using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results
{
    public class ReplicationsResults
    {
        public int CurrentReplications { get; set; } = 0;
        public double[] ObservedValues { get; set; }


        public void Reset()
        {
            CurrentReplications = 0;

            if(ObservedValues != null)
            {
                for (int i = 0; i < ObservedValues.Length; ++i)
                    ObservedValues[i] = 0;
            }

        }
    }
}
