using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.RandomDistribution
{
    public class ExponentialDistribution : IDistribution
    {
        Random _generator;
        double _lambda;
        public ExponentialDistribution(double exptectedValue)
        {
            _generator = new Random();
            _lambda = 1 / exptectedValue;
        }

        public double Sample()
        {
            double result = _generator.NextDouble();
            return -Math.Log(1 - result)/_lambda;
        }

        public void SetSeed(int seed)
        {
            _generator = new Random(seed);
        }
    }
}
