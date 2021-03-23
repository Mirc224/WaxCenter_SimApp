using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents;

namespace WaxCenter_SimApp.Model.Simulation.TrafikaSimulation
{
    public class Customer : Agent
    {
        public double QueueArrivalTime { get; set; } = 0;
        public Customer()
        {
            AgentID = Customer.GlobalAgentID++;
        }

        public static void ResetGlobalID()
        {
            GlobalAgentID = 0;
        }
    }
}
