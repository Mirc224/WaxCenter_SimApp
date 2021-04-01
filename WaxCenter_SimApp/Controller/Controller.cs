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

        private BackgroundWorker _replicationsWorker;
        private ReplicationControl _replicationSimControl;

        private ReplicationsSettings _replicationsSettings;
        //private ReplicationsResults _replicationsResults;

        private int[] _speedList = new int[] { 1, 2, 5, 10, 25, 50, 100, 1000 };
        //public GUIDataValuesVacCenter GUIData { get; private set; }
        public EventSimulationCore.SimulationStatus SimulationStatus { get => _simulation.Status; private set => _simulation.Status = value; }
        //private SimulationControl _realTimeSimulation;
        //public bool PauseClicked { get; set; } = false;

        public bool RealTimeCancellation { get => _realTimeSimWorker.CancellationPending; }

        public Controller(AppGUI appGUI, SimulationControl realTimeSim, ReplicationControl replicationSim, SimulationOptions simOptions)
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

            TimeSpan t = TimeSpan.FromSeconds(_simulation.StartTimeInSeconds);
            var startTime = t.ToString(@"hh\:mm\:ss");

            _realSimControl.SetClockValue(startTime);

            _realSimControl.UpdateValues();

            _replicationSimControl = replicationSim;
            _replicationSimControl.SetReplicationResults(_simulation.ReplicationResults);
            
            _replicationsSettings = new ReplicationsSettings();
            _replicationsSettings.NumberOfReplications = 1000;
        }

        public Controller(EventSimCoreVaccinationCenter simulation)
        {
            _simulation = simulation;
            _replicationsSettings = new ReplicationsSettings();
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
            _replicationsSettings.NumberOfReplications = 10000;
            _simulation.BeforeSimulation();
            for(int i = _simulation.ReplicationResults.CurrentReplications; i < _replicationsSettings.NumberOfReplications; ++i)
            {
                _simulation.BeforeReplication();
                _simulation.DoReplication();
                _simulation.AfterReplication();
                UpdateGUIAfterReplication();
            }
            //for(int i = )

            return true;
        }

        private void UpdateGUIAfterReplication()
        {
            /*string[] outputTitle = new string[] { "Mean admin QL: ", "Mean admin WT: ", "Mean examination QL: ", "Mean examination WT: ",
                                                  "Mean vaccination QL: ", "Mean vaccination WT: ", "Mean waiting room capacity used: ",
                                                  "Admin utilization: ", "Examination utilization: ", "Vaccination utilization: "};

            for(int i = 0; i < _simulation.ReplicationResults.ObservedValues.Length; ++i)
            {
                Console.WriteLine(outputTitle[i] + (_simulation.ReplicationResults.ObservedValues[i]/ _simulation.ReplicationResults.CurrentReplications));
            }*/
            _replicationSimControl.UpdateStatTables();
            /*foreach(var group in _simulation.ReplicationResults.ResultGroups)
            {
                foreach(var stat in group.GroupResults)
                {
                    for(int i = 0; i < stat.Values.Length; ++i)
                    {
                        Console.WriteLine(stat.Names[i] + ": " + (stat.Values[i]/_simulation.ReplicationResults.CurrentReplications));
                    }
                }
            }*/

        }

        public bool RunRealTimeSimulation(BackgroundWorker simulationWorker)
        {
            _realTimeSimWorker = simulationWorker;
            if(SimulationStatus != EventSimulationCore.SimulationStatus.PAUSED)
            {
                _simulation.BeforeSimulation();
                _simulation.BeforeReplication();
                _realTimeSimWorker.ReportProgress((int)UpdateDataType.SIMULATION_DATA);
                _realTimeSimWorker.ReportProgress((int)UpdateDataType.CLOCK_DATA, new ClockUpdateData(_simulation.ClockTimeInSeconds));
            }
            //_simulation.DoReplication();
            if (_simulation.RunRealTimeSimulation() != EventSimulationCore.SimulationStatus.FINISHED)
            {
                if (_realSimControl.PauseClicked)
                    SimulationStatus = EventSimulationCore.SimulationStatus.PAUSED;
                else
                {
                    _simulation.AfterReplication();
                    _realTimeSimWorker.ReportProgress((int)UpdateDataType.SIMULATION_DATA);
                    SimulationStatus = EventSimulationCore.SimulationStatus.CANCELED;
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
            _realTimeSimWorker.ReportProgress((int)UpdateDataType.SIMULATION_DATA);
            return true;
        }

        public void ClockUpdate()
        {
            _realTimeSimWorker.ReportProgress((int)UpdateDataType.CLOCK_DATA, new ClockUpdateData(_simulation.ClockTimeInSeconds));
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

        public void CancelRealTimeSimulation()
        {
            SimulationStatus = EventSimulationCore.SimulationStatus.CANCELED;
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
