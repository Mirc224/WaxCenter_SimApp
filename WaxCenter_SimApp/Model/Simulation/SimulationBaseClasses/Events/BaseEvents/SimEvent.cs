using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events.BaseEvents
{
    public abstract class SimEvent
    {
        /**
         * Abstraktna trieda, ktora predstavuje predka pre vsetky udalosti v simulacii. Obsahuje zakladne atributy, ktorymi su cas vyskytu, simulacia ku ktorej event prisluch 
         * a agent, s ktorym udalost pracuje. Taktiez obsahuje aj hlavicu metod, ktore musi implementovat kazda udalost.
         */
        public double OccurrenceTime { get; set; }
        public EventSimulationCore Simulation { get; protected set; }
        public Agent Agent { get; set; }
        public abstract void Execute();
    }
}
