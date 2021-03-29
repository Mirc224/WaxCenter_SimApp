using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.RandomDistribution;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.ComponentValuesClasses;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents
{
    public abstract class BaseSourceComponent : BaseComponent
    {
        public IDistribution Generator { get; protected set; }
        public int NumberOfGenerated { get; protected set; } = 0;
        public SourceStateData StateData { get; protected set; }
        public bool GenerateAfterMaxTime { get; set; } = false;
    }
}
