using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core
{
    /**
     * Interface, ktory musi implementovat kazde simulacne jadro.
     */
    interface ISimulation
    {
        // Metoda obsahujuca funkcie, ktore sa musia vykonat pred zaciatkom kazdej simulacie
        void BeforeSimulation();
        // Metoda obsahujuca funkcie, ktore sa musia vykonat po konci kazdej simulacie
        void AfterSimulation();
        // Metoda obsahujuca funkcie, ktore sa musia vykonat pocas replikacie. Ide vlastne o hlavnu simulacnu slucku.
        void DoReplication();
        // Metoda obsahujuca funkcie, ktore sa musia vykonat pred kazdou replikaciou
        void BeforeReplication();
        // Metoda obsahujuca funkcie, ktore sa musia vykonat po kazdej replikacii
        void AfterReplication();
    }
}
