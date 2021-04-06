using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WaxCenter_SimApp.GUIComponents.OptionsComponents;
using WaxCenter_SimApp.GUIComponents.Screens;
using WaxCenter_SimApp.GUIComponents.SimComponents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Settings;
using WaxCenter_SimApp.Model.Simulation.VaccinationCenter;

namespace WaxCenter_SimApp.Controller
{
    /** Enum predstavuje typ dat, ktore boli zaslane ako parameter metody.*/
    public enum RealTimeUpdateDataType
    {
        SIMULATION_START,
        SIMULATION_CONTINUE,
        SIMULATION_STOP,
        SIMULATION_COMPLETED,
        CLOCK_DATA,
        SIMULATION_DATA
    }

    /** Struktura obsahujuca informacie o progresse simulacie s viacerymi replikaciami a aj zamok, ktory je pouzity na medzi vlaknovu synchronizaciu.*/
    public struct ReplicationsUpdateData
    {
        public int Progress { get; set; }
        public AutoResetEvent WaitHandle { get; set; }
    }
    /** Struktura obsahujuca data pre aktualizaciu progresu experimentalnej simulacie. */
    public struct ExperimentalUpdateData
    {
        public int Progress { get; set; }
        public AutoResetEvent WaitHandle { get; set; }
    }
    /** Enum obsahuje mozne typy aktualizacii progresu, ktore maju byt vykonane.*/
    public enum ProgressUpdateType
    {
        SIMULATION_START,
        SIMULATION_CONTINUE,
        SIMULATION_STOP,
        SIMULATION_DATA,
        SIMULATION_PROGRESS
    }
    public class Controller
    {
        /** Spojovaci clanok medzi logickou a grafickou castou programu.*/
        private AppGUI _applicationGUI;
        private EventSimCoreVaccinationCenter _simulation;
        private SimulationOptions _simOptions;

        /** Odkaz na background workera a obrazovku pre real time simulaciu.*/
        private BackgroundWorker _realTimeSimWorker;
        private SimulationControl _realSimControl;
        /** Getter a setter pre status real time simulacie.*/
        public SimulationStatus RealTimeSimulationStatus { get => _simulation.Status; private set => _simulation.Status = value; }

        /** Odkaz na background workera a obrazovku pre simulaciu s viacero replikaciami. */
        private ReplicationControl _replicationSimControl;
        private ReplicationsSimulationSettings _replicationsSettings;
        private ReplicationsUpdateData _replicationsUpdateData = new ReplicationsUpdateData();
        
        /** Aktualny status simulacie s viacerymi replikaciami.*/
        public SimulationStatus ReplicationsSimulationStatus
        {
            get => _replicationsSettings.ReplicationSimulationStatus;
            private set => _replicationsSettings.ReplicationSimulationStatus = value;
        }

        /** Odkaz na background workera a obrazovku pre vykonavanie experimentalnej simulacie. */
        private StaffExperimentalControl _experimentSimControl;
        private ExperimentalSimulationSettings _experimentalSettings;
        private ExperimentalUpdateData _experimentalUpdateData = new ExperimentalUpdateData();
        /** Aktualny statu experimentalnej simulacie.*/
        public SimulationStatus ExperimentalSimulationStatus
        {
            get => _experimentalSettings.ExperimentalSimulationStatus;
            private set => _experimentalSettings.ExperimentalSimulationStatus = value;
        }
        /** List moznych rychlosti real time simulacie. */
        private int[] _speedList = new int[] { 1, 2, 5, 10, 25, 50, 100, 1000, 5000, 10000, 100000, 100000000, 500000000 };

        public bool RealTimeCancellation { get => _realTimeSimWorker.CancellationPending; }

