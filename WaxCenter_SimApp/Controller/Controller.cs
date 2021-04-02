using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.GUIComponents.OptionsComponents;
using WaxCenter_SimApp.GUIComponents.Screens;
using WaxCenter_SimApp.GUIComponents.SimComponents;
using WaxCenter_SimApp.Model.Simulation.GUIData;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Settings;
using WaxCenter_SimApp.Model.Simulation.TrafikaSimulation;
using WaxCenter_SimApp.Model.Simulation.VaccinationCenter;

namespace WaxCenter_SimApp.Controller
{
    public enum RealTimeUpdateDataType
    {
        SIMULATION_START,
        SIMULATION_CONTINUE,
        SIMULATION_STOP,
        SIMULATION_COMPLETED,
        CLOCK_DATA,
        SIMULATION_DATA
    }

    public struct ReplicationsUpdateData
    {
        public int Progress { get; set; }
    }

    public enum ReplicationsUpdateType
    {
        SIMULATION_START,
        SIMULATION_CONTINUE,
        SIMULATION_STOP,
        SIMULATION_DATA
    }
    public class Controller
    {
        private AppGUI _applicationGUI;
        private EventSimCoreVaccinationCenter _simulation;
        private SimulationOptions _simOptions;

        private BackgroundWorker _realTimeSimWorker;
        private SimulationControl _realSimControl;

        private BackgroundWorker _replicationsWorker;
        private ReplicationControl _replicationSimControl;

        private ReplicationsSimulationSettings _replicationsSettings;
        private ReplicationsUpdateData _replicationsUpdateData = new ReplicationsUpdateData();
        //private ReplicationsResults _replicationsResults;

        private int[] _speedList = new int[] { 1, 2, 5, 10, 25, 50, 100, 1000, 5000, 10000, 100000, 100000000, 500000000 };
        //public GUIDataValuesVacCenter GUIData { get; private set; }
        public SimulationStatus RealTimeSimulationStatus { get => _simulation.Status; private set => _simulation.Status = value; }
        public SimulationStatus ReplicationsSimulationStatus { 
            get => _replicationsSettings.ReplicationSimulationStatus; 
            private set => _replicationsSettings.ReplicationSimulationStatus = value; 
        }
        

        public bool RealTimeCancellation { get => _realTimeSimWorker.CancellationPending; }

        public Controller(AppGUI appGUI, SimulationControl realTimeSim, ReplicationControl replicationSim, SimulationOptions simOptions)
        {
            _applicationGUI = appGUI;
            _simulation = new EventSimCoreVaccinationCenter(this);
            _simulation.Controller = this;
            //GUIData = new GUIDataValuesVacCenter(_simulation);

            _realSimControl = realTimeSim;

            _simOptions = simOptions;
            _simOptions.PreFillSettings(_simulation.SimulationSettings);
            
            for(int i = 0; i < _simulation.SimulationComponentsManager.ServiceComponents.Length; ++i)
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
            
            _replicationsSettings = new ReplicationsSimulationSettings();
            _replicationsSettings.NumberOfReplications = 1000;
        }

        public Controller(EventSimCoreVaccinationCenter simulation)
        {
            _simulation = simulation;
            _replicationsSettings = new ReplicationsSimulationSettings();
            //_replicationsResults = new ReplicationsResults();
            /*_replicationsResults.CurrentReplications = 0;
            _replicationsResults.ObservedValues = new double[7];*/
        }

        public void Test()
        {
            /*Random tmp = new Random();
            int cislo = tmp.Next(50);
            Console.WriteLine(cislo);*/
            _replicationsSettings.NumberOfReplications = 10000;
            _simulation.BeforeSimulation();
            for (int i = _simulation.ReplicationResults.CurrentReplications; i < _replicationsSettings.NumberOfReplications; ++i)
            {
                _simulation.BeforeReplication();
                _simulation.DoReplication();
                _simulation.AfterReplication();
            }
            foreach (var group in _simulation.ReplicationResults.ResultGroups)
            {
                foreach (var stat in group.GroupResults)
                {
                    for (int i = 0; i < stat.Values.Length; ++i)
                    {
                        Console.WriteLine(stat.Names[i] + ": " + (stat.Values[i] / _simulation.ReplicationResults.CurrentReplications));
                    }
                }
            }
        }

