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
    public enum UpdateDataType
    {
        SIMULATION_START,
        SIMULATION_CONTINUE,
        SIMULATION_STOP,
        SIMULATION_COMPLETED,
        CLOCK_DATA,
        SIMULATION_DATA
    }
    public class Controller
    {
        private AppGUI _applicationGUI;
        private EventSimCoreVaccinationCenter _simulation;
        private SimulationOptions _simOptions;

        private BackgroundWorker _realTimeSimWorker;
        private SimulationControl _realSimControl;

        private ReplicationsSettings _replicationsSettings;
        private ReplicationsResults _replicationsResults;

        private int[] _speedList = new int[] { 1, 2, 5, 10, 25, 50, 100, 1000 };
        //public GUIDataValuesVacCenter GUIData { get; private set; }
        public EventSimulationCore.SimulationStatus SimulationStatus { get => _simulation.Status; private set => _simulation.Status = value; }
        //private SimulationControl _realTimeSimulation;
        public bool PauseClicked { get; set; } = false;

        public bool RealTimeCancellation { get => _realTimeSimWorker.CancellationPending; }

        public Controller(AppGUI appGUI, SimulationControl realTimeSim, SimulationOptions simOptions)
        {
            _applicationGUI = appGUI;
            _simulation = new EventSimCoreVaccinationCenter(this);
            _simulation.Controller = this;
            //GUIData = new GUIDataValuesVacCenter(_simulation);

            _realSimControl = realTimeSim;
            //_realSimControl.ComponentsManager = _simulation.SimulationComponentsManager;
            //_realSimControl.GUIData = GUIData;
            //_realSimControl.Controller = this;

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

            _realSimControl.UpdateValues();
        }

        public Controller(EventSimCoreVaccinationCenter simulation)
        {
            _simulation = simulation;
            _replicationsSettings = new ReplicationsSettings();
            _replicationsSettings.NumberOfReplications = 15000;
            _replicationsResults = new ReplicationsResults();
            /*_replicationsResults.CurrentReplications = 0;
            _replicationsResults.ObservedValues = new double[7];*/
        }


        public bool RunReplications()
        {
            _simulation.BeforeSimulation();
            for(int i = _simulation.ReplicationResults.CurrentReplications; i < _replicationsSettings.NumberOfReplications; ++i)
            {
                _simulation.BeforeReplication();
                _simulation.DoReplication();
                _simulation.AfterReplication();
            }
            UpdateGUIAfterReplication();
            //for(int i = )

            return true;
        }

        private void UpdateGUIAfterReplication()
        {
            string[] outputTitle = new string[] { "Mean admin QL: ", "Mean admin WT: ", "Mean examination QL: ", "Mean examination WT: ",
                                                  "Mean vaccination QL: ", "Mean vaccination WT: ", "Mean waiting room capacity used: ",
                                                  "Admin utilization: ", "Examination utilization: ", "Vaccination utilization: "};

            for(int i = 0; i < _simulation.ReplicationResults.ObservedValues.Length; ++i)
            {
                Console.WriteLine(outputTitle[i] + (_simulation.ReplicationResults.ObservedValues[i]/ _simulation.ReplicationResults.CurrentReplications));
            }

        }

        public bool RunRealTimeSimulation(BackgroundWorker simulationWorker)
        {
            _realTimeSimWorker = simulationWorker;
            if(SimulationStatus != EventSimulationCore.SimulationStatus.PAUSED)
            {
                _simulation.BeforeSimulation();
                _simulation.BeforeReplicationInit();
                _realTimeSimWorker.ReportProgress((int)UpdateDataType.SIMULATION_DATA);
                _realTimeSimWorker.ReportProgress((int)UpdateDataType.CLOCK_DATA, new ClockUpdateData(_simulation.CurrentTime));
            }
            //_simulation.DoReplication();
            if (_simulation.RunRealTimeSimulation() != EventSimulationCore.SimulationStatus.FINISHED)
            {
                if (PauseClicked)
                    SimulationStatus = EventSimulationCore.SimulationStatus.PAUSED;
                else
                    SimulationStatus = EventSimulationCore.SimulationStatus.CANCELED;
                return false;
            }

            return true;
        }

        public bool AfterEventUpdate()
        {
            _realTimeSimWorker.ReportProgress((int)UpdateDataType.SIMULATION_DATA);
            return true;
        }

        public void ClockUpdate(double currentTime)
        {
            //this._realTimeSimulation.SetClockValue($"{(int)currentTime}:{(int)((currentTime % 1) * 1000)}");
            //_realTimeSimulation.Clokc
            //_realTimeSimWorker.ReportProgress(0, 0);
            _realTimeSimWorker.ReportProgress((int)UpdateDataType.CLOCK_DATA, new ClockUpdateData(currentTime));
        }

        public void SetSimulationSpeed(int speedIndex)
        {
            _simulation.Speed = _speedList[speedIndex];
        }

        public void ResetRealTimeSimulation()
        {
            PauseClicked = false;
            _simulation.ResetSimulation();
            _realSimControl.UpdateValues();
            _realSimControl.SetClockValue("0");
        }

        public void CancelRealTimeSimulation()
        {
            SimulationStatus = EventSimulationCore.SimulationStatus.CANCELED;
        }

        public void InitializeSimulation()
        {
            _simulation.BeforeReplicationInit();
        }

        public void AfterRealTimeSimulationStopped()
        {
            SimulationStatus = EventSimulationCore.SimulationStatus.CANCELED;
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
    }
}
