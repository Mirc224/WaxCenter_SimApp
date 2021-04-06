using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Statistics;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.ComponentValuesClasses
{
    public class StatisticStateData
    {
        /**
         * Trieda, ktora uzmoznuje ziskat aktualne informacie o komponente, ktory sa stara o zber statistiky. 
         * Pouziva sa pri real time simulacii na reprezetaciu aktualneho stavu.
         */
        public double StatMin { get => _statistic.Min; }
        public double StatMax { get => _statistic.Max; }
        public double StatMean { get => _statistic.Mean; }
        private BaseStatistic _statistic;
        public StatisticStateData(BaseStatistic statistic)
        {
            _statistic = statistic;
        }
    }
}