        public Controller(AppGUI appGUI, SimulationControl realTimeSim, ReplicationControl replicationSim, 
                          StaffExperimentalControl experimentalSim, SimulationOptions simOptions)
        {
            _applicationGUI = appGUI;
            _simulation = new EventSimCoreVaccinationCenter(this);
            _simulation.Controller = this;

            _realSimControl = realTimeSim;

            _simOptions = simOptions;
            _simOptions.PreFillSettings(_simulation.SimulationSettings);
            /** Nastavenie ID pre Graficke komponenty simulacie a priradenie referencii na dane komponenty zodpovedajucim grafickym komponentom. */
            for (int i = 0; i < _simulation.SimulationComponentsManager.ServiceComponents.Length; ++i)
            {
                _realSimControl.GUISimComponentManager.GSimResourcePools[i].ID = i;
                _realSimControl.GUISimComponentManager.GSimResourcePools[i].ServiceModelComponent = 
                    _simulation.SimulationComponentsManager.ServiceComponents[i];

                _realSimControl.GUISimComponentManager.GSimServices[i].ID = i;
                _realSimControl.GUISimComponentManager.GSimServices[i].ServiceModelComponent =
                    _simulation.SimulationComponentsManager.ServiceComponents[i];
            }

            for (int i = 0; i < _simulation.SimulationComponentsManager.DelayComponents.Length; ++i)
            {
                _realSimControl.GUISimComponentManager.GSimDelays[i].ID = i;
                _realSimControl.GUISimComponentManager.GSimDelays[i].DelayModelComponent =
                    _simulation.SimulationComponentsManager.DelayComponents[i];
            }

            for (int i = 0; i < _simulation.SimulationComponentsManager.Statistics.Length; ++i)
            {
                _realSimControl.GUISimComponentManager.GSimStats[i].ID = i;
                _realSimControl.GUISimComponentManager.GSimStats[i].StatisticModel =
                    _simulation.SimulationComponentsManager.Statistics[i];
            }

            _realSimControl.GUISimComponentManager.GSimSource.SourceModelComponent = _simulation.SimulationComponentsManager.Source;
            _realSimControl.GUISimComponentManager.GSimSink.SinkModelComponent = _simulation.SimulationComponentsManager.Sink;

            TimeSpan t = TimeSpan.FromSeconds(_simulation.StartTimeInSeconds);
            var startTime = t.ToString(@"hh\:mm\:ss");

            _realSimControl.SetClockValue(startTime);
            _realSimControl.SetClockTicks(_speedList.Length - 1);

            _realSimControl.UpdateValues();

            _replicationSimControl = replicationSim;
            _replicationSimControl.SetReplicationResults(_simulation.ReplicationResults);

            _experimentSimControl = experimentalSim;
            _experimentSimControl.ReplicationResults = _simulation.ReplicationResults;

            _replicationsSettings = new ReplicationsSimulationSettings();
            _replicationsSettings.NumberOfReplications = 1000;

            _experimentalSettings = new ExperimentalSimulationSettings();
        }

