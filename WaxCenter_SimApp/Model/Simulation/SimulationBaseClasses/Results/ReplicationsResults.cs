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
        public double MeanOvertime { get => CurrentReplications == 0 ? 0 : OverTime / CurrentReplications; }
        public double OverTime { get; set; } = 0;

        private Dictionary<string, ResultGroup> _dicionaryGroup = new Dictionary<string, ResultGroup>();

        public ResultGroup this[string key] { get => _dicionaryGroup[key]; set => _dicionaryGroup[key] = value; }
        public ResultGroup[] ResultGroups { 
            get=> _resultGroups; 
            set
            {
                _resultGroups = value;
                foreach (var group in _resultGroups)
                    group.ReplicationsResult = this;
            }
        }

        private ResultGroup[] _resultGroups;


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

        public void Rebuild()
        {
            if (ResultGroups != null)
            {
                foreach (var resultGroup in ResultGroups)
                {
                    resultGroup.Rebuild();
                }
            }
        }

        public void Reset()
        {
            CurrentReplications = 0;
            OverTime = 0;
            
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
