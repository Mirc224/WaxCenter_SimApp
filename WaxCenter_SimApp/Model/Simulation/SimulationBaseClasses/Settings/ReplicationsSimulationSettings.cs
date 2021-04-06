using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Settings
{
    public class ReplicationsSimulationSettings
    {
        /**
         * Trieda obsahujuca data pre vykonavanie simulacneho behu s viacerymi replikaciami.
         */
        public int NumberOfReplications { get; set; } = 0;
        public int DataUpdateInterval { get; set; } = 10;
        public SimulationStatus ReplicationSimulationStatus { get; set; } = SimulationStatus.FINISHED;

    }
}