        public bool RunExperimentalSimulation(BackgroundWorker experimentalWorker)
        {
            /** Metoda v ktorej sa vykonava experimentalny beh simulacie. V ramci nej dochadza k testovaniu roznych kombinacii poctov personalu na jednotlivych stanovistiach. */
            AutoResetEvent waitHandle;
            _experimentSimControl.ValuesProcessed = true;
            if (ExperimentalSimulationStatus != SimulationStatus.PAUSED)
            {
                _simulation.BeforeSimulation();
                _simulation.ResetSimulation();
                _simulation.ReplicationResults.Reset();
                _experimentalUpdateData.Progress = 0;
                _experimentSimControl.ClearGraphSeries();
                _experimentalSettings.CurrentExperimentalReplications = 0;
                _experimentalSettings.CurrentReplication = 0;
                _experimentalSettings.ResetActual();
                _experimentalSettings.CalculateMaxReplications();
                experimentalWorker.ReportProgress((int)ProgressUpdateType.SIMULATION_START, _experimentalUpdateData);
            }
            for (_experimentalSettings.ActualAdmin = _experimentalSettings.MinAdmin;
                _experimentalSettings.ActualAdmin <= _experimentalSettings.MaxAdmin;
                ++_experimentalSettings.ActualAdmin)
            {
                for( _experimentalSettings.ActualNurse = _experimentalSettings.MinNurse;
                    _experimentalSettings.ActualNurse <= _experimentalSettings.MaxNurse;
                    ++_experimentalSettings.ActualNurse)
                {
                    _experimentSimControl.AddNewSeries($"Admin: {_experimentalSettings.ActualAdmin} Nurses: {_experimentalSettings.ActualNurse}");
                    for (_experimentalSettings.ActualDoctor = _experimentalSettings.MinDoctor; 
                        _experimentalSettings.ActualDoctor <= _experimentalSettings.MaxDoctor;
                        ++_experimentalSettings.ActualDoctor)
                    {
                        /** Nastavenie hodnot jednotlivych typov personalu pre nasledujuci beh replikacii. Vytvorenie */
                        waitHandle = new AutoResetEvent(false);
                        _experimentSimControl.WaitHandle = waitHandle;
                        _simulation.AdminService.MaxStaff = _experimentalSettings.ActualAdmin;
                        _simulation.ExaminationService.MaxStaff = _experimentalSettings.ActualDoctor;
                        _simulation.VaccinationService.MaxStaff = _experimentalSettings.ActualNurse;
                        _simulation.ReplicationResults.Rebuild();
                        _simulation.BeforeSimulation();
                        for (; _experimentalSettings.CurrentExperimentalReplications < _experimentalSettings.RepPerExperiment;
                            ++_experimentalSettings.CurrentExperimentalReplications)
                        {
                            _simulation.BeforeReplication();
                            _simulation.DoReplication();
                            _simulation.AfterReplication();
                            ++_experimentalSettings.CurrentReplication;
                            if (_experimentalSettings.CurrentReplication % 100 == 0)
                            {
                                _experimentalUpdateData.Progress = (int)(((double)_experimentalSettings.CurrentReplication / _experimentalSettings.MaxReplications) * 100);
                                experimentalWorker.ReportProgress((int)ProgressUpdateType.SIMULATION_PROGRESS, _experimentalUpdateData);
                            }
                            if (experimentalWorker.CancellationPending)
                            {
                                ExperimentalSimulationStatus = SimulationStatus.CANCELED;
                                return false;
                            }
                        }
                        _experimentalSettings.CurrentExperimentalReplications = 0;
                        _experimentSimControl.ValuesProcessed = false;
                        UpdateGUIAfterExperiment(experimentalWorker);

                        /** Synchronizacia vlakien.*/
                        if (!_experimentSimControl.ValuesProcessed)
                        {
                            waitHandle.WaitOne();
                        }
                    }
                }

            }
            ExperimentalSimulationStatus = SimulationStatus.FINISHED;
            return true;
        }

        private void UpdateGUIAfterExperiment(BackgroundWorker experimentalWorker)
        {
            /** Metoda, ktora je zavolana po vykonani replikacii pre danu kombinaciu poctu personalu.*/
            _experimentalUpdateData.Progress = (int)(((double)_experimentalSettings.CurrentReplication / _experimentalSettings.MaxReplications) * 100);
            experimentalWorker.ReportProgress((int)ProgressUpdateType.SIMULATION_DATA, _experimentalUpdateData);
        }

        /**
         * Metoda pre vykonavanie simulacneho behu s viacerymi replikaciami.
         */
        public bool RunReplicationsWithGUIUpdate(BackgroundWorker replicationsWorker)
        {

            if(ReplicationsSimulationStatus != SimulationStatus.PAUSED)
            {
                _simulation.BeforeSimulation();
                _simulation.ResetSimulation();
                _simulation.ReplicationResults.Reset();
                _replicationsUpdateData.Progress = 0;
                replicationsWorker.ReportProgress((int)ProgressUpdateType.SIMULATION_START, _replicationsUpdateData);
            }
            
            for(int i = _simulation.ReplicationResults.CurrentReplications; i < _replicationsSettings.NumberOfReplications; ++i)
            {
                _simulation.BeforeReplication();
                _simulation.DoReplication();
                _simulation.AfterReplication();
                if (_simulation.ReplicationResults.CurrentReplications % _replicationsSettings.DataUpdateInterval == 0)
                    UpdateGUIAfterReplication(replicationsWorker);
                if(replicationsWorker.CancellationPending)
                {
                    UpdateGUIAfterReplication(replicationsWorker);
                    if (_simulation.ReplicationResults.CurrentReplications != _replicationsSettings.NumberOfReplications)
                    {
                        if(_replicationSimControl.PauseClicked)
                        {
                            ReplicationsSimulationStatus = SimulationStatus.PAUSED;
                        }
                        else
                        {
                            ReplicationsSimulationStatus = SimulationStatus.CANCELED;
                        }
                        return false;
                    }
                    else
                    {
                        ReplicationsSimulationStatus = SimulationStatus.FINISHED;
                        return true;
                    }
                }
            }
            UpdateGUIAfterReplication(replicationsWorker);
            ReplicationsSimulationStatus = SimulationStatus.FINISHED;
            return true;
        }

