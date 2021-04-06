using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events.BaseEvents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.AdditionalServiceComponents;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events
{
    public class ServiceEndEvent : BaseServiceEvent
    {
        /**
         * Trieda predstavuje koncovu udalost na komponente service.
         */
        public ServiceEndEvent(ServiceComponent service, ServiceStaff staff)
        {
            _staff = staff;
            _service = service;
        }
        public override void Execute()
        {
            // V ramci jej vykonavania je uvolneny presonal, ktory obsluhu vykonaval a agent je zaslany do metody EndService, kde su vykonane dalsie procesy a je posunuty do dalsieho komponentu.
            _staff.ReturnToResourcePool();
            _service.EndService(Agent);
        }
    }
}
