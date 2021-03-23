using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Statistics
{
    public abstract class BaseStatictic
    {
        protected double Denominator { get; set; }
        protected double Numerator { get; set; }
        public double Min { get; protected set; }
        public double Max { get; protected set; }

        public void Reset()
        {
            Numerator = 0;
            Denominator = 0;
            Min = Double.MaxValue;
            Max = Double.MinValue;
        }
    }
}
