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
        public ContinuousStatistic StatAdminQLength { get; private set; } = new ContinuousStatistic("Admin QLength");
        public DiscreteStatistic StatAdminWaitingTime { get; private set; } = new DiscreteStatistic("Admin WTime");

        // Vysetrenie
        public ContinuousStatistic StatExaminationQLength { get; private set; } = new ContinuousStatistic("Examination QLength");
        public DiscreteStatistic StatExaminationWaitingTime { get; private set; } = new DiscreteStatistic("Examination WTime");

        // Vakcinacia
        public ContinuousStatistic StatVaccinationQLength { get; private set; } = new ContinuousStatistic("Vaccination QLength");
        public DiscreteStatistic StatVaccinationWaitingTime { get; private set; } = new DiscreteStatistic("Vaccination WTime");

        // Cakaren
        public ContinuousStatistic StatWaitingRoomCapacity { get; private set; } = new ContinuousStatistic("Waiting room capacity");

        private Random _sourceArrivalGenerator;
        private Random _notCommingGenerator;

        private int _numberOfNotComing;

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

            ResultGroup adminStatGroup = new ResultGroup(new BaseResults[] {StatAdminQLength.ReplicationResults, 
                                                                            StatAdminWaitingTime.ReplicationResults,
                                                                            AdminService.ResourcePool.ReplicationResults});
            adminStatGroup["QLengthStat"] = StatAdminQLength.ReplicationResults;
            adminStatGroup["WTimeStat"] = StatAdminWaitingTime.ReplicationResults;
            adminStatGroup["ResPool"] = AdminService.ResourcePool.ReplicationResults;

            ResultGroup examinationStatGroup = new ResultGroup(new BaseResults[] {StatExaminationQLength.ReplicationResults,
                                                                                  StatExaminationWaitingTime.ReplicationResults,
                                                                                  ExaminationService.ResourcePool.ReplicationResults});

            examinationStatGroup["QLengthStat"] = StatExaminationQLength.ReplicationResults;
            examinationStatGroup["WTimeStat"] = StatExaminationWaitingTime.ReplicationResults;
            examinationStatGroup["ResPool"] = ExaminationService.ResourcePool.ReplicationResults;

            ResultGroup vaccinationStatGroup = new ResultGroup(new BaseResults[] {StatVaccinationQLength.ReplicationResults,
                                                                                  StatVaccinationWaitingTime.ReplicationResults,
                                                                                  VaccinationService.ResourcePool.ReplicationResults});

            vaccinationStatGroup["QLengthStat"] = StatVaccinationQLength.ReplicationResults;
            vaccinationStatGroup["WTimeStat"] = StatVaccinationWaitingTime.ReplicationResults;
            vaccinationStatGroup["ResPool"] = VaccinationService.ResourcePool.ReplicationResults;

            ResultGroup delayStatGroup = new ResultGroup(new BaseResults[] {StatWaitingRoomCapacity.ReplicationResults});

            delayStatGroup["StatCapacity"] = StatWaitingRoomCapacity.ReplicationResults;

            ReplicationResults.ResultGroups = new ResultGroup[] { adminStatGroup, examinationStatGroup, vaccinationStatGroup, delayStatGroup };

            ReplicationResults["AdminGroup"] = adminStatGroup;
            ReplicationResults["ExaminationGroup"] = examinationStatGroup;
            ReplicationResults["VaccinationGroup"] = vaccinationStatGroup;
            ReplicationResults["DelayGroup"] = delayStatGroup;

            ContinueAfterMaxTime = true;
            MaxTime = 540 * 60;
            StartTimeInSeconds = 28800;
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
        public void BeforeReplication()
        {
            Patient.ResetGlobalID();
            base.BeforeReplication();
            _numberOfNotComing = _notCommingGenerator.Next(5, 25);
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
            StatAdminWaitingTime.Add((CurrentTime - patient.AdminEnterTime) / 60);
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
            StatExaminationWaitingTime.Add((CurrentTime - patient.ExaminationEnterTime) / 60);
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
            StatVaccinationWaitingTime.Add((CurrentTime - patient.VaccinationEnterTime) / 60);
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
            int multiplier = 1;
            //return ((EndTime/60.0)/NumberOfGeneratedAgents)*60;
            while(true)
            {
                if (_sourceArrivalGenerator.NextDouble() < ((double)_numberOfNotComing / PatientGenerated))
                    ++multiplier;
                else
                    break;
            }

            return multiplier * SourceInterval;
        }

        override
        protected void SeedIt()
        {
            _sourceArrivalGenerator = new Random(SeedGenerator.Next());
            _notCommingGenerator = new Random(SeedGenerator.Next());
            base.SeedIt();
        }

        protected override void PlanFirstEvent()
        {
            PatientSource.Start();
        }

        protected override void FinishContinuousStatistics()
        {
            double usedTime = ContinueAfterMaxTime ? CurrentTime : SimulationSettings.MaxTime;
            StatAdminQLength.Add(AdminService.QueueSize, CurrentTime);
            StatExaminationQLength.Add(ExaminationService.QueueSize, usedTime);
            StatVaccinationQLength.Add(VaccinationService.QueueSize, usedTime);
            StatWaitingRoomCapacity.Add(VaccinationService.QueueSize, usedTime);
        }
    }
}
