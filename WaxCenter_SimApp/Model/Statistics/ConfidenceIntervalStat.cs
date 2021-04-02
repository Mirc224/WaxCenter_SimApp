using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Statistics
{
    class ConfidenceIntervalStat
    {
        public double Mean { get; protected set; }
        public double Variance { get; protected set; }
        public double Low { get; protected set; }
        public double High { get; protected set; }
        public int Count { get; protected set; }

        public double _observedValuesSum;

        public void Add(double value)
        {
            _observedValuesSum += value;
        }

        public void Reset()
        {
            Mean = 0;
            Variance = 0;
            Low = 0;
            High = 0;
            Count = 0;
        }

    }
}
