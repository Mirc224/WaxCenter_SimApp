using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents
{
    public class SinkComponent : IComponent
    {
        public int AgentsSinked { get; private set; } = 0;

        public void Sink()
        {
            ++AgentsSinked;
        }
        public void Reset()
        {
            AgentsSinked = 0;
        }
    }
}
