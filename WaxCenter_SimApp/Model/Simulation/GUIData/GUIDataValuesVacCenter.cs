using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.ComponentValuesClasses;
using WaxCenter_SimApp.Model.Simulation.VaccinationCenter;

namespace WaxCenter_SimApp.Model.Simulation.GUIData
{
    public class GUIDataValuesVacCenter
    {
        public SourceStateData<Patient> SourceStateData { get => _simulation.PatientSource.StateData; }
        public ServiceStateData ServiceAdminStateData { get => _simulation.AdminService.ServiceStateData; }
        public ServiceStateData ServiceExaminationStateData { get => _simulation.ExaminationService.ServiceStateData; }
        public ServiceStateData ServiceVaccinationStateData { get => _simulation.VaccinationService.ServiceStateData; }
        public DelayStateData DelayWaitingRoomStateData { get => _simulation.WaitingRoomDelay.StateData; }
        public SinkStateData SinkStateData { get => _simulation.PatientSink.StateData; }
        public StatisticStateData StatAdminQLengthStateData { get => _simulation.StatAdminQLength.StateData; }
        public StatisticStateData StatAdminWaitingTStateData { get => _simulation.StatAdminWaitingTime.StateData; }
        public StatisticStateData StatExaminationQLengthStateData { get => _simulation.StatExaminationQLength.StateData; }
        public StatisticStateData StatExaminationWaitingTStateData { get => _simulation.StatExaminationWaitingTime.StateData; }
        public StatisticStateData StatVaccinationQLengthStateData { get => _simulation.StatVaccinationQLength.StateData; }
        public StatisticStateData StatVaccinationWaitingTStateData { get => _simulation.StatVaccinationWaitingTime.StateData; }
        public StatisticStateData StatWaitingRoomCapacityStateData{ get => _simulation.StatWaitingRoomCapacity.StateData; }

        private EventSimCoreVaccinationCenter _simulation;

        public GUIDataValuesVacCenter(EventSimCoreVaccinationCenter simulation)
        {
            _simulation = simulation;
        }
    }
}
