using System;
using WaxCenter_SimApp.Model.RandomDistribution;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.ComponentValuesClasses;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents
{
    public class DelayComponent : BaseComponent
    {
        /**
         * Simulacny komponent delay. Obsahuje v sebe informacie o pocte agentov, ktori do komponentu vstupili, vystupili alebo sa v nom v sucasnosti nachadzaju. Taktiez obsahuje 
         * referencie na funkcie, ktore sa maju vykonat pri vstupe a vystupe z komponentu.
         */
        public int AgentsEntered { get; protected set; } = 0;
        public int AgentsLeaved { get; protected set; } = 0;
        public int MaxService { get; protected set; }
        public int CurrentlyUsed { get; protected set; }
        public bool IsFree { get => MaxService != _capacityUsed; }
        public IDistribution Generator { get; protected set; }
        // Atribut potrebny pre planovanie dalsich eventov zaciatku obsluhy. Je rozdielny od CurrentlyUsed, ktory obsluhovanych v case.
        protected int _capacityUsed = 0;
        public Func<DelayComponent, Agent, int> OnEnter { get; set; } = null;
        public Func<DelayComponent, Agent, int> OnExit { get; set; } = null;
        public virtual DelayStateData StateData { get; protected set; }
        public DelayComponent(EventSimulationCore simulation, IDistribution generator, int maxService = 1)
        {
            Simulation = simulation;
            MaxService = maxService;
            Generator = generator;
            StateData = new DelayStateData(this);
        }
        public virtual bool StartService(Agent agent)
        {
            ++CurrentlyUsed;
            if (OnEnter != null)
                OnEnter(this, agent);
            return true;
        }
        public virtual bool EndService(Agent agent)
        {
            // On exit
            // Navysi counter agentov, ktori opustili komponent. Znizi sa aktualny pocet obsluhovanych a uvolni sa miesto na dalsiu obsluhu.
            ++AgentsLeaved;
            --CurrentlyUsed;
            --_capacityUsed;
            if (OnExit != null)
                OnExit(this, agent);

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
            ++_capacityUsed;
            // On enter Service
            if (_capacityUsed > MaxService)
                throw new Exception("ServiceComponent: Used more services than maximal avaiable!");

            var serviceStartE = new DelayStartEvent(this);
            serviceStartE.Agent = agent;
            serviceStartE.OccurrenceTime = Simulation.CurrentTime;
            Simulation.EventCalendar.Insert(serviceStartE.OccurrenceTime, serviceStartE);
        }

        public override void Reset()
        {
            _capacityUsed = 0;
            CurrentlyUsed = 0;
            AgentsEntered = 0;
            AgentsLeaved = 0;
        }
    }
}
