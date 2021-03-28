using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.ComponentValuesClasses
{
    public class DelayStateData
    {
        public int AgentsEntered { get => _delayComponent.AgentsEntered; }
        public int AgentsLeaved { get => _delayComponent.AgentsLeaved; }
        public int CurrentlyUsed { get => _delayComponent.CurrentlyUsed; }

        protected DelayComponent _delayComponent;
        public DelayStateData(DelayComponent delay)
        {
            _delayComponent = delay;
        }
    }
}
