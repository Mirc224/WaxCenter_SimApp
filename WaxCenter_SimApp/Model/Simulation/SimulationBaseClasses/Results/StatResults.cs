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
        /**
         * Trieda vysledkov suvisiacich s komponentami statistiky. Tato tried umoznuje pre kazdu satistiku ziskat aj interval spolahlivosti, ktory je defaultne nastaveny na 95% interval spolahlivosti.
         */
        // Odlaz na zodpovedajucu statistiku
        public BaseStatistic Statistic { get; private set; }
        // Prupustna odhadovana chyba
        public double AddmissibleErrorEst { get => _count < 1 ? Double.MaxValue : Coefficient * Variance / Math.Sqrt(_count); }
        // Koeficiet studentovho rozdelenia pre urcity interval spolahlivosti
        public double Coefficient { get; set; } = 1.96;
        // Suma priemerov sledovanej statistiky
        public double MeanSum { get => _statsValues[0]; }
        // Priemer zo sumy priemerov
        public double Mean { get => _count == 0 ? 0 : _statsValues[0] / _count; }
        // Suma priemerov na druhu, ktora sa pouziva pre efektivny vypocet intervalu spolahlivosti
        public double XSquared { get => _statsValues[3]; }
        // Odchylka sledovanej statistiky vypocitatan zo zaznamenanych dat
        public double Variance { get => _count < 2 ? 0 : Math.Sqrt(_OneDivNMinusOne * XSquared - Math.Pow(_OneDivNMinusOne * MeanSum,2)); }

        private double _OneDivNMinusOne { get => (1.0 / (_count - 1)); }
        // Popis statistiky
        private string _description;
        // Pocet zozbieranych dat
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
