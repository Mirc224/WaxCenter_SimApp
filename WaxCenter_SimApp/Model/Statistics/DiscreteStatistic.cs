using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Statistics
{
    public class DiscreteStatistic : BaseStatistic
    {
        /** Potomok triedy base statistic. Umoznuje vypocet diskrenych statistik.*/
        public DiscreteStatistic(string description) 
            : base(description)
        {
        }

        override public double Mean { get => Numerator / Denominator; }
        public void Add(double value)
        {
            Numerator += value;
            ++Denominator;
            if (value < Min)
                _min = value;
            if (value > Max)
                _max = value;
            _noRecords = false;
        }
    }
}
