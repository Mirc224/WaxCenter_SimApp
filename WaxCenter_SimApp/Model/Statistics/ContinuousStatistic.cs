using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Statistics
{
    public class ContinuousStatistic : BaseStatistic
    {
        /** Potomok triedy base statistic. Umoznuje vypocet spojitch statistik. Zaznamenava si predchadzajuci stav a hodnotu. Stavom byva zvycajnse cas.*/
        public double PreviousState { get; private set; }
        public double PreviousValue { get; private set; }
        override public double Mean { get => Denominator != 0 ? Numerator / Denominator : 0; }

        public ContinuousStatistic(string description)
            : base(description)
        {
        }
        public void Add(double value, double time)
        {
            double weight = (time - PreviousState);
            Numerator += weight * PreviousValue;
            Denominator += weight;
            PreviousState = time;
            PreviousValue = value;
            if (value < Min)
                _min = value;
            if (value > Max)
                _max = value;
            _noRecords = false;
        }
        
        override public void Reset()
        {
            PreviousState = 0;
            PreviousValue = 0;
            base.Reset();
        }
    }
}
