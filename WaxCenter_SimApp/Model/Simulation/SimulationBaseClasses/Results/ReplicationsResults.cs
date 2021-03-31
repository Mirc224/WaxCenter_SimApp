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
        //public double[] ObservedValues { get; set; }
        public ResultGroup[] ResultGroups { get; set; }


        public void AfterReplicationUpdate()
        {
            if (ResultGroups != null)
            {
                foreach (var resultGroup in ResultGroups)
                {
                    resultGroup.AfterReplicationUpdate();
                }
            }
        }

        public void Reset()
        {
            CurrentReplications = 0;
            
            if(ResultGroups != null)
            {
                foreach(var resultGroup in ResultGroups)
                {
                    resultGroup.Reset();
                }

            }

        }
    }
}
