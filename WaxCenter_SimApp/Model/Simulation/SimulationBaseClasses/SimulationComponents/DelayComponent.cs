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
    public class DelayComponent : BaseComponent
    {
        public int AgentsEntered { get; protected set; } = 0;
        public int AgentsLeaved { get; protected set; } = 0;
        public int MaxService { get; protected set; }
        public int CurrentlyUsed { get; protected set; }
        public bool IsFree { get => MaxService != CurrentlyUsed; }
        public IDistribution Generator { get; protected set; }

        public Func<DelayComponent, Agent, int> OnEnter { get; set; } = null;

        public DelayComponent(EventSimulationCore simulation, IDistribution generator, int maxService = 1)
        {
            Simulation = simulation;
            MaxService = maxService;
            Generator = generator;
        }
        public virtual bool StartService(Agent agent)
        {
            ++CurrentlyUsed;
            return true;
        }

        public virtual bool EndService(Agent agent)
        {
            // On exit
            ++AgentsLeaved;
            --CurrentlyUsed;
            NextComponent.Enter(agent);
            return true;
        }
        public override void Enter(Agent agent)
        {
            ++AgentsEntered;
            PlanServiceEventStart(agent);
        }

        protected virtual void PlanServiceEventStart(Agent agent)
        {
            ++CurrentlyUsed;
            // On enter Service
            if (CurrentlyUsed > MaxService)
                throw new Exception("ServiceComponent: Used more services than maximal avaiable!");

            //var serviceStartE = Activator.CreateInstance(typeof(E), Simulation) as E;
            var serviceStartE = new DelayStartEvent(this);
            serviceStartE.Agent = agent;
            serviceStartE.OccurrenceTime = Simulation.CurrentTime;
            Simulation.EventCalendar.Insert(serviceStartE.OccurrenceTime, serviceStartE);
        }

        public override void Reset()
        {
            CurrentlyUsed = 0;
            AgentsEntered = 0;
            AgentsLeaved = 0;
        }
    }
}
