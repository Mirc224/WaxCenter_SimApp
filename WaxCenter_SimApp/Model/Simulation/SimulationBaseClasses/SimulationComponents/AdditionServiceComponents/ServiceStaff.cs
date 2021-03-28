using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.AdditionalServiceComponents
{
    public class ServiceStaff
    {
        public double TimeOccupied { get; set; } = 0;
        public double Utilization { get => _service.Simulation.CurrentTime == 0 ? 0 : TimeOccupied / _service.Simulation.CurrentTime; }
        public double CurrentServiceDuration { get; set; } = 0;
        public bool Occupied { get; set; } = false;
        private ServiceComponent _service;

        public ServiceStaff(ServiceComponent service)
        {
            _service = service;
        }

        public void ReturnToResourcePool()
        {
            _service.ResourcePool.ReturnStaff(this);
        }

        public void Reset()
        {
            CurrentServiceDuration = 0;
            TimeOccupied = 0;
            Occupied = false;
        }
    }
}