        /**
         * Metoda, ktora sa vykona po urcitom pocte vykonanych replikacii a zabezpeci odoslanie poziadavky pre prekreslenie grafickych komponentov tykajucich sa simulacneho behu s viacerymi replikaciami.
         */
        private void UpdateGUIAfterReplication(BackgroundWorker replicationsWorker)
        {
            AutoResetEvent waitHandle = new AutoResetEvent(false);
            _replicationSimControl.ValueProcessed = false;
            _replicationsUpdateData.WaitHandle = waitHandle;

            _replicationsUpdateData.Progress = (int)((((double)_simulation.ReplicationResults.CurrentReplications) / _replicationsSettings.NumberOfReplications) * 100);
            replicationsWorker.ReportProgress((int)ProgressUpdateType.SIMULATION_DATA, _replicationsUpdateData);

            if(!_replicationSimControl.ValueProcessed)
            {
                waitHandle.WaitOne();
            }
        }

        /**
         * Metoda v ktorej bezi real time simulacia.
         */
        public bool RunRealTimeSimulation(BackgroundWorker simulationWorker)
        {
            _realTimeSimWorker = simulationWorker;
            if(RealTimeSimulationStatus != SimulationStatus.PAUSED)
            {
                _simulation.BeforeSimulation();
                _simulation.BeforeReplication();
                _realTimeSimWorker.ReportProgress((int)RealTimeUpdateDataType.SIMULATION_DATA);
                _realTimeSimWorker.ReportProgress((int)RealTimeUpdateDataType.CLOCK_DATA, new ClockUpdateData(_simulation.ClockTimeInSeconds));
            }
            if (_simulation.RunRealTimeSimulation() != SimulationStatus.FINISHED)
            {
                if (_realSimControl.PauseClicked)
                    RealTimeSimulationStatus = SimulationStatus.PAUSED;
                else
                {
                    _simulation.AfterReplication();
                    _realTimeSimWorker.ReportProgress((int)RealTimeUpdateDataType.SIMULATION_DATA);
                    RealTimeSimulationStatus = SimulationStatus.CANCELED;
                }
                return false;
            }
            else
            {
                _simulation.AfterReplication();
            }

            return true;
        }

        /**
         * Metoda, ktora background workerovy nahlasi aby vykonl update real time simulacie.
         */
        public bool AfterEventUpdate()
        {
            _realTimeSimWorker.ReportProgress((int)RealTimeUpdateDataType.SIMULATION_DATA);
            return true;
        }

        /**
         * Updatuje zobrazovany cas v real time simulacii.
         */
        public void ClockUpdate()
        {
            _realTimeSimWorker.ReportProgress((int)RealTimeUpdateDataType.CLOCK_DATA, new ClockUpdateData(_simulation.ClockTimeInSeconds));
        }

        public void SetSimulationSpeed(int speedIndex)
        {
            _simulation.Speed = _speedList[speedIndex];
        }

        public void ResetRealTimeSimulation()
        {
            _simulation.ResetSimulation();
            _realSimControl.UpdateValues();
            TimeSpan t = TimeSpan.FromSeconds(_simulation.StartTimeInSeconds);
            var startTime = t.ToString(@"hh\:mm\:ss");
            _realSimControl.SetClockValue(startTime);
        }

        public void ResetReplicationsSimulation()
        {
            _simulation.ResetSimulation();
            _simulation.ReplicationResults.Reset();
            _replicationSimControl.RebuildStatTables();
        }

        public void ResetExperimentalSimulation()
        {
            _simulation.ResetSimulation();
            _simulation.ReplicationResults.Reset();
            _experimentSimControl.Reset();
        }

        public void AfterRealTimeSimulationStopped()
        {
            RealTimeSimulationStatus = SimulationStatus.CANCELED;
        }

        public void AfterReplicationsSimulationStopped()
        {
            ReplicationsSimulationStatus = SimulationStatus.CANCELED;
        }

