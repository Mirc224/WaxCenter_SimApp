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
        public DelayEndEvent(DelayComponent delayComponent)
        {
            _delayComponent = delayComponent;
        }
        public override void Execute()
        {
            _delayComponent.EndService(Agent);
        }
    }
}
