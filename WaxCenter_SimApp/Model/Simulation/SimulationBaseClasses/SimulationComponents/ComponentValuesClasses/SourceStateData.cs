using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.ComponentValuesClasses
{
    public class SourceStateData
    {
        /**
         * Trieda, ktora uzmoznuje ziskat aktualne informacie o komponente source. 
         * Pouziva sa pri real time simulacii na reprezetaciu aktualneho stavu.
         */
        public int SourceOutput { get => _source.NumberOfGenerated; }
        private BaseSourceComponent _source;
        public SourceStateData(BaseSourceComponent source)
        {
            _source = source;
        }

    }
}
