using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.AdditionServiceComponents;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results
{
    public class ResourcePoolResults: BaseResults
    {
        private ResourcePool _resourcePool;

        public ResourcePoolResults(ResourcePool resPool)
        {
            _resourcePool = resPool;
            Rebuild();
        }

        override
        public void Rebuild()
        {
            _statsNames = new string[1 + _resourcePool.MaxStaff];
            _statsValues = new double[1 + _resourcePool.MaxStaff];
            _statsNames[0] = "Utilization";
            for(int i = 1; i < _resourcePool.MaxStaff + 1; ++i)
            {
                _statsNames[i] = $"Staff{i} utilization";
            }
        }

        public override void AfterReplicationUpdate()
        {
            _statsValues[0] += _resourcePool.Utilization;
            for (int i = 1; i < _resourcePool.MaxStaff + 1; ++i)
            {
                _statsValues[i] += _resourcePool.Staff[i - 1].Utilization;
            }
        }
    }
}
