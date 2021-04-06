using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.ComponentValuesClasses
{
    public class ServiceStateData: DelayStateData
    {
        /**
         * Trieda, ktora uzmoznuje ziskat aktualne informacie o komponente service. 
         * Pouziva sa pri real time simulacii na reprezetaciu aktualneho stavu.
         */
        public int QueueSize { get => ((ServiceComponent)_delayComponent).QueueSize; }
        public double ResourcePoolUtilization { get => ((ServiceComponent)_delayComponent).ResourcePool.Utilization; }
        public int ResourcePoolMaxStaff { get => ((ServiceComponent)_delayComponent).ResourcePool.MaxStaff; }
        public ServiceStateData(ServiceComponent service):
            base(service)
        {
        }
    }
}
