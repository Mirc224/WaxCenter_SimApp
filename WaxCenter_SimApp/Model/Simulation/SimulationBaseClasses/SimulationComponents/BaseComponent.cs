using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents
{
    public abstract class BaseComponent
    {
        public EventSimulationCore Simulation { get; protected set; }
        public BaseComponent NextComponent { get; set; } = null;
        public abstract void Enter(Agent agent);
        public abstract void Reset();
    }
}
