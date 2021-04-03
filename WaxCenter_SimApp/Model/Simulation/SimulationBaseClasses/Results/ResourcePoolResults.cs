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
        public ResourcePool ResourcePool { get; private set; }
        public double Utilization { get => _statsValues[0]; }

        public ResourcePoolResults(ResourcePool resPool)
        {
            ResourcePool = resPool;
            Rebuild();
        }

        override
        public void Rebuild()
        {
            _statsNames = new string[1 + ResourcePool.MaxStaff];
            _statsValues = new double[1 + ResourcePool.MaxStaff];
            _statsNames[0] = "Utilization";
            for(int i = 1; i < ResourcePool.MaxStaff + 1; ++i)
            {
                _statsNames[i] = $"Staff{i} utilization";
            }
        }

        public override void AfterReplicationUpdate()
        {
            _statsValues[0] += ResourcePool.Utilization * 100;
            for (int i = 1; i < ResourcePool.MaxStaff + 1; ++i)
            {
                _statsValues[i] += ResourcePool.Staff[i - 1].Utilization * 100;
            }
        }
    }
}
