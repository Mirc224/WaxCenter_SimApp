using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results
{
    public class ServiceResults: BaseResults
    {
        private ServiceComponent _serviceComponent;

        public ServiceResults(ServiceComponent service)
        {
            _serviceComponent = service;
        }

        override
        public void Rebuild()
        {
            _statsNames = new string[1 + _serviceComponent.MaxStaff];
            _statsValues = new double[1 + _serviceComponent.MaxStaff];
            _statsNames[0] = "Utilization";
            for(int i = 1; i < _serviceComponent.ResourcePool.MaxStaff + 1; ++i)
            {
                _statsNames[i] = "Staff{i} utilization:";
            }
        }

        public override void AfterReplicationUpdate()
        {
            _statsValues[0] += _serviceComponent.ResourcePool.Utilization;
            for (int i = 1; i < _serviceComponent.ResourcePool.MaxStaff + 1; ++i)
            {
                _statsValues[i] += _serviceComponent.ResourcePool.Staff[i - 1].Utilization;
            }
        }
    }
}
