using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.RandomDistribution;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Agents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Events.BaseEvents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents;
using WaxCenter_SimApp.Model.Statistics;

namespace WaxCenter_SimApp.Model.Simulation.VaccinationCenter
{
    public class EventSimCoreVaccinationCenter : EventSimulationCore
    {

        public double SourceInterval { get; set; } = 60;
        public int PatientGenerated { get; set; } = 540;
        // Komponenty
        public SourceComponent<Patient> PatientSource { get; private set; }
        public ServiceComponent AdminService { get; private set; }
        public ServiceComponent ExaminationService { get; private set; }
        public ServiceComponent VaccinationService { get; private set; }
        public DelayComponent WaitingRoomDelay { get; private set; }
        public SinkComponent PatientSink { get; private set; }

        // Statistiky
        // Administracia
        public ContinuousStatistic StatAdminQLength { get; private set; } = new ContinuousStatistic();
        public DiscreteStatistic StatAdminWaitingTime { get; private set; } = new DiscreteStatistic();

        // Vysetrenie
        public ContinuousStatistic StatExaminationQLength { get; private set; } = new ContinuousStatistic();
        public DiscreteStatistic StatExaminationWaitingTime { get; private set; } = new DiscreteStatistic();

        // Vakcinacia
        public ContinuousStatistic StatVaccinationQLength { get; private set; } = new ContinuousStatistic();
        public DiscreteStatistic StatVaccinationWaitingTime { get; private set; } = new DiscreteStatistic();

        // Cakaren
        public ContinuousStatistic StatWaitingRoomCapacity { get; private set; } = new ContinuousStatistic();

        public EventSimCoreVaccinationCenter(Controller.Controller controller, double maxTime = 0)
            : base(controller, maxTime)
        {
            var sourceGenerator = new CustomDistribution();
            sourceGenerator.CustomDistributionFunction = SourceGeneratorFunction;
            PatientSource = new SourceComponent<Patient>(this, sourceGenerator);
            AdminService = new ServiceComponent(this, new UniformBoundedDistribution(140, 220), 5);
            AdminService.OnEnter = AdminOnEnter;
            AdminService.OnEnterDelay = AdminOnEnterDelay;
            PatientSource.NextComponent = AdminService;

            ExaminationService = new ServiceComponent(this, new ExponentialDistribution(260), 6);
            ExaminationService.OnEnter = ExaminationOnEnter;
            ExaminationService.OnEnterDelay = ExaminationOnEnterDelay;
            AdminService.NextComponent = ExaminationService;

            VaccinationService = new ServiceComponent(this, new TriangularDistribution(20, 100, 75), 3);
            VaccinationService.OnEnter = VaccinationOnEnter;
            VaccinationService.OnEnterDelay = VaccinationOnEnterDelay;
            ExaminationService.NextComponent = VaccinationService;

            WaitingRoomDelay = new DelayComponent(this, new DiscreteDistribution(new double[] { 0.95, 0.05 }, new double[] { 15 * 60, 30 * 60 }), int.MaxValue);
            WaitingRoomDelay.OnEnter = WaitingRoomOnEnter;
            WaitingRoomDelay.OnExit = WaitingRoomOnExit;
            VaccinationService.NextComponent = WaitingRoomDelay;

            PatientSink = new SinkComponent(this);
            WaitingRoomDelay.NextComponent = PatientSink;

            SimulationComponentsManager.Source = PatientSource;
            SimulationComponentsManager.ServiceComponents = new ServiceComponent[] { AdminService, ExaminationService, VaccinationService };
            SimulationComponentsManager.DelayComponents = new DelayComponent[] { WaitingRoomDelay};
            SimulationComponentsManager.Sink = PatientSink;
            SimulationComponentsManager.Statistics = new BaseStatistic[] {StatAdminQLength, StatAdminWaitingTime, StatExaminationQLength, StatExaminationWaitingTime,
                                                                   StatVaccinationQLength, StatVaccinationWaitingTime, StatWaitingRoomCapacity};

            int noStatistics = SimulationComponentsManager.ServiceComponents.Length + SimulationComponentsManager.Statistics.Length;
            ReplicationResults = new ReplicationsResults();
            ReplicationResults.CurrentReplications = 0;
            ReplicationResults.ObservedValues = new double[noStatistics];
            //ContinueAfterMaxTime = true;
            ContinueAfterMaxTime = false;
            MaxTime = 540 * 60;
            SetSeed();
        }

