using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.RandomDistribution;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.AdditionServiceComponents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.ComponentValuesClasses;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents
{
    public class ServiceComponent : DelayComponent
    {
        public ResourcePool ResourcePool { get; private set; }
        public Queue<Agent> WaitingQueue { get; private set; } = new Queue<Agent>();
        public int QueueSize { get => WaitingQueue.Count; }
        public Func<ServiceComponent, Agent, int> OnEnterDelay { get; set; } = null;
        public ServiceStateData ServiceStateData { get=> (ServiceStateData)StateData; }
        public ServiceComponent(EventSimulationCore simulation, IDistribution generator, int maxService = 1): 
            base(simulation, generator, maxService)
        {
            ResourcePool = new ResourcePool(this, maxService);
            StateData = new ServiceStateData(this);
        }

        override public void Enter(Agent agent)
        {
            ++AgentsEntered;

            if(IsFree)
            {
                PlanServiceEventStart(agent);
                //StartService();
            }
            else
            {
                AddToQueue(agent);
            }
            // On enter 
            if (OnEnter != null)
                OnEnter(this, agent);
        }
        override public bool StartService(Agent agent)
        {
            // On service start
            ++CurrentlyUsed;
            if (OnEnterDelay != null)
                OnEnterDelay(this, agent);

         /*   ++CurrentlyUsed;
            // On enter Service
            if (CurrentlyUsed > MaxService)
                throw new Exception("ServiceComponent: Used more services than maximal avaiable!");*/
            return true;
        }

        override public bool EndService(Agent agent)
        {
            // On exit
            ++AgentsLeaved;
            --CurrentlyUsed;
            --_capacityUsed;
            if(_capacityUsed < 0)
                throw new Exception("ServiceComponent: Released more services than maximal avaiable!");
            if(QueueSize !=0)
            {
                PlanServiceEventStart(WaitingQueue.Dequeue());
                //StartService();
            }
            NextComponent.Enter(agent);
            return true;
        }

        public void AddToQueue(Agent agent)
        {
            // On enter Queue
            WaitingQueue.Enqueue(agent);
        }

        public Agent GetFirstFromQueue()
        {
            return WaitingQueue.Dequeue();
        }

        override protected void PlanServiceEventStart(Agent agent)
        {
            ++_capacityUsed;
            // On enter Service
            if (CurrentlyUsed > MaxService)
                throw new Exception("ServiceComponent: Used more services than maximal avaiable!");

            //var serviceStartE = Activator.CreateInstance(typeof(E), Simulation) as E;
            var serviceStartE = new ServiceStartEvent(this);
            serviceStartE.Agent = agent;
            serviceStartE.OccurrenceTime = Simulation.CurrentTime;
            Simulation.EventCalendar.Insert(serviceStartE.OccurrenceTime, serviceStartE);
        }
        override public void Reset()
        {
            WaitingQueue.Clear();
            ResourcePool.Reset();
            base.Reset();
        }

    }
}
