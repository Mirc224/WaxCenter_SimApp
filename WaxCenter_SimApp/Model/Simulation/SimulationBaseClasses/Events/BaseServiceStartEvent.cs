using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events
{
    class BaseServiceStartEvent : SimEvent
    {
        private ServiceComponent _service;
        public BaseServiceStartEvent(ServiceComponent service)
        {
            _service = service;
        }
        public override void Execute()
        {
            _service.StartService(Agent);
            BaseServiceEndEvent endService = new BaseServiceEndEvent(_service);
            endService.Agent = Agent;
            endService.OccurrenceTime = _service.Simulation.CurrentTime + _service.Generator.Sample();
            _service.Simulation.EventCalendar.Insert(endService.OccurrenceTime, endService);
        }
    }
}
