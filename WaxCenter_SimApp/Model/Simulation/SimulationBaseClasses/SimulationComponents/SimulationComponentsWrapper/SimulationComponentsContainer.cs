using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Statistics;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.SimulationComponentsWrapper
{
    public class SimulationComponentsContainer
    {
        public BaseSourceComponent Source { get; set; }
        public SinkComponent Sink { get; set; }
        public ServiceComponent[] ServiceComponents { get; set; }
        public DelayComponent[] DelayComponents { get; set; }
        public BaseStatistic[] Statistics { get; set; }
    }
}
