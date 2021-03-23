using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core
{
    interface ISimulation
    {
        void BeforeSimulation();
        void AfterSimulation();
        void DoReplication();
        void BeforeReplication();
        void AferReplication();
    }
}
