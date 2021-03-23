using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Statistics
{
    public class DiscreteStatistic : BaseStatictic
    {
        public double Mean { get => Numerator / Denominator; }
        public void Add(double value)
        {
            Numerator += value;
            ++Denominator;
            if (value < Min)
                Min = value;
            if (value > Max)
                Max = value;
        }
    }
}
