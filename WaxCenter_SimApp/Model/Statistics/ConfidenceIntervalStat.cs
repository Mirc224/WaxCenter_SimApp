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
        private double _XSquaredSum;
        private double _XSum;
        private double _variance { get => _count < 2 ? 0 : Math.Sqrt((_OneDivNMinusOne * _XSquaredSum) - Math.Pow(_OneDivNMinusOne * _XSum, 2)); }
        private double _OneDivNMinusOne { get => (1.0 / _count - 1); }
        private int _count;

        public void Add(double value)
        {
            ++_count;
            _XSum += value;
            _XSquaredSum = value * value;
        }

        public void Reset()
        {
            Mean = 0;
            _XSquaredSum = 0;
            _XSum = 0;
            _count = 0;
        }

    }
}
