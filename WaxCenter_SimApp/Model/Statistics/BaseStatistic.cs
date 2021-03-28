using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.ComponentValuesClasses;

namespace WaxCenter_SimApp.Model.Statistics
{
    public abstract class BaseStatistic
    {
        protected double Denominator { get; set; }
        protected double Numerator { get; set; }
        public double Min { get; protected set; }
        public double Max { get; protected set; }
        abstract public double Mean { get; }
        public StatisticStateData StateData { get; protected set; }
        public BaseStatistic()
        {
            StateData = new StatisticStateData(this);
        }
        public void Reset()
        {
            Numerator = 0;
            Denominator = 0;
            Min = Double.MaxValue;
            Max = Double.MinValue;
        }
    }
}