        public bool RunReplicationsWithGUIUpdate(BackgroundWorker replicationWorek)
        {
            _replicationsWorker = replicationWorek;
            if(ReplicationsSimulationStatus != SimulationStatus.PAUSED)
            {
                _simulation.BeforeSimulation();
                _simulation.ResetSimulation();
                _simulation.ReplicationResults.Reset();
                _replicationsUpdateData.Progress = 0;
                _replicationsWorker.ReportProgress((int)ReplicationsUpdateType.SIMULATION_START, _replicationsUpdateData);
            }
            
            for(int i = _simulation.ReplicationResults.CurrentReplications; i < _replicationsSettings.NumberOfReplications; ++i)
            {
                _simulation.BeforeReplication();
                _simulation.DoReplication();
                _simulation.AfterReplication();
                if (_simulation.ReplicationResults.CurrentReplications % _replicationsSettings.DataUpdateInterval == 0)
                    UpdateGUIAfterReplication();
                if(_replicationsWorker.CancellationPending)
                {
                    UpdateGUIAfterReplication();
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
            UpdateGUIAfterReplication();
            //for(int i = )
            ReplicationsSimulationStatus = SimulationStatus.FINISHED;
            return true;
        }

        private void UpdateGUIAfterReplication()
        {
            _replicationsUpdateData.Progress = (int)((((double)_simulation.ReplicationResults.CurrentReplications) / _replicationsSettings.NumberOfReplications) * 100);
            _replicationsWorker.ReportProgress((int)ReplicationsUpdateType.SIMULATION_DATA, _replicationsUpdateData);
        }

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
            //_simulation.DoReplication();
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

        public bool AfterEventUpdate()
        {
            _realTimeSimWorker.ReportProgress((int)RealTimeUpdateDataType.SIMULATION_DATA);
            return true;
        }

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

        public void AfterRealTimeSimulationStopped()
        {
            RealTimeSimulationStatus = SimulationStatus.CANCELED;
        }

        public void AfterReplicationsSimulationStopped()
        {
            ReplicationsSimulationStatus = SimulationStatus.CANCELED;
        }

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

        public void SwitchToReplicationScreen()
        {
            PrefillReplicationsOptions();
        }

        public void SwitchToSimulationScreen()
        {
            PrefillReplicationsOptions();
        }

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
                    _replicationSimControl.ReplicationsInputText = "Number must be positive";
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
                    _replicationSimControl.DoctorInputText = "Number must be positive";
            }

            if (!Int32.TryParse(_replicationSimControl.NurseInputText, out nurseStaff))
            {
                error = true;
                _replicationSimControl.NurseInputText = "Invalid number";
            }
            else
            {
                if (nurseStaff < 1)
                    _replicationSimControl.NurseInputText= "Number must be positive";
            }

            if (!double.TryParse(_replicationSimControl.IntervalInputText, out arrivalInterval))
            {
                error = true;
                _replicationSimControl.IntervalInputText = "Invalid number";
            }
            else
            {
                if (arrivalInterval < 1)
                    _replicationSimControl.IntervalInputText = "Number must be positive";
            }

            if (!Int32.TryParse(_replicationSimControl.PatientInputText, out numOfPatients))
            {
                error = true;
                _replicationSimControl.PatientInputText = "Invalid number";
            }
            else
            {
                if (numOfPatients < 1)
                    _replicationSimControl.PatientInputText = "Number must be positive";
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

        private void ReplicationsOptionsChanged()
        {
            SimulationOptionsChanged();
            _replicationSimControl.RebuildStatTables();
            _replicationSimControl.UpdateStatTables();
        }

        private void SimulationOptionsChanged()
        {
            _simulation.ReplicationResults.Rebuild();
            _simulation.ResetSimulation();
        }

        public void PrefillReplicationsOptions()
        {
            _replicationSimControl.UpdateIntervalInputText = _replicationsSettings.DataUpdateInterval.ToString();
            _replicationSimControl.ReplicationsInputText = _replicationsSettings.NumberOfReplications.ToString();
            _replicationSimControl.AdminInputText = _simulation.AdminService.ResourcePool.MaxStaff.ToString();
            _replicationSimControl.DoctorInputText = _simulation.ExaminationService.ResourcePool.MaxStaff.ToString();
            _replicationSimControl.NurseInputText = _simulation.VaccinationService.ResourcePool.MaxStaff.ToString();
            _replicationSimControl.PatientInputText = _simulation.PatientGenerated.ToString();
            _replicationSimControl.IntervalInputText = _simulation.SourceInterval.ToString();
        }

    }
}
