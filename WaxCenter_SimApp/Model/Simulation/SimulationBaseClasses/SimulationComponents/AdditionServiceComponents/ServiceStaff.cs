using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.AdditionalServiceComponents
{
    public class ServiceStaff
    {
        public double TimeOccupied { get; protected set; } = 0;
        public double Utilization { get => _service.Simulation.CurrentTime == 0 ? 0 : TimeOccupied / _service.Simulation.CurrentTime; }
        private ServiceComponent _service;

        public ServiceStaff(ServiceComponent service)
        {
            _service = service;
        }

        public void Reset()
        {
            TimeOccupied = 0;
        }
    }
}
