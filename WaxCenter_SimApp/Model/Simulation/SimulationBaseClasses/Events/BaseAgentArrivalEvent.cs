using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events
{
    class BaseAgentArrivalEvent<T> : SimEvent
        where T: Agent
    {
        private SourceComponent<T> _source;

        public BaseAgentArrivalEvent(SourceComponent<T> source)
        {
            _source = source;
        }
        public override void Execute()
        {
            Agent agent = _source.GetAgent();
            this.Agent = agent;
            this.OccurrenceTime = _source.Simulation.CurrentTime + _source.Generator.Sample();
            _source.Simulation.EventCalendar.Insert(this.OccurrenceTime, this);
            _source.Enter(agent);
        }
    }
}
