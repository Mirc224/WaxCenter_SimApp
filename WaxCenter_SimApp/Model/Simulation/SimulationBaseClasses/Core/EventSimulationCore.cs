using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WaxCenter_SimApp.DataStructures;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events.BaseEvents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.SimulationComponentsWrapper;

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
        public bool ContinueAfterMaxTime { get; set; } = false;
        public SimulationComponentsManager SimulationComponentsManager { get; protected set; } = new SimulationComponentsManager();
        public int Seed { 
            get => _lastUsedSeed; 
            set 
            { 
                _lastUsedSeed = value;
                SetSeed(_lastUsedSeed);
            } 
        }
        public bool AutoSeed 
        { 
            get => _autoSeed;
            set
            {
                _autoSeed = value;
                if (value)
                    SetSeed();
                else
                    SetSeed(_lastUsedSeed);
            } 
        }
        private int _lastUsedSeed = 224;
        private bool _autoSeed = false;
        
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
            if (_autoSeed)
                SetSeed();
            else
                SetSeed(_lastUsedSeed);
        }
        public abstract void BeforeReplicationInit();
        public void ResetSimulation()
        {
            ResetComponents();
            ResetStatistics();
            ResetGenerators();
        }

        protected virtual void ResetComponents()
        {
            SimulationComponentsManager.ResetAllComponents();
        }
        protected virtual void ResetStatistics()
        {
            if (SimulationComponentsManager.Statistics != null)
                for (int i = 0; i < SimulationComponentsManager.Statistics.Length; ++i)
                    SimulationComponentsManager.Statistics[i].Reset();
        }
        protected void SetSeed()
        {
            SeedGenerator = new Random();
            SeedIt();
        }
        protected void SetSeed(int seed)
        {
            _lastUsedSeed = seed;
            SeedGenerator = new Random(seed);
            SeedIt();
        }
        protected virtual void SeedIt()
        {
            SimulationComponentsManager.SetComponetsSeed(SeedGenerator);
        }
        public virtual void DoReplication()
        {
            SimEvent currentEvent = null;
            if (EventCalendar.Count == 0)
            {
                PlanFirstEvent();
                /*                currentEvent = new CustomerArrivalEvent(this);
                                currentEvent.OccurrenceTime = CustomerSource.Generator.Sample();
                                EventCalendar.Insert(currentEvent.OccurrenceTime, currentEvent);*/
            }
            CurrentTime = 0;
            while (EventCalendar.Count != 0 && (CurrentTime <= MaxTime || ContinueAfterMaxTime))
            {
                currentEvent = EventCalendar.GetMin();
                CurrentTime = currentEvent.OccurrenceTime;
                currentEvent.Execute();
            }
        }
        public void ResetGenerators()
        {
            if (AutoSeed)
                SetSeed();
            else
                SetSeed(Seed);
        }

        protected abstract void PlanFirstEvent();

        public virtual SimulationStatus RunRealTimeSimulation()
        {
            SimEvent currentEvent = null;
            if (EventCalendar.Count == 0 && (Status == SimulationStatus.CANCELED || Status == SimulationStatus.FINISHED))
            {
                PlanFirstEvent();
            }
            Status = SimulationStatus.RUNNING;
            double nextEventTime;
            while (EventCalendar.Count != 0 && (CurrentTime <= MaxTime || ContinueAfterMaxTime))
            {

                nextEventTime = EventCalendar.Peek;
                while (CurrentTime < nextEventTime)
                {
                    CurrentTime += RunClock(nextEventTime - CurrentTime);
                    if (nextEventTime < CurrentTime)
                        CurrentTime = nextEventTime;
                    Controller.ClockUpdate(CurrentTime);
                    if (CurrentTime > MaxTime && !ContinueAfterMaxTime)
                    {
                        Status = SimulationStatus.FINISHED;
                        return Status;
                    }
                    if (Controller.RealTimeCancellation)
                    {
                        Status = SimulationStatus.CANCELED;
                        return Status;
                    }
                }
                CurrentTime = nextEventTime;
                currentEvent = EventCalendar.GetMin();
                CurrentTime = currentEvent.OccurrenceTime;
                currentEvent.Execute();
                Controller.AfterEventUpdate();
            }
            Status = SimulationStatus.FINISHED;
            return Status;
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
