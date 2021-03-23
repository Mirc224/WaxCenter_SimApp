using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.RandomDistribution;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents;
using WaxCenter_SimApp.Model.Simulation.TrafikaSimulation.Events;
using WaxCenter_SimApp.Model.Statistics;

namespace WaxCenter_SimApp.Model.Simulation.TrafikaSimulation
{       
    public class EventSimCoreNewsPapers : EventSimulationCore
    {
        /*
         * Tu patria vsetko dalsie co je v simulacii. Generatory generator nasad, statisticke vyhodnotenia, atribut stavu, ci je obsadene alebo neobsadene.
         */
        //public Queue<Customer> WaitingQueue { get; private set; } = new Queue<Customer>();
        //public ExponentialDistribution CustomerArrivalGenerator { get; private set; } = new ExponentialDistribution(5);
        //public ExponentialDistribution ServiceTimeGenerator { get; private set; } = new ExponentialDistribution(4);
        public ServiceComponent<ServiceStartEvent> NewsPaperService { get; private set; }
        public DiscreteStatistic NewsPaperWaitingTime { get; private set; } = new DiscreteStatistic();
        public ContinousStatistic NewsPaperQLength { get; private set; } = new ContinousStatistic();
        public SourceComponent<Customer> CustomerSource { get; private set; }
        public SinkComponent CustomerSink { get; private set; } = new SinkComponent();
        public int Speed { get; set; } = 1;
        public double StartTime { get; set; } = 0;
        public Random SeedGenerator { get; private set; }

        public EventSimCoreNewsPapers()
        {
            NewsPaperService = new ServiceComponent<ServiceStartEvent>(this, new ExponentialDistribution(4), 1);
            CustomerSource = new SourceComponent<Customer>(new ExponentialDistribution(5));
            SeedGenerator = new Random();
        }

        override
        public void DoReplication()
        {
            SimEvent currentEvent = null;
            if(EventCalendar.Count == 0)
            {
                currentEvent = new CustomerArrivalEvent(this);
                currentEvent.OccurrenceTime = CustomerSource.Generator.Sample();
                EventCalendar.Insert(currentEvent.OccurrenceTime, currentEvent);
            }
            CurrentTime = 0;
            while (EventCalendar.Count != 0 && CurrentTime <= MaxTime)
            {
                currentEvent = EventCalendar.GetMin();
                CurrentTime = currentEvent.OccurrenceTime;
                currentEvent.Execute();
            }
            Console.WriteLine(NewsPaperWaitingTime.Mean);
            Console.WriteLine(NewsPaperQLength.Mean);
        }

        public SimulationStatus RunRealTimeSimulation()
        {
            SimEvent currentEvent = null;
            if (EventCalendar.Count == 0 && (Status == SimulationStatus.CANCELED || Status == SimulationStatus.FINISHED))
            {
                currentEvent = new CustomerArrivalEvent(this);
                currentEvent.OccurrenceTime = CustomerSource.Generator.Sample();
                EventCalendar.Insert(currentEvent.OccurrenceTime, currentEvent);
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
            int time = timeDifference - 1 >= 0 ? 1000 / actualSpeed : (int)((timeDifference * 1000)/actualSpeed);
            Thread.Sleep(time);
            if (timeDifference < 1)
                return timeDifference;
            return 1;
        }

        public void ResetSimulation()
        {
            MaxTime = 900000;
            Console.WriteLine("resetujem");
            CurrentTime = StartTime;
            EventCalendar.Reset();
            Customer.ResetGlobalID();
            ResetComponents();
            ResetStatistics();
        }

        private void ResetComponents()
        {
            CustomerSource.Reset();
            NewsPaperService.Reset();
            CustomerSink.Reset();
            CustomerSource.Generator.SetSeed(SeedGenerator.Next());
            NewsPaperService.Generator.SetSeed(SeedGenerator.Next());
        }

        private void ResetStatistics()
        {
            NewsPaperWaitingTime.Reset();
            NewsPaperQLength.Reset();
            NewsPaperQLength.PreviousState = StartTime;
        }
    }
}
