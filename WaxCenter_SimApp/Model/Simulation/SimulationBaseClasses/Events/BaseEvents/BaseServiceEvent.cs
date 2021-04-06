using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.AdditionalServiceComponents;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events.BaseEvents
{
    public abstract class BaseServiceEvent : SimEvent
    {
        /**
         * Abstraktna trieda, ktora je predkom pre udalosti suvisiace s komponentom simulacie Service. Obsahuje referenciu an obsluhujuci personal a komponent, s ktorym
         * je udalost spata.
         */
        protected ServiceComponent _service;
        protected ServiceStaff _staff;
    }
}