        public void AfterExperimentalSimulationStopped()
        {
            ReplicationsSimulationStatus = SimulationStatus.CANCELED;
        }

        /**
         * Metoda, v ktorej dochadaza k parsrovaniu a pripadnej aplikacii zadanych zakladnych nastaveni simulacie.
         */
        public void TryApplyBaseSimulationSettings()
        {
            bool errorOccured = false;
            int seed = 0;
            double maxTime;

            if(!double.TryParse(_simOptions.MaxTimeInputText, out maxTime))
            {
                _simOptions.MaxTimeInputText = "Invalid input!";
                errorOccured = true;
            }

            if(!_simOptions.AutoSeedChecked)
            {
                if(!Int32.TryParse(_simOptions.SeedInputText, out seed))
                {
                    _simOptions.SeedInputText = "Invalid input!";
                    errorOccured = true;
                }
            }
            if(!errorOccured)
            {
                _simulation.SimulationSettings.Units = _simOptions.SelectedTimeUnits;
                _simulation.MaxTime = maxTime;
                _simulation.AutoSeed = _simOptions.AutoSeedChecked;
                if(!_simulation.AutoSeed)
                {
                    _simulation.Seed = seed;
                }
                _simulation.ContinueAfterMaxTime = _simOptions.AfterMaxTimeChecked;
            }
        }

        /**
         * Metoda, v ktorej pri zvoleni grafickeho komponentu simulacie dochadza k predvyplneniu hodnot.
         */
        public void HandleGUIComponentSelection(ISimComponent simComponent, IGUIOptions optionsComponent)
        {
            switch(simComponent.SimComponentType)
            {
                case SimComponentType.SOURCE:
                    var sourceOptions = (SimSourceOptions)optionsComponent;
                    var sourceGUIComponent = (SimSource)simComponent;
                    sourceOptions.AgentsInputText = _simulation.PatientGenerated.ToString();
                    sourceOptions.IntervalInputText = _simulation.SourceInterval.ToString();
                    break;
                case SimComponentType.RESOURCEPOOL:
                    var resPoolOptions = (SimResPoolOptions)optionsComponent;
                    var resPoolGUIComponent = (SimResourcePool)simComponent;
                    resPoolOptions.StaffInputText = resPoolGUIComponent.ServiceModelComponent.MaxService.ToString();
                    break;
                default:
                    break;
            }
        }

        /**
         * Metoda, v ktorej sa vyberie metoda pre spracovanie nastaveni, ktore boli zadane pre resource pool alebo pre source.
         */
        public void HandleGUIComponentOptionsConfirmation(ISimComponent simComponent, IGUIOptions optionsComponent)
        {
            switch (simComponent.SimComponentType)
            {
                case SimComponentType.SOURCE:
                    var sourceOptions = (SimSourceOptions)optionsComponent;
                    var sourceGUIComponent = (SimSource)simComponent;
                    TryParseSourceOptions(sourceOptions, sourceGUIComponent);
                    break;
                case SimComponentType.RESOURCEPOOL:
                    var resPoolOptions = (SimResPoolOptions)optionsComponent;
                    var resPoolGUIComponent = (SimResourcePool)simComponent;
                    TryParseResourcePoolOptions(resPoolOptions, resPoolGUIComponent);
                    break;
                default:
                    break;
            }
        }

        public void ResetSimulation()
        {
            _simulation.ResetSimulation();
        }

