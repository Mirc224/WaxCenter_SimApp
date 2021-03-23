using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Statistics
{
    public class ContinousStatistic : BaseStatictic
    {
        public double PreviousState { get; set; }
        public double PreviousValue { get; set; }
        public double Mean { get => Denominator != 0 ? Numerator / Denominator : 0; }
        public void Add(double value, double time)
        {
            double weight = (time - PreviousState);
            Numerator += weight * PreviousValue;
            Denominator += weight;
            PreviousState = time;
            PreviousValue = value;
            if (value < Min)
                Min = value;
            if (value > Max)
                Max = value;
        }
    }
}
