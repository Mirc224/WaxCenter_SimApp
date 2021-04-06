using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events.BaseEvents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events
{
    class DelayEndEvent : BaseDelayEvent
    {
        /**
         * Trieda predsavuje koncovu udalost na komponente urcitom komponente delay.
         */
        public DelayEndEvent(DelayComponent delayComponent)
        {
            _delayComponent = delayComponent;
        }
        public override void Execute()
        {
            // Pri vykonani je nad prislusnym komponentom zvolana metoda EndService, do ktorej je poslany agent, ktoreho sa udalost tyka.
            _delayComponent.EndService(Agent);
        }
    }
}
