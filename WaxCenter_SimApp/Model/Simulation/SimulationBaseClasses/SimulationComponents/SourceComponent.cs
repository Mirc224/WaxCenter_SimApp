using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.RandomDistribution;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.ComponentValuesClasses;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents
{
    public class SourceComponent<T> : BaseSourceComponent
        where T: Agent
    {

        public SourceComponent(EventSimulationCore simulation, IDistribution distributionGenerator)
        {
            Simulation = simulation;
            Generator = distributionGenerator;
            StateData = new SourceStateData(this);
        }

        public T GetAgent()
        {
            T newAgent = Activator.CreateInstance(typeof(T)) as T;
            ++NumberOfGenerated;
            return newAgent;
        }

        override public void Reset()
        {
            NumberOfGenerated = 0;
            Agent.GlobalAgentID = 0;
        }

        public void Start()
        {
            BaseAgentArrivalEvent<T> arrivalEvent = new BaseAgentArrivalEvent<T>(this);
            arrivalEvent.OccurrenceTime = Simulation.CurrentTime + Generator.Sample();
            Simulation.EventCalendar.Insert(arrivalEvent.OccurrenceTime, arrivalEvent);

        }

        override public void Enter(Agent agent)
        {
            // On enter method
            NextComponent.Enter(agent);
            // On exit method
        }
    }
}
