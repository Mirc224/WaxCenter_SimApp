using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results
{
    public class ResultGroup
    {
        public BaseResults[] GroupResults { get; set; }
        public ReplicationsResults ReplicationsResult { get; set; }
        private Dictionary<string, BaseResults> _dictionaryResults = new Dictionary<string, BaseResults>();
        public BaseResults this[string key] { get => _dictionaryResults[key]; set => _dictionaryResults[key] = value; }

        public ResultGroup(BaseResults[] results)
        {
            GroupResults = results;
        }

        public void AfterReplicationUpdate()
        {
            foreach (var result in GroupResults)
            {
                result.AfterReplicationUpdate();
            }
        }

        public void Rebuild()
        {
            foreach (var result in GroupResults)
            {
                result.Rebuild();
            }
        }

        public void Reset()
        {
            foreach (var result in GroupResults)
            {
                result.Reset();
            }
        }
    }
}
