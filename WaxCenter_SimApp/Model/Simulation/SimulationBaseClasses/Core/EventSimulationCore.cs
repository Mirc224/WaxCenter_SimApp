using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WaxCenter_SimApp.DataStructures;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events.BaseEvents;


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
        public enum TimeUnits
        {
            SECONDS = 1,
            MINUTES = 60,
            HOURS = 3600
        }
        public enum SimulationStatus
        {
            FINISHED,
            CANCELED,
            PAUSED,
            RUNNING,
            INTERRUPTED
        }
        public PairingHeap<double, SimEvent> EventCalendar { get; protected set; } = new PairingHeap<double, SimEvent>();
        public int Speed { get; set; } = 1;
        public Random SeedGenerator { get; protected set; }
        public double CurrentTime { get; protected set; } = 0;
        public double MaxTime { get; set; } = 0;
        public Controller.Controller Controller { get; set; }
        public SimulationStatus Status { get; set; } = SimulationStatus.FINISHED;
        protected int _lastUsedSeed = 224;
        public bool AutoSeed { get; protected set; } = false;
        
        public EventSimulationCore(Controller.Controller controller, double maxTime = 0)
        {
            Controller = controller;
            MaxTime = maxTime;
        }
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
        public abstract void BeforeReplicationInit();
        public void ResetSimulation()
        {
            ResetComponents();
            ResetStatistics();
            ResetGenerators();
        }

        protected virtual void ResetComponents(){}
        protected virtual void ResetStatistics(){}
        public void SetSeed()
        {
            SeedGenerator = new Random();
            SeedIt();
        }
        public void SetSeed(int seed)
        {
            _lastUsedSeed = seed;
            SeedGenerator = new Random(_lastUsedSeed);
            SeedIt();
        }
        protected abstract void SeedIt();
        public abstract void DoReplication();
        public void ResetGenerators()
        {
            if (AutoSeed)
                SetSeed();
            else
                SetSeed(_lastUsedSeed);
        }
        public double RunClock(double timeDifference)
        {
            int actualSpeed = Speed;
            int time = timeDifference - 1 >= 0 ? 1000 / actualSpeed : (int)((timeDifference * 1000) / actualSpeed);
            Thread.Sleep(time);
            if (timeDifference < 1)
                return timeDifference;
            return 1;
        }
    }
}
