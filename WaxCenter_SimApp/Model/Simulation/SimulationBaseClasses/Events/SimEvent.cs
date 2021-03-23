using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events
{
    public abstract class SimEvent
    {
        public double OccurrenceTime { get; set; }
        public EventSimulationCore Simulation { get; protected set; }
        public Agent Agent { get; set; }
        public abstract void Execute();
    }
}
