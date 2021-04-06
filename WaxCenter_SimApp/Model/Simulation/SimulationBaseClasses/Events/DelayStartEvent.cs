using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events.BaseEvents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events
{
    class DelayStartEvent : BaseDelayEvent
    {
        /**
         * Trieda predstavujuca zaciatok udalosti na prislusnom komponente delay.
         */
        public DelayStartEvent(DelayComponent delayComponent)
        {
            _delayComponent = delayComponent;
        }
        public override void Execute()
        {
            // V ramci vykonavania udalosti je agent poslany do service komponentu a je naplanovany koniec obsluhy zakaznika. 
            _delayComponent.StartService(Agent);
            var endService = new DelayEndEvent(_delayComponent);
            endService.Agent = Agent;
            double durration = _delayComponent.Generator.Sample();
            endService.OccurrenceTime = _delayComponent.Simulation.CurrentTime + durration;
            _delayComponent.Simulation.EventCalendar.Insert(endService.OccurrenceTime, endService);
        }
    }
}
