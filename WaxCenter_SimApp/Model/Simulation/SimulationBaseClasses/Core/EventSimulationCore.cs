using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WaxCenter_SimApp.DataStructures;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events.BaseEvents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Settings;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.SimulationComponentsWrapper;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core
{
    public enum SimulationStatus
    {
        FINISHED,
        CANCELED,
        PAUSED,
        RUNNING,
        INTERRUPTED
    }
    public struct ClockUpdateData
    {
        public string CurrentTime;
        public ClockUpdateData(double currTime)
        {
            TimeSpan t = TimeSpan.FromSeconds(currTime);
            CurrentTime = t.ToString(@"hh\:mm\:ss");
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

        public double StartTimeInSeconds { get; set; } = 0; 
        public SimulationStatus Status { get; set; } = SimulationStatus.FINISHED;
        public PairingHeap<double, SimEvent> EventCalendar { get; protected set; } = new PairingHeap<double, SimEvent>();
        public ReplicationsResults ReplicationResults { get; protected set; }
        public Controller.Controller Controller { get; set; }
        public Random SeedGenerator { get; protected set; }
        public double CurrentTime { get; protected set; } = 0;
        public SimulationComponentsManager SimulationComponentsManager { get; protected set; } = new SimulationComponentsManager();
        public BaseEventSimulationSettings SimulationSettings { get; protected set; } = new BaseEventSimulationSettings();
        public int Speed { get => SimulationSettings.Speed; set => SimulationSettings.Speed = value; }
        public double MaxTime { get => SimulationSettings.MaxTime *(int)SimulationSettings.Units ; set => SimulationSettings.MaxTime = value; }
        private double _realMaxTimeInSec { get => SimulationSettings.MaxTime; }
        public bool ContinueAfterMaxTime { get=> SimulationSettings.ContinueAfterMaxTime; set => SimulationSettings.ContinueAfterMaxTime = value; }
        public double ClockTimeInSeconds { get => CurrentTime + StartTimeInSeconds; }

        public int Seed { 
            get => SimulationSettings.LastUsedSeed; 
            set 
            {
                SimulationSettings.LastUsedSeed = value;
                SetSeed(SimulationSettings.LastUsedSeed);
            } 
        }
        public bool AutoSeed 
        { 
            get => SimulationSettings.AutoSeed;
            set
            {
                SimulationSettings.AutoSeed = value;
                if (value)
                    SetSeed();
                else
                    SetSeed(SimulationSettings.LastUsedSeed);
            } 
        }
        
        public EventSimulationCore(Controller.Controller controller, double maxTime = 0)
        {
            Controller = controller;
            MaxTime = maxTime;
        }
        public void AfterReplication()
        {
            UpdateReplicationResults();
        }

        public void AfterSimulation()
        {
            throw new NotImplementedException();
        }

        public virtual void BeforeReplication()
        {
            ResetSimulation();
        }

        public void BeforeSimulation()
        {
            if (SimulationSettings.AutoSeed)
                SetSeed();
            else
                SetSeed(SimulationSettings.LastUsedSeed);
            if (ReplicationResults != null)
                ReplicationResults.Reset();
        }
        protected void UpdateReplicationResults()
        {
            ++ReplicationResults.CurrentReplications;
            if(ContinueAfterMaxTime)
                ReplicationResults.OverTime += CurrentTime - _realMaxTimeInSec;

            ReplicationResults.AfterReplicationUpdate();
        }

        //public abstract void BeforeReplicationInit();
        public void ResetSimulation()
        {
            Status = SimulationStatus.FINISHED;
            CurrentTime = 0;
            EventCalendar.Reset();
            ResetComponents();
            ResetStatistics();
        }

        protected void ResetSeeds()
        {
            if (AutoSeed)
                SeedGenerator = new Random();
            else
                SeedGenerator = new Random(Seed);
            SeedIt();
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
            SimulationSettings.LastUsedSeed = seed;
            SeedGenerator = new Random(seed);
            SeedIt();
        }
        protected virtual void SeedIt()
        {
            SimulationComponentsManager.SetComponetsSeed(SeedGenerator);
        }

        protected abstract void FinishContinuousStatistics();
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
            while (EventCalendar.Count != 0 && (CurrentTime <= _realMaxTimeInSec || ContinueAfterMaxTime))
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
            while (EventCalendar.Count != 0 && (CurrentTime <= _realMaxTimeInSec || ContinueAfterMaxTime))
            {

                nextEventTime = EventCalendar.Peek;
                while (CurrentTime < nextEventTime)
                {
                    CurrentTime += RunClock(nextEventTime - CurrentTime);
                    if (nextEventTime < CurrentTime)
                        CurrentTime = nextEventTime;

                    Controller.ClockUpdate();
                    if (CurrentTime > _realMaxTimeInSec && !ContinueAfterMaxTime)
                    {
                        Console.WriteLine(EventCalendar.Count);
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
            Console.WriteLine(EventCalendar.Count);
            Status = SimulationStatus.FINISHED;
            return Status;
        }

        public double RunClock(double timeDifference)
        {
            /*int actualSpeed = Speed;
            double tmpTimeDifference = timeDifference / ((double)SimulationSettings.Units);
            int time = tmpTimeDifference - 1 >= 0 ? 1000 / actualSpeed : (int)((tmpTimeDifference * 1000) / actualSpeed);
            Thread.Sleep(time);
            if (tmpTimeDifference < 1)
                return timeDifference;
            return 1 * ((double)SimulationSettings.Units);*/
            int actualSpeed = Speed;
            if(Speed > 1000)
            {
                if (Speed == 500000000)
                    return 500000000;
                Thread.Sleep(1);
                return actualSpeed / 10;
            }
            int time = timeDifference - 1 >= 0 ? 1000 / actualSpeed : (int)((timeDifference * 1000) / actualSpeed);
            Thread.Sleep(time);
            if (timeDifference < 1)
                return timeDifference;
            return 1;
        }
    }
}
