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
        public DelayStartEvent(DelayComponent delayComponent)
        {
            _delayComponent = delayComponent;
        }
        public override void Execute()
        {
            _delayComponent.StartService(Agent);
            var endService = new DelayEndEvent(_delayComponent);
            endService.Agent = Agent;
            endService.OccurrenceTime = _delayComponent.Simulation.CurrentTime + _delayComponent.Generator.Sample();
            _delayComponent.Simulation.EventCalendar.Insert(endService.OccurrenceTime, endService);
        }
    }
}
