using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.ComponentValuesClasses
{
    public class SinkStateData
    {
        /**
         * Trieda, ktora uzmoznuje ziskat aktualne informacie o komponente sink. 
         * Pouziva sa pri real time simulacii na reprezetaciu aktualneho stavu.
         */
        public int SinkInput { get => _sink.AgentsSinked; }
        private SinkComponent _sink;
        public SinkStateData(SinkComponent sink)
        {
            _sink = sink;
        }
    }
}
