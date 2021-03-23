using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.RandomDistribution;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents
{
    public class SourceComponent<T> : IComponent
        where T: Agent
    {
        public IDistribution Generator { get; private set; }
        public int NumberOfGenerated { get; set; } = 0;
        public EventSimulationCore Simulation { get; private set; }

        public SourceComponent(IDistribution distributionGenerator)
        {
            Generator = distributionGenerator;
        }

        public T GetAgent()
        {
            T newAgent = Activator.CreateInstance(typeof(T)) as T;
            ++NumberOfGenerated;
            return newAgent;
        }

        public void Reset()
        {
            NumberOfGenerated = 0;
            Agent.GlobalAgentID = 0;
        }
    }
}
