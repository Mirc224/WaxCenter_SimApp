using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.RandomDistribution
{
    /**
     * Trieda generatora diskretneho rozdelenia. Parametrami pre vytvorenie su pravdepodobnosti a k nim prisluchajuce hodnoty.
     * Na urcenie hodnoty sa pouziva generator rovnomerneho rozdelenia
     */
    public class DiscreteDistribution : IDistribution
    {
        // Pole pravdepodobnosti
        private double[] _probabilities;
        // Pole hodnot prisluchajucich pravdepodbnostiam
        private double[] _outputValues;
        private Random _generator;
        public DiscreteDistribution(double[] probabilities, double[] outputValues)
        {
            _probabilities = probabilities;
            _outputValues = outputValues;
        }
        public double Sample()
        {
            double cummulatedProbability = 0;
            double generatedValue = _generator.NextDouble();
            for(int i = 0; i < _probabilities.Length; ++i)
            {
                cummulatedProbability += _probabilities[i];
                if(generatedValue < cummulatedProbability)
                {
                    return _outputValues[i];
                }
            }

            return 0;
        }

        public void SetSeed(int seed)
        {
            _generator = new Random(seed);
        }
    }
}
