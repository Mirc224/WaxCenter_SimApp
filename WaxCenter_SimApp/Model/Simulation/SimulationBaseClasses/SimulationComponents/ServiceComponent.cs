using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.RandomDistribution;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents
{
    public class ServiceComponent<E> : IComponent
        where E: SimEvent
    {
        public int MaxService { get; private set; } 
        public int CurrentlyUsed { get; private set; }
        public bool IsFree { get => MaxService != CurrentlyUsed; }
        public Queue<Agent> WaitingQueue { get; private set; } = new Queue<Agent>();
        public IDistribution Generator { get; private set; }
        public int QueueSize { get => WaitingQueue.Count; }
        public int AgentsEntered { get; private set; } = 0;
        public int AgentsLeaved { get; private set; } = 0;
        public EventSimulationCore Simulation { get; private set; }
        public ServiceComponent(EventSimulationCore simulation, IDistribution generator, int maxService = 1)
        {
            Simulation = simulation;
            MaxService = maxService;
            Generator = generator;
        }

        public void ServiceEnter(Agent agent)
        {
            ++AgentsEntered;
            if(IsFree)
            {
                PlanServiceEventStart(agent);
                StartService();
            }
            else
            {
                AddToQueue(agent);
            }
        }
        public bool StartService()
        {
            ++CurrentlyUsed;
            if (CurrentlyUsed > MaxService)
                throw new Exception("ServiceComponent: Used more services than maximal avaiable!");
            return true;
        }

        public bool EndService()
        {
            ++AgentsLeaved;
            --CurrentlyUsed;
            if(CurrentlyUsed < 0)
                throw new Exception("ServiceComponent: Released more services than maximal avaiable!");
            if(QueueSize !=0)
            {
                PlanServiceEventStart(WaitingQueue.Dequeue());
                StartService();
            }
            return true;
        }

        public void AddToQueue(Agent agent)
        {
            WaitingQueue.Enqueue(agent);
        }

        public Agent GetFirstFromQueue()
        {
            return WaitingQueue.Dequeue();
        }

        private void PlanServiceEventStart(Agent agent)
        {
            var serviceStartE = Activator.CreateInstance(typeof(E), Simulation) as E;
            serviceStartE.Agent = agent;
            serviceStartE.OccurrenceTime = Simulation.CurrentTime;
            Simulation.EventCalendar.Insert(serviceStartE.OccurrenceTime, serviceStartE);
        }
        public void Reset()
        {
            CurrentlyUsed = 0;
            WaitingQueue.Clear();
            AgentsLeaved = 0;
            AgentsEntered = 0;
        }

    }
}
