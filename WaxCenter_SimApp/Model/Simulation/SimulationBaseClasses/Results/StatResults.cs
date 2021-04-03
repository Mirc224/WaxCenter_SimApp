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
        public double AddmissibleErrorEst { get => _count < 1 ? Double.MaxValue : Coefficient * Variance / Math.Sqrt(_count); }
        public double Coefficient { get; set; } = 1.96;
        public double MeanSum { get => _statsValues[0]; }
        public double Mean { get => _count == 0 ? 0 : _statsValues[0] / _count; }
        public double XSquared { get => _statsValues[3]; }
        public double Variance { get => _count < 2 ? 0 : Math.Sqrt(_OneDivNMinusOne * XSquared - Math.Pow(_OneDivNMinusOne * MeanSum,2)); }

        private double _OneDivNMinusOne { get => (1.0 / (_count - 1)); }
        private int _count = 0;
        public StatResults(BaseStatistic statistic, string description)
        {
            Statistic = statistic;
            _description = description;
            Rebuild();
        }

        public override void AfterReplicationUpdate()
        {
            ++_count;
            _statsValues[0] += Statistic.Mean;
            _statsValues[1] += Statistic.Max;
            _statsValues[2] += Statistic.Min;
            _statsValues[3] += Statistic.Mean * Statistic.Mean;
        }

        public override void Rebuild()
        {
            _statsNames = new string[] { _description + " mean", _description + " max" , _description + " min" };
            _statsValues = new double[4];
        }

        public override void Reset()
        {
            _count = 0;
            base.Reset();
        }

    }
}
