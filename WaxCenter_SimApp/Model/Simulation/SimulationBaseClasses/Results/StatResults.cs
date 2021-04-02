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
        public BaseStatistic Statistic { get; private set; }
        private string _description;
        public double Mean { get => _statsValues[0]; }
        public StatResults(BaseStatistic statistic, string description)
        {
            Statistic = statistic;
            _description = description;
            Rebuild();
        }
        public override void AfterReplicationUpdate()
        {
            _statsValues[0] += Statistic.Mean;
            _statsValues[1] += Statistic.Max;
            _statsValues[2] += Statistic.Min;
        }

        public override void Rebuild()
        {
            _statsNames = new string[] { _description + " mean", _description + " max" , _description + " min" };
            _statsValues = new double[3];
        }
    }
}