        override
        public void DoReplication()
        {
            base.DoReplication();
/*            Console.WriteLine("AdminQL: " + StatAdminQLength.Mean);
            Console.WriteLine("AdminWaiting Time: " + StatAdminWaitingTime.Mean);
            Console.WriteLine("AdminRS: " + AdminService.ResourcePool.Utilization + "\n");
            Console.WriteLine("ExaminationQL: " + StatExaminationQLength.Mean);
            Console.WriteLine("ExaminationWaiting Time: " + StatExaminationWaitingTime.Mean);
            Console.WriteLine("DoctorRS: " + ExaminationService.ResourcePool.Utilization + "\n");
            Console.WriteLine("VaccinationQL: " + StatVaccinationQLength.Mean);
            Console.WriteLine("VaccinationWaiting Time: " + StatVaccinationWaitingTime.Mean);
            Console.WriteLine("SisterRS: " + VaccinationService.ResourcePool.Utilization + "\n");
            Console.WriteLine("StatWaitingRoom: " + StatWaitingRoomCapacity.Mean + "\n");*/
        }

        override
        public void BeforeReplicationInit()
        {
            CurrentTime = 0;
            EventCalendar.Reset();
            Patient.ResetGlobalID();
            base.BeforeReplication();
        }

        private int AdminOnEnter(DelayComponent self, Agent agent)
        {
            var service = (ServiceComponent)self;
            var patient = (Patient)agent;
            patient.AdminEnterTime = CurrentTime;
            StatAdminQLength.Add(service.QueueSize, CurrentTime);
            return 0;
        }

        private int AdminOnEnterDelay(ServiceComponent self, Agent agent)
        {
            var patient = (Patient)agent;
            StatAdminQLength.Add(self.QueueSize, CurrentTime);
            StatAdminWaitingTime.Add(CurrentTime - patient.AdminEnterTime);
            return 0;
        }

        private int ExaminationOnEnter(DelayComponent self, Agent agent)
        {
            var service = (ServiceComponent)self;
            var patient = (Patient)agent;
            patient.ExaminationEnterTime = CurrentTime;
            StatExaminationQLength.Add(service.QueueSize, CurrentTime);
            return 0;
        }
        private int ExaminationOnEnterDelay(ServiceComponent self, Agent agent)
        {
            var patient = (Patient)agent;
            StatExaminationQLength.Add(self.QueueSize, CurrentTime);
            StatExaminationWaitingTime.Add(CurrentTime - patient.ExaminationEnterTime);
            return 0;
        }
        private int VaccinationOnEnter(DelayComponent self, Agent agent)
        {
            var service = (ServiceComponent)self;
            var patient = (Patient)agent;
            patient.VaccinationEnterTime = CurrentTime;
            StatVaccinationQLength.Add(service.QueueSize, CurrentTime);
            return 0;
        }
        private int VaccinationOnEnterDelay(ServiceComponent self, Agent agent)
        {
            var patient = (Patient)agent;
            StatVaccinationQLength.Add(self.QueueSize, CurrentTime);
            StatVaccinationWaitingTime.Add(CurrentTime - patient.VaccinationEnterTime);
            return 0;
        }
        private int WaitingRoomOnEnter(DelayComponent self, Agent agent)
        {
            StatWaitingRoomCapacity.Add(self.CurrentlyUsed, CurrentTime);
            return 0;
        }
        private int WaitingRoomOnExit(DelayComponent self, Agent agent)
        {
            StatWaitingRoomCapacity.Add(self.CurrentlyUsed, CurrentTime);
            return 0;
        }
        private double SourceGeneratorFunction()
        {
            //return ((EndTime/60.0)/NumberOfGeneratedAgents)*60;
            return SourceInterval;
        }

        protected override void PlanFirstEvent()
        {
            PatientSource.Start();
        }

        protected override void UpdateReplicationResults()
        {
            int noStats = SimulationComponentsManager.Statistics.Length;
            int noServices = SimulationComponentsManager.ServiceComponents.Length;
            ++ReplicationResults.CurrentReplications;
            for(int i = 0; i < noStats; ++i)
            {
                ReplicationResults.ObservedValues[i] += SimulationComponentsManager.Statistics[i].Mean;
            }

            for (int i = noStats; i < noStats + noServices; ++i)
            {
                ReplicationResults.ObservedValues[i] += SimulationComponentsManager.ServiceComponents[i - noStats].ResourcePool.Utilization;
            }

        }
    }
}
