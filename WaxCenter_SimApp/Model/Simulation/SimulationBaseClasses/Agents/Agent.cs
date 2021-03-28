using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents
{
    public abstract class Agent
    {
        public static int GlobalAgentID = 0;
        public int AgentID { get; protected set; }
        public static void ResetGlobalID()
        {
            GlobalAgentID = 0;
        }
    }
}