        /**
         * Metoda, v ktorej dochadaza k parsrovaniu a pripadnej aplikacii nastaveni suvisiacich s poctom a intervalom prichodu pacientov.
         */
        private void TryParseSourceOptions(SimSourceOptions options, SimSource resPoolGUI)
        {
            bool error = false;
            int agentsGenerated = 0;
            double intervalRate = 0;

            if (!double.TryParse(options.IntervalInputText, out intervalRate))
            {
                error = true;
                options.IntervalInputText = "Invalid number";
            }
            else
            {
                if (intervalRate <=0)
                {
                    options.IntervalInputText = "Number have to be between (0, inf)!";
                    error = true;
                }
            }

            if (!Int32.TryParse(options.AgentsInputText, out agentsGenerated))
            {
                error = true;
                options.AgentsInputText = "Invalid number";
            }
            else
            {
                if (agentsGenerated < 1)
                {
                    options.AgentsInputText = "Number have to be between <1, inf)!";
                    error = true;
                }
            }

            if(!error)
            {
                _simulation.SourceInterval = intervalRate;
                _simulation.PatientGenerated = agentsGenerated;
            }

        }
        /**
         * Metoda, v ktorej dochadaza k parsrovaniu a pripadnej aplikacii nastaveni pre zvoleny resource pool.
         */
        private void TryParseResourcePoolOptions(SimResPoolOptions options, SimResourcePool resPoolGUI)
        {
            bool error = false;
            int maxStaff = 0;

            if(!Int32.TryParse(options.StaffInputText, out maxStaff))
            {
                error = true;
                options.StaffInputText = "Invalid number";
            }
            else
            {
                if (maxStaff < 1)
                {
                    options.StaffInputText = "Number have to be between <1, inf)!";
                    error = true;
                }  
            }
            
            if(!error)
            {
                resPoolGUI.ServiceModelComponent.MaxStaff = maxStaff;
                resPoolGUI.UpdateAccordingToState();
            }

        }

        /**
         * Metoda, v ktorej dochadaza k parsrovaniu a pripadnej aplikacii zadanych nastaveni simulacie s viacerymi replikaciami.
         */
        public void TryParseAndApplyReplicationsOptions()
        {
            bool error = false;
            int replications = 0;
            int adminStaff = 0;
            int doctorStaff = 0;
            int nurseStaff = 0;
            double arrivalInterval = 0;
            int numOfPatients = 0;
            int updateInterval = 0;

            if (!Int32.TryParse(_replicationSimControl.UpdateIntervalInputText, out updateInterval))
            {
                error = true;
                _replicationSimControl.UpdateIntervalInputText = "Invalid number";

            }
            else
            {
                if (updateInterval < 1)
                    _replicationSimControl.UpdateIntervalInputText = "Number must be positive";
            }

            if (!Int32.TryParse(_replicationSimControl.ReplicationsInputText, out replications))
            {
                error = true;
                _replicationSimControl.ReplicationsInputText = "Invalid number";

            }
            else
            {
                if (replications < 1)
                {
                    _replicationSimControl.ReplicationsInputText = "Number must be positive";
                    error = true;
                }
                    
            }

            if (!Int32.TryParse(_replicationSimControl.AdminInputText, out adminStaff))
            {
                error = true;
                _replicationSimControl.AdminInputText = "Invalid number";

            }
            else
            {
                if(adminStaff < 1 )
                    _replicationSimControl.AdminInputText = "Number must be positive";
            }

            if (!Int32.TryParse(_replicationSimControl.DoctorInputText, out doctorStaff))
            {
                error = true;
                _replicationSimControl.DoctorInputText = "Invalid number";

            }
            else
            {
                if (doctorStaff < 1)
                {
                    _replicationSimControl.DoctorInputText = "Number must be positive";
                    error = true;
                }
            }

            if (!Int32.TryParse(_replicationSimControl.NurseInputText, out nurseStaff))
            {
                error = true;
                _replicationSimControl.NurseInputText = "Invalid number";
            }
            else
            {
                if (nurseStaff < 1)
                {
                    _replicationSimControl.NurseInputText = "Number must be positive";
                    error = true;
                }
                    
            }

            if (!double.TryParse(_replicationSimControl.IntervalInputText, out arrivalInterval))
            {
                error = true;
                _replicationSimControl.IntervalInputText = "Invalid number";
            }
            else
            {
                if (arrivalInterval < 1)
                {
                    _replicationSimControl.IntervalInputText = "Number must be positive";
                    error = true;
                }
            }

            if (!Int32.TryParse(_replicationSimControl.PatientInputText, out numOfPatients))
            {
                error = true;
                _replicationSimControl.PatientInputText = "Invalid number";
            }
            else
            {
                if (numOfPatients < 1)
                {
                    _replicationSimControl.PatientInputText = "Number must be positive";
                    error = true;
                }
                    
            }

            if(!error)
            {
                _replicationsSettings.DataUpdateInterval = updateInterval;
                _replicationsSettings.NumberOfReplications = replications;
                _simulation.PatientGenerated = numOfPatients;
                _simulation.SourceInterval = arrivalInterval;
                _simulation.AdminService.MaxStaff = adminStaff;
                _simulation.ExaminationService.MaxStaff = doctorStaff;
                _simulation.VaccinationService.MaxStaff = nurseStaff;
                ReplicationsOptionsChanged();
            }
        }

