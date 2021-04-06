using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.RandomDistribution
{
    /*
     * Generator rovnomerneho spojiteho rozdelenia na urcitom intervale. Parametrami konstruktora su minimalna a maximalna hodnota, ktora ma byt vygenerovana.
     */
    class UniformBoundedDistribution : IDistribution
    {
        Random _generator;
        private int _min;
        private int _max;

        public UniformBoundedDistribution(int min, int max)
        {
            _min = min;
            _max = max;
            _generator = new Random();
        }
        public void SetSeed(int seed)
        {
            _generator = new Random(seed);
        }

        public double Sample()
        {
            return (_max - _min) * _generator.NextDouble() + _min;
        }
    }
}
