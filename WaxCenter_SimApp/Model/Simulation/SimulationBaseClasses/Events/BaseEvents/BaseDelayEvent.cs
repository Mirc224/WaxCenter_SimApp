using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events.BaseEvents
{
    public abstract class BaseDelayEvent : SimEvent
    {
        /*
         * Abstraktna trieda predka pre vsetky udalosti suvisiace s komponentom simulacie Delay. Obsahuje referenciu an delay komponent, s ktorym je udalost spata.
         */
        protected DelayComponent _delayComponent;
    }
}
