using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.ComponentValuesClasses;

namespace WaxCenter_SimApp.Model.Statistics
{
    public abstract class BaseStatistic
    {
        /** Abstraktna trieda predstavujuca predka vsetkych statistik. Obsahuje citatela a menovatela, minimum, maximum a hlavicky zakladnych funkcii, ktore musi kazda statistika obsahovat.*/
        protected double Denominator { get; set; }
        protected double Numerator { get; set; }
        public double Min { get => _noRecords ? 0 : _min;}
        public double Max { get => _noRecords ? 0 : _max; }
        protected bool _noRecords = false;
        protected double _min;
        protected double _max;
        public StatResults ReplicationResults { get; set; }
        abstract public double Mean { get; }
        public StatisticStateData StateData { get; protected set; }
        public BaseStatistic(string description)
        {
            StateData = new StatisticStateData(this);
            ReplicationResults = new StatResults(this, description);
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
