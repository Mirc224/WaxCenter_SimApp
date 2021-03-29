using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Statistics;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.SimulationComponentsWrapper
{
    public class SimulationComponentsManager
    {
        public BaseSourceComponent Source { get; set; }
        public SinkComponent Sink { get; set; }
        public ServiceComponent[] ServiceComponents { get; set; }
        public DelayComponent[] DelayComponents { get; set; }
        public BaseStatistic[] Statistics { get; set; }

        public void ResetAllComponents()
        {
            if (Source != null)
                Source.Reset();

            if (ServiceComponents != null)
                for (int i = 0; i < ServiceComponents.Length; ++i)
                    ServiceComponents[i].Reset();

            if (DelayComponents != null)
                for (int i = 0; i < DelayComponents.Length; ++i)
                    DelayComponents[i].Reset();

            if (Sink != null)
                Sink.Reset();
        }

        public void SetComponetsSeed(Random seedGenerator)
        {
            if (Source != null)
                Source.Generator.SetSeed(seedGenerator.Next());

            if (ServiceComponents != null)
                for (int i = 0; i < ServiceComponents.Length; ++i)
                    ServiceComponents[i].Generator.SetSeed(seedGenerator.Next());

            if (DelayComponents != null)
                for (int i = 0; i < DelayComponents.Length; ++i)
                    DelayComponents[i].Generator.SetSeed(seedGenerator.Next());
        }

    }
}
