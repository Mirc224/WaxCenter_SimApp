using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Statistics;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results
{
    public class StatResults : BaseResults
    {
        private BaseStatistic _statistic;
        private string _description;

        public StatResults(BaseStatistic statistic, string description)
        {
            _statistic = statistic;
            _description = description;
            Rebuild();
        }
        public override void AfterReplicationUpdate()
        {
            _statsValues[0] += _statistic.Mean;
            _statsValues[1] += _statistic.Max;
            _statsValues[2] += _statistic.Min;
        }

        public override void Rebuild()
        {
            _statsNames = new string[] { _description + " mean", _description + " max" , _description + " min" };
            _statsValues = new double[3];
        }
    }
}
