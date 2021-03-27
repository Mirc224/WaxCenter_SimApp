using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events.BaseEvents
{
    public abstract class BaseServiceEvent : SimEvent
    {
        protected ServiceComponent _service;
    }
}