        /**
         * Metoda, v ktorej dochadaza k parsrovaniu a pripadnej aplikacii zadanych nastaveni pre experimentalnu simulaciu.
         */
        public void TryParseAndApplyExperimentalOptions()
        {
            bool error = false;
            int replications = 0;
            int adminStaffMin = 0;
            int adminStaffMax = 0;
            int doctorStaffMin = 0;
            int doctorStaffMax = 0;
            int nurseStaffMin = 0;
            int nurseStaffMax = 0;
            double arrivalInterval = 0;
            int numOfPatients = 0;

            string[] minMaxValues;

            minMaxValues = _experimentSimControl.AdminInputText.Split('-');
            if (minMaxValues.Length == 2 &&
                Int32.TryParse(minMaxValues[0], 
                out adminStaffMin) &&
                Int32.TryParse(minMaxValues[1],
                out adminStaffMax))
            {
                if (adminStaffMax < 1 || adminStaffMin < 1)
                {
                    _experimentSimControl.AdminInputText = "Number must be positive";
                    error = true;
                }
                else if (adminStaffMin > adminStaffMax)
                {
                    _experimentSimControl.AdminInputText = "Wrong bounds";
                    error = true;
                }
            }
            else
            {
                error = true;
                _experimentSimControl.AdminInputText = "Invalid number";
            }

            minMaxValues = _experimentSimControl.DoctorInputText.Split('-');

            if (minMaxValues.Length == 2 &&
                Int32.TryParse(minMaxValues[0],
                out doctorStaffMin) &&
                Int32.TryParse(minMaxValues[1],
                out doctorStaffMax))
            {
                if (doctorStaffMin < 1 || doctorStaffMax < 1)
                {
                    _experimentSimControl.DoctorInputText = "Number must be positive";
                    error = true;
                }
                else if (doctorStaffMin > doctorStaffMax)
                {
                    _experimentSimControl.DoctorInputText = "Wrong bounds";
                    error = true;
                }
            }
            else
            {
                error = true;
                _experimentSimControl.DoctorInputText = "Invalid number";

            }

            minMaxValues = _experimentSimControl.NurseInputText.Split('-');

            if (minMaxValues.Length == 2 &&
                Int32.TryParse(minMaxValues[0],
                out nurseStaffMin) &&
                Int32.TryParse(minMaxValues[1],
                out nurseStaffMax))
            {
                if (nurseStaffMin < 1 || nurseStaffMax < 1)
                {
                    _experimentSimControl.NurseInputText = "Number must be positive";
                    error = true;
                }
                else if (nurseStaffMin > nurseStaffMax)
                {
                    _experimentSimControl.NurseInputText = "Wrong bounds";
                    error = true;
                }
               
            }
            else
            {
                error = true;
                _experimentSimControl.NurseInputText = "Invalid number";
            }

            if (!Int32.TryParse(_experimentSimControl.ReplicationsInput, out replications))
            {
                error = true;
                _experimentSimControl.ReplicationsInput = "Invalid number";
            }
            else
            {
                if (replications < 1)
                    _experimentSimControl.ReplicationsInput = "Number must be positive";
            }

            if (!Int32.TryParse(_experimentSimControl.PatientsInputText, out numOfPatients))
            {
                error = true;
                _experimentSimControl.PatientsInputText = "Invalid number";
            }
            else
            {
                if (numOfPatients < 1)
                    _experimentSimControl.PatientsInputText = "Number must be positive";
            }

            if (!double.TryParse(_experimentSimControl.ArrivalInputText, out arrivalInterval))
            {
                error = true;
                _experimentSimControl.ArrivalInputText = "Invalid number";
            }
            else
            {
                if (arrivalInterval <= 0)
                    _experimentSimControl.ArrivalInputText = "Number must be positive";
            }


            if (!error)
            {
                _experimentalSettings.MaxAdmin = adminStaffMax;
                _experimentalSettings.MinAdmin = adminStaffMin;
                _experimentalSettings.MaxDoctor = doctorStaffMax;
                _experimentalSettings.MinDoctor = doctorStaffMin;
                _experimentalSettings.MaxNurse = nurseStaffMax;
                _experimentalSettings.MinNurse = nurseStaffMin;
                _experimentalSettings.RepPerExperiment = replications;
                _simulation.PatientGenerated = numOfPatients;
                _simulation.SourceInterval = arrivalInterval;
                SimulationOptionsChanged();
            }
        }

