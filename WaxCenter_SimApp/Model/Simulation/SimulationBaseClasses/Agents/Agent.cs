using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents
{
    /*
     * Abstraktna trieda predstavujuca predchodcu pre vsetkych agentov udalostne orientovanej simulacie.
     */
    public abstract class Agent
    {
        // Globalna premenna udavajuca pocet vygenerovanych agentov
        public static int GlobalAgentID = 0;
        // ID agenta
        public int AgentID { get; protected set; }
        // Funkica, ktora vynuluje gobalnu premennu GlobalAgentID
        public static void ResetGlobalID()
        {
            GlobalAgentID = 0;
        }
    }
}
