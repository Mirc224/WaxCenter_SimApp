using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core.EventSimulationCore;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Settings
{
    public class BaseEventSimulationSettings
    {
        public int Speed { get; set; } = 1;
        public double MaxTime { get => _maxTime; set => _maxTime = value * ((int)Units); }
        public bool ContinueAfterMaxTime { get; set; } = false;
        public bool AutoSeed { get; set; } = true;
        public int LastUsedSeed { get; set; } = 224;

        public TimeUnits Units { get; set; } = TimeUnits.SECONDS;
        private double _maxTime = 0;

    }
}
