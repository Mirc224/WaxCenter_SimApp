using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.ComponentValuesClasses;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents
{
    public class SinkComponent : BaseComponent
    {
        public int AgentsSinked { get; private set; } = 0;
        public SinkStateData StateData { get; private set; }

        public SinkComponent(EventSimulationCore simulation)
        {
            Simulation = simulation;
            StateData = new SinkStateData(this);
        }

        public void Sink(Agent agent)
        {
            ++AgentsSinked;
        }
        
        override public void Reset()
        {
            AgentsSinked = 0;
        }

        public override void Enter(Agent agent)
        {
            // On enter
            Sink(agent);
        }
    }
}
