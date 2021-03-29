using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.RandomDistribution;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events.BaseEvents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents;
using WaxCenter_SimApp.Model.Statistics;

namespace WaxCenter_SimApp.Model.Simulation.TrafikaSimulation
{       
    public class EventSimCoreNewsPapers : EventSimulationCore
    {
        /*
         * Tu patria vsetko dalsie co je v simulacii. Generatory generator nasad, statisticke vyhodnotenia, atribut stavu, ci je obsadene alebo neobsadene.
         */
        public DiscreteStatistic NewsPaperWaitingTime { get; private set; } = new DiscreteStatistic();
        public ContinuousStatistic NewsPaperQLength { get; private set; } = new ContinuousStatistic();
        public ContinuousStatistic DelaySize { get; private set; } = new ContinuousStatistic();
        public SourceComponent<Customer> CustomerSource { get; private set; }
        public ServiceComponent NewsPaperService { get; private set; }
        public DelayComponent ReadDelay { get; private set; }
        public SinkComponent CustomerSink { get; private set; }
        public double StartTime { get; set; } = 0;

        public EventSimCoreNewsPapers(Controller.Controller controller, double maxTime = 0)
            : base(controller, maxTime)
        {
            CustomerSource = new SourceComponent<Customer>(this, new ExponentialDistribution(5));
            NewsPaperService = new ServiceComponent(this, new ExponentialDistribution(4), 1);
            ReadDelay = new DelayComponent(this, new DiscreteDistribution(new double[] { 0.95, 0.05 }, new double[] { 10, 30 }), int.MaxValue);
            CustomerSink = new SinkComponent(this);
            NewsPaperService.OnEnter = OnEnterService;
            NewsPaperService.OnEnterDelay = OnEnterDelay;
            ReadDelay.OnEnter = OnEnterReadDelay;
            ReadDelay.OnExit = OnExitReadDelay;
            CustomerSource.NextComponent = NewsPaperService;
            NewsPaperService.NextComponent = ReadDelay;
            ReadDelay.NextComponent = CustomerSink;
            SeedGenerator = new Random();
            SeedIt();
        }

        override
        public void DoReplication()
        {
            base.DoReplication();

            Console.WriteLine(NewsPaperWaitingTime.Mean);
            Console.WriteLine(NewsPaperQLength.Mean);
            Console.WriteLine(NewsPaperService.ResourcePool.Utilization);
            Console.WriteLine(DelaySize.Mean);
        }

        public int OnEnterService(DelayComponent self, Agent agent)
        {
            var tmpSelf = (ServiceComponent)self;
            var customer = (Customer)agent;
            customer.QueueArrivalTime = this.CurrentTime;
            NewsPaperQLength.Add(tmpSelf.QueueSize, CurrentTime);

            return 0;
        }

        public int OnEnterDelay(ServiceComponent self, Agent agent)
        {
            var customer = (Customer)agent;
            NewsPaperQLength.Add(self.QueueSize, CurrentTime);
            NewsPaperWaitingTime.Add(CurrentTime - customer.QueueArrivalTime);

            return 0;
        }

        public int OnEnterReadDelay(DelayComponent self, Agent agent)
        {
            DelaySize.Add(self.CurrentlyUsed, CurrentTime);
            return 0;
        }

        public int OnExitReadDelay(DelayComponent self, Agent agent)
        {
            DelaySize.Add(self.CurrentlyUsed, CurrentTime);
            return 0;
        }

        override public SimulationStatus RunRealTimeSimulation()
        {
            SimEvent currentEvent = null;
            if (EventCalendar.Count == 0 && (Status == SimulationStatus.CANCELED || Status == SimulationStatus.FINISHED))
            {
                CustomerSource.Start();
            }
            Status = SimulationStatus.RUNNING;
            double nextEventTime;
            while (EventCalendar.Count != 0 && CurrentTime <= MaxTime)
            {
                
                nextEventTime = EventCalendar.Peek;
                while(CurrentTime < nextEventTime)
                {
                    CurrentTime += RunClock(nextEventTime - CurrentTime);
                    if (nextEventTime < CurrentTime)
                        CurrentTime = nextEventTime;
                    Controller.ClockUpdate(CurrentTime);
                    if(CurrentTime > MaxTime)
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
        override
        public void BeforeReplicationInit()
        {
            MaxTime = 900000;
            Console.WriteLine("resetujem");
            CurrentTime = StartTime;
            EventCalendar.Reset();
            Customer.ResetGlobalID();
            ResetComponents();
            ResetStatistics();
        }

        override
        protected void ResetComponents()
        {
            CustomerSource.Reset();
            NewsPaperService.Reset();
            CustomerSink.Reset();
            ReadDelay.Reset();
        }

        override
        protected void ResetStatistics()
        {
            NewsPaperWaitingTime.Reset();
            NewsPaperQLength.Reset();
            DelaySize.Reset();
            //NewsPaperQLength.PreviousState = StartTime;
        }

        protected override void SeedIt()
        {
            CustomerSource.Generator.SetSeed(SeedGenerator.Next());
            NewsPaperService.Generator.SetSeed(SeedGenerator.Next());
            ReadDelay.Generator.SetSeed(SeedGenerator.Next());
        }

        protected override void PlanFirstEvent()
        {
            CustomerSource.Start();
        }
    }
}
