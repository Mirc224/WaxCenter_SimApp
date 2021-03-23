using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.Model.Simulation.TrafikaSimulation.Events
{
    class CustomerArrivalEvent : NewsPaperEvent
    {
        public CustomerArrivalEvent(EventSimCoreNewsPapers core) : base(core)
        {

        }
        public override void Execute()
        {
            var simNS = (EventSimCoreNewsPapers)Simulation;
            Agent = simNS.CustomerSource.GetAgent();
            var customer = (Customer)Agent;
            //Console.WriteLine($"Prichod zakaznika {Customer.AgentID} o: { this.OccurrenceTime}");
            customer.QueueArrivalTime = simNS.CurrentTime;
            simNS.NewsPaperService.ServiceEnter(customer);
            /*if (simNS.NewsPaperService.IsFree)
            {
                if(simNS.NewsPaperService.StartService())
                {
                    var serviceStartE = new ServiceStartEvent(simNS);
                    serviceStartE.Agent = customer;
                    serviceStartE.OccurrenceTime = simNS.CurrentTime;
                    simNS.EventCalendar.Insert(serviceStartE.OccurrenceTime, serviceStartE);
                    //Console.WriteLine($"Zaciatok oblsuhy zakaznika {Customer.AgentID} je naplanovany na: { serviceStartE.OccurrenceTime}");
                }
            }
            else
            {
                simNS.WaitingQueue.Enqueue(customer);
                //Console.WriteLine($"V rade je {simNS.WaitingQueue.Count}");
            }*/
            simNS.NewsPaperQLength.Add(simNS.NewsPaperService.QueueSize, simNS.CurrentTime);
            this.OccurrenceTime = simNS.CurrentTime + simNS.CustomerSource.Generator.Sample();
            //Console.WriteLine($"Dalsi zakaznik {Customer.AgentID + 1} pride o: { this.OccurrenceTime}");
            simNS.EventCalendar.Insert(this.OccurrenceTime, this);
        }
    }
}
