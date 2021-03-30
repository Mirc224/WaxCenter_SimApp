using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.GUIComponents.Screens;

namespace WaxCenter_SimApp.GUIComponents.SimComponents.GUISimComponentsWrapper
{
    public class GUISimulationComponentsManager
    {
        public SimSource GSimSource { get; set;}
        public SimService[] GSimServices { get; set; }
        public SimResourcePool[] GSimResourcePools { get; set; }
        public SimDelay[] GSimDelays { get; set; }
        public SimSink GSimSink { get; set; }
        public SimStats[] GSimStats { get; set; }

        public void SetSimulationControlForComponents(SimulationControl simControl)
        {
            if (GSimSource != null)
                GSimSource.SimulationControl = simControl;

            if (GSimServices != null)
                foreach (var service in GSimServices)
                    service.SimulationControl = simControl;

            if (GSimResourcePools != null)
                foreach (var resourcePool in GSimResourcePools)
                    resourcePool.SimulationControl = simControl;

            if (GSimDelays != null)
                foreach (var delay in GSimDelays)
                    delay.SimulationControl = simControl;

            if (GSimSink != null)
                GSimSink.SimulationControl = simControl;

            if (GSimStats != null)
                foreach (var stat in GSimStats)
                    stat.SimulationControl = simControl;

        }
    }
}
