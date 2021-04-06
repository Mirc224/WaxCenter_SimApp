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
        /**
         * Konkretna uloha udalostne orientovanej simulacie. Konkretne ide o ulohu vakcinacneho centra.
         */
        /** Udava interval v sekundach, v akom budu agenti vstupovat do modelu.*/
        public double SourceInterval { get; set; } = 60;
        /** Udava kolko pacientov je za den ocakavanych. Pouziva sa pri vypocte pravdepodobnosti, ci sa agent na ockovanie dostavi alebo nie.*/
        public int PatientGenerated { get; set; } = 540;
        /** 
         * Komponenty simulacie. Nachadza sa tu zdroj pacientov, obsluha predstavujuca registraciu, obsluha predstavujuca vysetrenie a obsluha predstavujuca ockovanie. Dalej je tu 
         * este komponent delay, ktory reprezentuje cakarane a komponent sink.
         */
        public SourceComponent<Patient> PatientSource { get; private set; }
        public ServiceComponent AdminService { get; private set; }
        public ServiceComponent ExaminationService { get; private set; }
        public ServiceComponent VaccinationService { get; private set; }
        public DelayComponent WaitingRoomDelay { get; private set; }
        public SinkComponent PatientSink { get; private set; }

        // Statistiky
        // Administracia
        /** Statistiky, ktore sa pocas priebehu simulacie zbieraju.*/
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

        /** Generatory pcotu pacientov, ktori sa nedostavia a generator, ktori urci, ci sa dany pacient nedostavi alebo dostavi.*/
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

            /** Nastavenie generatora a priradenie funkcii, ktore maju byt vykonane pri urcitych udalostiach v ramci komponentu.*/
            ExaminationService = new ServiceComponent(this, new ExponentialDistribution(260), 6);
            ExaminationService.OnEnter = ExaminationOnEnter;
            ExaminationService.OnEnterDelay = ExaminationOnEnterDelay;
            AdminService.NextComponent = ExaminationService;

            /** Nastavenie generatora a priradenie funkcii, ktore maju byt vykonane pri urcitych udalostiach v ramci komponentu.*/
            VaccinationService = new ServiceComponent(this, new TriangularDistribution(20, 100, 75), 3);
            VaccinationService.OnEnter = VaccinationOnEnter;
            VaccinationService.OnEnterDelay = VaccinationOnEnterDelay;
            ExaminationService.NextComponent = VaccinationService;

            /** Nastavenie generatora a priradenie funkcii, ktore maju byt vykonane pri urcitych udalostiach v ramci komponentu.*/
            WaitingRoomDelay = new DelayComponent(this, new DiscreteDistribution(new double[] { 0.95, 0.05 }, new double[] { 15 * 60, 30 * 60 }), int.MaxValue);
            WaitingRoomDelay.OnEnter = WaitingRoomOnEnter;
            WaitingRoomDelay.OnExit = WaitingRoomOnExit;
            VaccinationService.NextComponent = WaitingRoomDelay;

            PatientSink = new SinkComponent(this);
            WaitingRoomDelay.NextComponent = PatientSink;

            /** Naplnenie manazera komponentov.*/
            SimulationComponentsManager.Source = PatientSource;
            SimulationComponentsManager.ServiceComponents = new ServiceComponent[] { AdminService, ExaminationService, VaccinationService };
            SimulationComponentsManager.DelayComponents = new DelayComponent[] { WaitingRoomDelay};
            SimulationComponentsManager.Sink = PatientSink;
            SimulationComponentsManager.Statistics = new BaseStatistic[] {StatAdminQLength, StatAdminWaitingTime, StatExaminationQLength, StatExaminationWaitingTime,
                                                                   StatVaccinationQLength, StatVaccinationWaitingTime, StatWaitingRoomCapacity};

            int noStatistics = SimulationComponentsManager.ServiceComponents.Length + SimulationComponentsManager.Statistics.Length;
            ReplicationResults = new ReplicationsResults();
            ReplicationResults.CurrentReplications = 0;
            /** Vytvorenie skupiny vysledkov pre administrativnu fazu.*/
            ResultGroup adminStatGroup = new ResultGroup(new BaseResults[] {StatAdminQLength.ReplicationResults, 
                                                                            StatAdminWaitingTime.ReplicationResults,
                                                                            AdminService.ResourcePool.ReplicationResults});
            /** Ulozenie urcitych vysledkov pod klucove nazvy.*/
            adminStatGroup["QLengthStat"] = StatAdminQLength.ReplicationResults;
            adminStatGroup["WTimeStat"] = StatAdminWaitingTime.ReplicationResults;
            adminStatGroup["ResPool"] = AdminService.ResourcePool.ReplicationResults;
            /** Vytvorenie skupiny vysledkov pre */
            ResultGroup examinationStatGroup = new ResultGroup(new BaseResults[] {StatExaminationQLength.ReplicationResults,
                                                                                  StatExaminationWaitingTime.ReplicationResults,
                                                                                  ExaminationService.ResourcePool.ReplicationResults});
            /** Ulozenie urcitych vysledkov pod klucove nazvy.*/
            examinationStatGroup["QLengthStat"] = StatExaminationQLength.ReplicationResults;
            examinationStatGroup["WTimeStat"] = StatExaminationWaitingTime.ReplicationResults;
            examinationStatGroup["ResPool"] = ExaminationService.ResourcePool.ReplicationResults;
            /** Vytvorenie skupiny vysledkov pre */
            ResultGroup vaccinationStatGroup = new ResultGroup(new BaseResults[] {StatVaccinationQLength.ReplicationResults,
                                                                                  StatVaccinationWaitingTime.ReplicationResults,
                                                                                  VaccinationService.ResourcePool.ReplicationResults});
            /** Ulozenie urcitych vysledkov pod klucove nazvy.*/
            vaccinationStatGroup["QLengthStat"] = StatVaccinationQLength.ReplicationResults;
            vaccinationStatGroup["WTimeStat"] = StatVaccinationWaitingTime.ReplicationResults;
            vaccinationStatGroup["ResPool"] = VaccinationService.ResourcePool.ReplicationResults;
            /** Vytvorenie skupiny vysledkov pre */
            ResultGroup delayStatGroup = new ResultGroup(new BaseResults[] {StatWaitingRoomCapacity.ReplicationResults});

            delayStatGroup["StatCapacity"] = StatWaitingRoomCapacity.ReplicationResults;

            ReplicationResults.ResultGroups = new ResultGroup[] { adminStatGroup, examinationStatGroup, vaccinationStatGroup, delayStatGroup };
            /** Namapovanie urcitych vysledkov na kluce.*/
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
        }

        override
        public void BeforeReplication()
        {
            Patient.ResetGlobalID();
            base.BeforeReplication();
            _numberOfNotComing = _notCommingGenerator.Next(5, 25);
        }

        /** Metoda, ktora sa vykona pri vstupe pacienta do komponentu service predstavujuceho registraciu.*/
        private int AdminOnEnter(DelayComponent self, Agent agent)
        {
            var service = (ServiceComponent)self;
            var patient = (Patient)agent;
            patient.AdminEnterTime = CurrentTime;
            StatAdminQLength.Add(service.QueueSize, CurrentTime);
            return 0;
        }
        /** Metoda, ktora sa vykona pri zacati obsluhy pacienta v komponente service predsavjuci registraciu.*/
        private int AdminOnEnterDelay(ServiceComponent self, Agent agent)
        {
            var patient = (Patient)agent;
            StatAdminQLength.Add(self.QueueSize, CurrentTime);
            StatAdminWaitingTime.Add((CurrentTime - patient.AdminEnterTime) / 60);
            return 0;
        }
        /** Metoda, ktora sa vykona pri vstupe pacienta do komponentu service predstavujuceho vysetrenie.*/
        private int ExaminationOnEnter(DelayComponent self, Agent agent)
        {
            var service = (ServiceComponent)self;
            var patient = (Patient)agent;
            patient.ExaminationEnterTime = CurrentTime;
            StatExaminationQLength.Add(service.QueueSize, CurrentTime);
            return 0;
        }
        /** Metoda, ktora sa vykona pri zacati obsluhy pacienta v komponente service predsavjuci vysetrenie.*/
        private int ExaminationOnEnterDelay(ServiceComponent self, Agent agent)
        {
            var patient = (Patient)agent;
            StatExaminationQLength.Add(self.QueueSize, CurrentTime);
            StatExaminationWaitingTime.Add((CurrentTime - patient.ExaminationEnterTime) / 60);
            return 0;
        }
        /** Metoda, ktora sa vykona pri vstupe pacienta do komponentu service predstavujuceho ockovanie.*/
        private int VaccinationOnEnter(DelayComponent self, Agent agent)
        {
            var service = (ServiceComponent)self;
            var patient = (Patient)agent;
            patient.VaccinationEnterTime = CurrentTime;
            StatVaccinationQLength.Add(service.QueueSize, CurrentTime);
            return 0;
        }
        /** Metoda, ktora sa vykona pri zacati obsluhy pacienta v komponente service predsavjuci ockovnie.*/
        private int VaccinationOnEnterDelay(ServiceComponent self, Agent agent)
        {
            var patient = (Patient)agent;
            StatVaccinationQLength.Add(self.QueueSize, CurrentTime);
            StatVaccinationWaitingTime.Add((CurrentTime - patient.VaccinationEnterTime) / 60);
            return 0;
        }
        /** Metoda, ktora sa vykona pri vstupe pacienta do cakarne.*/
        private int WaitingRoomOnEnter(DelayComponent self, Agent agent)
        {
            StatWaitingRoomCapacity.Add(self.CurrentlyUsed, CurrentTime);
            return 0;
        }
        /** Metoda, ktora sa vykona pri odchode pacienta z cakarne.*/
        private int WaitingRoomOnExit(DelayComponent self, Agent agent)
        {
            StatWaitingRoomCapacity.Add(self.CurrentlyUsed, CurrentTime);
            return 0;
        }
        /** Funkcia pre custom generator, ktora je pouzita v zdroji a generuje casy prichodu agentov podla urcitych pravidiel.*/
        private double SourceGeneratorFunction()
        {
            int multiplier = 1;
            while(true)
            {
                if (_sourceArrivalGenerator.NextDouble() < ((double)_numberOfNotComing / PatientGenerated))
                    ++multiplier;
                else
                    break;
            }

            return multiplier * SourceInterval;
        }

        /** Nastavi seedy pre vsetky generatory, ktore su v priebehu simulacie vyuzivane.*/
        override
        protected void SeedIt()
        {
            _sourceArrivalGenerator = new Random(SeedGenerator.Next());
            _notCommingGenerator = new Random(SeedGenerator.Next());
            base.SeedIt();
        }
        /** Naplanuje prvu udalost.*/
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
