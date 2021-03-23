using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.TrafikaSimulation.Events
{
    public class ServiceStartEvent : NewsPaperEvent
    {

        public ServiceStartEvent(EventSimCoreNewsPapers core) : base(core)
        {

        }
        public override void Execute()
        {
            //Console.WriteLine($"Zaciatok obsluhy zakaznika {Customer.AgentID} o: { this.OccurrenceTime}");
            var simNS = (EventSimCoreNewsPapers)Simulation;
            var endEvent = new ServiceEndEvent(simNS);
            var customer = (Customer)Agent;
            simNS.NewsPaperQLength.Add(simNS.NewsPaperService.QueueSize, simNS.CurrentTime);
            simNS.NewsPaperWaitingTime.Add(simNS.CurrentTime - customer.QueueArrivalTime);
            endEvent.Agent = customer;
            endEvent.OccurrenceTime = simNS.CurrentTime + simNS.NewsPaperService.Generator.Sample();
            //Console.WriteLine($"Koniec obsluhy zakaznika {Customer.AgentID} naplanovany na: { endEvent.OccurrenceTime}");
            simNS.EventCalendar.Insert(endEvent.OccurrenceTime, endEvent);
        }
    }
}
