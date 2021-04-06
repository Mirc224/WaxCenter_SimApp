using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents;

namespace WaxCenter_SimApp.Model.Simulation.VaccinationCenter
{
    public class Patient : Agent
    {
        /**
         * Konkretna implementacia agenta pre ulohu vakcinacneho centra. Obsahuje atributy potrebne pre zbieranie statistik.
         */
        public double ArrivalTime { get; set; }
        public double WaitingRoomTime { get; set; }
        public double AdminEnterTime { get; set; }
        public double ExaminationEnterTime { get; set; }
        public double VaccinationEnterTime { get; set; }

        public Patient()
        {
            AgentID = ++Agent.GlobalAgentID;
        }
    }
}
