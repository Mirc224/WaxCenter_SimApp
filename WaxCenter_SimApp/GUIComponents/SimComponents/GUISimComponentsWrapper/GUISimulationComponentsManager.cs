using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.GUIComponents.SimComponents.GUISimComponentsWrapper
{
    public class GUISimulationComponentsManager
    {
        public SimSource GSimSource { get; set;}
        public SimService[] GSimServices { get; set; }
        public SimResourcePool[] GSimResourcePool { get; set; }
        public SimDelay[] GSimDelays { get; set; }
        public SimSink GSimSink { get; set; }
        public SimStats[] GSimStats { get; set; }
    }
}
