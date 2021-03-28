using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.ComponentValuesClasses
{
    public class SourceStateData<T>
        where T : Agents.Agent
    {
        public int SourceOutput { get => _source.NumberOfGenerated; }
        private SourceComponent<T> _source;
        public SourceStateData(SourceComponent<T> source)
        {
            _source = source;
        }

    }
}
