using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.TrafikaSimulation.Events
{
    class ServiceEndEvent : NewsPaperEvent
    {
        public ServiceEndEvent(EventSimCoreNewsPapers core) : base(core)
        {

        }
        public override void Execute()
        {
            //Console.WriteLine($"Koniec obsluhy zakaznika {Customer.AgentID} o: { this.OccurrenceTime}");
            var simNS = (EventSimCoreNewsPapers)Simulation;
            simNS.NewsPaperService.EndService();
            simNS.NewsPaperQLength.Add(simNS.NewsPaperService.QueueSize, simNS.CurrentTime);
            simNS.CustomerSink.Sink();
            /*if(simNS.WaitingQueue.Count != 0)
            {
                var serviceStart = new ServiceStartEvent(simNS);
                serviceStart.Agent = simNS.WaitingQueue.Dequeue();
                serviceStart.OccurrenceTime = this.OccurrenceTime;
                simNS.EventCalendar.Insert(serviceStart.OccurrenceTime, serviceStart);
            }
            else
            {
                simNS.NewsPaperService.EndSerivce();
            }*/
        }
    }
}
