using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results
{
    public abstract class BaseResults
    {
        /**
         * Abstraktna trieda, ktora predstavuje predka pre specificke druhy tried vysledkov.
         * Obsahuje pole hodnot a nazvov pre tieto hodnoty.
         * Su tu uvedene aj hlavicky metod, ktore musi kazdy potomok triedy implementovat.
         */
        protected string[] _statsNames;
        protected double[] _statsValues;
        public string[] Names { get=>_statsNames; }
        public double[] Values { get=>_statsValues; }

        public virtual void Reset()
        {
            // V ramci metody reset su hodnoty v poli nastavene na 0.
            for (int i = 0; i < _statsValues.Length; ++i)
                _statsValues[i] = 0;
        }

        public abstract void AfterReplicationUpdate();

        public abstract void Rebuild();
    }
}
