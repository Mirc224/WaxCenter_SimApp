using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events.BaseEvents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events
{
    public class ServiceStartEvent : BaseServiceEvent
    {
        /**
         * Trieda reprezentuje udalost zaciatku obsluhy na komponente service.
         */
        public ServiceStartEvent(ServiceComponent service)
        {
            _service = service;
        }
        public override void Execute()
        {
            // V ramci vykonavania udalosti je prislusny agent poslay do metody start service a resourcepoolu prisluchajucemu ku komponentu service je vyziadany pracovnik, ktory sa bude starat o obsluhu. 
            _service.StartService(Agent);
            _staff = _service.ResourcePool.GetFreeStaff();
            if (_staff == null)
                throw new Exception("ServiceStartEvnet: returned null staff!");

            // Nasledne je naplanovana udalost konca obsluhy na komponente service.
            var endService = new ServiceEndEvent(_service, _staff);
            endService.Agent = Agent;
            double durationTime = _service.Generator.Sample();
            _staff.CurrentServiceDuration = durationTime;
            endService.OccurrenceTime = _service.Simulation.CurrentTime + durationTime;
            // Naplanovana udalost konca je vlozena do kalendara udalosti simulacie.
            _service.Simulation.EventCalendar.Insert(endService.OccurrenceTime, endService);
        }
    }
}