        public void SwitchToReplicationScreen()
        {
            _simulation.ResetSimulation();
            _simulation.ReplicationResults.Reset();
            _replicationSimControl.Reset();
            PrefillReplicationsOptions();
        }

        public void SwitchToSimulationScreen()
        {
            ResetRealTimeSimulation();
        }

        public void SwitchToExperimentalScreen()
        {
            _simulation.ResetSimulation();
            SetExperimentalSettingsAcordingToActual();
            PrefilExperimentalOptions();
        }

        private void ReplicationsOptionsChanged()
        {
            SimulationOptionsChanged();
            _replicationSimControl.RebuildStatTables();
            _replicationSimControl.Reset();
        }

        private void SimulationOptionsChanged()
        {
            _simulation.ReplicationResults.Rebuild();
            _simulation.ResetSimulation();
        }

        /**
         * Metoda, pre predvyplnenie nastaveni simulacie s viacerymi replikaciami vzhladom na sucasne nastavenia.
         */
        private void PrefillReplicationsOptions()
        {
            _replicationSimControl.UpdateIntervalInputText = _replicationsSettings.DataUpdateInterval.ToString();
            _replicationSimControl.ReplicationsInputText = _replicationsSettings.NumberOfReplications.ToString();
            _replicationSimControl.AdminInputText = _simulation.AdminService.ResourcePool.MaxStaff.ToString();
            _replicationSimControl.DoctorInputText = _simulation.ExaminationService.ResourcePool.MaxStaff.ToString();
            _replicationSimControl.NurseInputText = _simulation.VaccinationService.ResourcePool.MaxStaff.ToString();
            _replicationSimControl.PatientInputText = _simulation.PatientGenerated.ToString();
            _replicationSimControl.IntervalInputText = _simulation.SourceInterval.ToString();
        }

        /**
         * Metoda, pre predvyplnenie experimentalnych nastaveni vzhladom na sucasne nastavenia.
         */
        private void SetExperimentalSettingsAcordingToActual()
        {
            _experimentalSettings.ActualAdmin = _simulation.AdminService.ResourcePool.MaxStaff;
            _experimentalSettings.MinAdmin = _experimentalSettings.ActualAdmin;
            _experimentalSettings.MaxAdmin = _experimentalSettings.ActualAdmin;

            _experimentalSettings.ActualDoctor = _simulation.ExaminationService.ResourcePool.MaxStaff;
            _experimentalSettings.MinDoctor = _experimentalSettings.ActualDoctor;
            _experimentalSettings.MaxDoctor = _experimentalSettings.ActualDoctor;

            _experimentalSettings.ActualNurse = _simulation.VaccinationService.ResourcePool.MaxStaff;
            _experimentalSettings.MinNurse = _experimentalSettings.ActualNurse;
            _experimentalSettings.MaxNurse = _experimentalSettings.ActualNurse;

            _experimentalSettings.ArrivalInterval = _simulation.SourceInterval;
            _experimentalSettings.NumberOfPatients = _simulation.PatientGenerated;
        }
        /**
         * Metoda, pre predvyplnenie grafickych komponentov experimentalnych nastaveni vzhladom na sucasne nastavenia.
         */
        private void PrefilExperimentalOptions()
        {
            _experimentSimControl.AdminInputText = _experimentalSettings.AdminPrefillText;
            _experimentSimControl.DoctorInputText = _experimentalSettings.DoctorPrefillText;
            _experimentSimControl.NurseInputText = _experimentalSettings.NursePrefillText;
            _experimentSimControl.ReplicationsInput = _experimentalSettings.RepPerExperiment.ToString();
            _experimentSimControl.ArrivalInputText = _experimentalSettings.ArrivalInterval.ToString();
            _experimentSimControl.PatientsInputText = _experimentalSettings.NumberOfPatients.ToString();
        }

    }
}
