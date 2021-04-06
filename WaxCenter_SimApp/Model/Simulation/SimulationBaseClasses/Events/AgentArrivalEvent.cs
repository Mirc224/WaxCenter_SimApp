using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events.BaseEvents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents;

namespace WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events
{
    class BaseAgentArrivalEvent<T> : SimEvent
        where T: Agent
    {
        /**
         * Genericka trieda simulacneho eventu, ktora zodpoveda za udalost agenta urciteho typu. Atributom je zdrojovy komponent, s ktorym je event spaty.
         */
        private SourceComponent<T> _source;

        public BaseAgentArrivalEvent(SourceComponent<T> source)
        {
            _source = source;
        }
        public override void Execute()
        {
            // V ramci metody execute si metoda vyziada od zdroja agenta daneho typu a v pripade ak su splnene podmienky, tak je naplanovany event prichodu dalsieho agenta.
            Agent agent = _source.GetAgent();
            this.Agent = agent;
            this.OccurrenceTime = _source.Simulation.CurrentTime + _source.Generator.Sample();
            if(this.OccurrenceTime <= _source.Simulation.MaxTime || _source.GenerateAfterMaxTime)
                _source.Simulation.EventCalendar.Insert(this.OccurrenceTime, this);
            // Agent, ktory vznikol v ramci tejto udalosti je poslany do dalsieho komponentu simulacie.
            _source.Enter(agent);
        }
    }
}
