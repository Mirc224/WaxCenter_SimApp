using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.GUIComponents.SimComponents
{   
    public enum SimComponentType
    {
        SOURCE,
        SINK,
        SELECT2,
        DELAY,
        SERVICE,
        RESOURCEPOOL,
        STAT
    }
    public interface ISimComponent
    {
        int ID { get; set; }
        SimComponentType SimComponentType { get; }
        Screens.SimulationControl SimulationControl { get; set; }
    }
}
