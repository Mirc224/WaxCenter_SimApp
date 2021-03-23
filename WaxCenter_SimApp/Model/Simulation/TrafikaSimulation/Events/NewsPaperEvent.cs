using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events;

namespace WaxCenter_SimApp.Model.Simulation.TrafikaSimulation.Events
{
    public abstract class NewsPaperEvent : SimEvent
    {
        public NewsPaperEvent(EventSimulationCore core)
        {
            Simulation = core;
        }

    }
}
