using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.RandomDistribution
{
    /**
     * Trieda predstavujuca generator trojuholnikoveho rozdelenia. Vstupnymi parametrami konstruktora su minimum, maximum a modus.
     */
    public class TriangularDistribution : IDistribution
    {
        private double _min;
        private double _max;
        private double _mode;

        private Random _gen;

        public TriangularDistribution(double min, double max, double mode)
        {
            _min = min;
            _max = max;
            _mode = mode;
            _gen = new Random();
        }

        public double Sample()
        {
            double generatedU = _gen.NextDouble();
            double Fc = (_mode - _min) / (_max - _min);

            if (generatedU < Fc)
                return _min + Math.Sqrt(generatedU * (_max - _min) * (_mode - _min));
            else
                return _max - Math.Sqrt((1-generatedU) * (_max - _min) * (_max - _mode));
        }

        public void SetSeed(int seed)
        {
            _gen = new Random(seed);
        }
    }
}
