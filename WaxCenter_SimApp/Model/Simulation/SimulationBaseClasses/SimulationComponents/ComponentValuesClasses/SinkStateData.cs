using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.ComponentValuesClasses
{
    public class SinkStateData
    {
        public int SinkInput { get => _sink.AgentsSinked; }
        private SinkComponent _sink;
        public SinkStateData(SinkComponent sink)
        {
            _sink = sink;
        }
    }
}
