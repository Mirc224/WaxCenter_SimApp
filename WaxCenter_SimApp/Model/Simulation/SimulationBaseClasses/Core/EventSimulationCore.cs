using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.DataStructures;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events;


namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core
{
    public struct ClockUpdateData
    {
        public string CurrentTime;
        public ClockUpdateData(double currTime)
        {
            CurrentTime = String.Format("{0:0.00}", currTime);
        }
    }
    public abstract class EventSimulationCore : ISimulation
    {
        public enum SimulationStatus
        {
            FINISHED,
            CANCELED,
            PAUSED,
            RUNNING,
            INTERRUPTED
        }
        public PairingHeap<double, SimEvent> EventCalendar { get; protected set; } = new PairingHeap<double, SimEvent>();

        public double CurrentTime { get; protected set; } = 0;
        public double MaxTime { get; set; } = 0;
        public Controller.Controller Controller { get; set; }
        public SimulationStatus Status { get; set; } = SimulationStatus.FINISHED;
        public void AferReplication()
        {
            throw new NotImplementedException();
        }

        public void AfterSimulation()
        {
            throw new NotImplementedException();
        }

        public void BeforeReplication()
        {
            throw new NotImplementedException();
        }

        public void BeforeSimulation()
        {
            throw new NotImplementedException();
        }

        public virtual void DoReplication()
        {
            SimEvent currentEvent = null;
            CurrentTime = 0;
            while(EventCalendar.Count != 0 && CurrentTime <= MaxTime)
            {
                currentEvent = EventCalendar.GetMin();
                CurrentTime = currentEvent.OccurrenceTime;
                currentEvent.Execute();
            }
        }
    }
}
