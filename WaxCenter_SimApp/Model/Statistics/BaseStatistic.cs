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
        public double Min { get => _noRecords ? 0 : _min;}
        public double Max { get => _noRecords ? 0 : _max; }
        protected bool _noRecords = false;
        protected double _min;
        protected double _max;
        abstract public double Mean { get; }
        public StatisticStateData StateData { get; protected set; }
        public BaseStatistic()
        {
            StateData = new StatisticStateData(this);
        }
        public virtual void Reset()
        {
            Numerator = 0;
            Denominator = 0;
            _min = Double.MaxValue;
            _max = Double.MinValue;
            _noRecords = true;
        }
    }
}
