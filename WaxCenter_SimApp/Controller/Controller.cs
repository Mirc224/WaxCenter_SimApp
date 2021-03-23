using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.GUIComponents.Screens;
using WaxCenter_SimApp.Model.Simulation.GUIData;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;
using WaxCenter_SimApp.Model.Simulation.TrafikaSimulation;

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
        private EventSimCoreNewsPapers _simulation;
        private BackgroundWorker _realTimeSimWorker;
        private int[] _speedList = new int[] { 1, 2, 5, 10, 25, 50, 100, 1000 };
        public GUIDataValues GUIData { get; private set; }
        public EventSimulationCore.SimulationStatus SimulationStatus { get => _simulation.Status; private set => _simulation.Status = value; }
        //private SimulationControl _realTimeSimulation;
        public bool PauseClicked { get; set; } = false;

        public bool RealTimeCancellation { get => _realTimeSimWorker.CancellationPending; }

        public Controller(AppGUI appGUI, SimulationControl realTimeSim)
        {
            _applicationGUI = appGUI;
            _simulation = new EventSimCoreNewsPapers();
            _simulation.Controller = this;
            GUIData = new GUIDataValues(_simulation);
            realTimeSim.GUIData = GUIData;
            //_realTimeSimulation = realTimeSim;

        }

        public bool RunRealTimeSimulation(BackgroundWorker simulationWorker)
        {
            _realTimeSimWorker = simulationWorker;
            /*            _simulation.MaxTime = 80;
                        _simulation.DoReplication();*/
            if( _simulation.RunRealTimeSimulation() != EventSimulationCore.SimulationStatus.FINISHED)
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
        }

        public void CancelRealTimeSimulation()
        {
            SimulationStatus = EventSimulationCore.SimulationStatus.CANCELED;
        }

        public void InitializeSimulation()
        {
            _simulation.ResetSimulation();
        }

        public void AfterRealTimeSimulationStopped()
        {
            SimulationStatus = EventSimulationCore.SimulationStatus.CANCELED;
        }
    }
}
