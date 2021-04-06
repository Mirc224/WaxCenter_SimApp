using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results
{
    public class ResultGroup
    {
        /**
         * Skupina vysledkov. Obsahuje vysledky, vacsinou suvisiace s jednym komponentom simulacie. Umoznuje adresovanie vysledku na zaklade slovniku, kde je klucom string hodnota.
         */
        public BaseResults[] GroupResults { get; set; }
        public ReplicationsResults ReplicationsResult { get; set; }
        public BaseResults this[string key] { get => _dictionaryResults[key]; set => _dictionaryResults[key] = value; }
        public ResultGroup(BaseResults[] results)
        {
            GroupResults = results;
        }
        private Dictionary<string, BaseResults> _dictionaryResults = new Dictionary<string, BaseResults>();
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
