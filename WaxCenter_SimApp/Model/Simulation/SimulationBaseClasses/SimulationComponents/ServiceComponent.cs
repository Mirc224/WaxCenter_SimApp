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
        /**
         * Trieda reprezentuje simulacny komponent service. Obsahuje udaje o aktualnom stave komponentu a taktiez sa stara o planovanie eventov zaciatku obsluhy. 
         * Obsahuje referenciu na funkciu, ktora ma byt vykonana v okamihu, ked sa Agent dostane na rad a zancne by obsluhovany.
         */
        public ResourcePool ResourcePool { get; private set; }
        public Queue<Agent> WaitingQueue { get; private set; } = new Queue<Agent>();
        public int QueueSize { get => WaitingQueue.Count; }
        public Func<ServiceComponent, Agent, int> OnEnterDelay { get; set; } = null;
        public ServiceStateData ServiceStateData { get=> (ServiceStateData)StateData; }
        public int MaxStaff 
        {
            get => MaxService;  
            set
            {
                MaxService = value;
                ResourcePool.SetMaxStaff(value);
            }
        }
        public ServiceComponent(EventSimulationCore simulation, IDistribution generator, int maxService = 1): 
            base(simulation, generator, maxService)
        {
            ResourcePool = new ResourcePool(this, maxService);
            StateData = new ServiceStateData(this);
        }

        override public void Enter(Agent agent)
        {
            ++AgentsEntered;
            // Po vstupe agenta sa navysi counter agentov, ktori vstupili do komponentu. Vykona sa test, ci je obsluha volna a v pripade ak je volna, naplanuje sa zaciatok obsluhy pre daneho agenta.
            // V pripade, ze by obsluha nebola volna, je agent zaradeny do frontu.
            if(IsFree)
            {
                PlanServiceEventStart(agent);
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
            // Metoda sa vykona pri zacati obsluhy agenta.
            ++CurrentlyUsed;
            if (OnEnterDelay != null)
                OnEnterDelay(this, agent);

            return true;
        }

        override public bool EndService(Agent agent)
        {
            // Metoda sa vykona pri ukonceni obsluhy agenta. Aktualizuje sa stav komponentu a uvolni sa kapacita u obsluhujucich prvkov.
            // On exit
            ++AgentsLeaved;
            --CurrentlyUsed;
            --_capacityUsed;
            if(_capacityUsed < 0)
                throw new Exception("ServiceComponent: Released more services than maximal avaiable!");
            if(QueueSize !=0)
            {
                PlanServiceEventStart(WaitingQueue.Dequeue());
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
            // Naplanuje zaciatok obsluhy pre agenta zadaneho ako argument metody.
            ++_capacityUsed;
            // On enter Service
            if (CurrentlyUsed > MaxService)
                throw new Exception("ServiceComponent: Used more services than maximal avaiable!");

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
