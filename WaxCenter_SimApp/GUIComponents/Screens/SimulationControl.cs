using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaxCenter_SimApp.GUIComponents.SimComponents;
using WaxCenter_SimApp.GUIComponents.SimComponents.GUISimComponentsWrapper;
using WaxCenter_SimApp.Model.Simulation.GUIData;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.SimulationComponentsWrapper;

namespace WaxCenter_SimApp.GUIComponents.Screens
{
    public partial class SimulationControl : UserControl
    {
        public AppGUI AppGUI { get; set; }
        //public SimulationComponentsManager ComponentsManager { get; set; }
        public GUISimulationComponentsManager GUISimComponentManager { get; private set; } = new GUISimulationComponentsManager();
        public SimulationControl()
        {
            InitializeComponent();
            GUISimComponentManager.GSimSource = PatientSource;
            GUISimComponentManager.GSimServices = new SimService[] { ServiceAdministracia, ServiceExamination, ServiceVaccination };
            GUISimComponentManager.GSimDelays = new SimDelay[] { DelayWaitingRoom };
            GUISimComponentManager.GSimResourcePools = new SimResourcePool[] { ResPoolAdmin, ResPoolDoctor, ResPoolNurse };
            GUISimComponentManager.GSimSink = PatientSink;
            GUISimComponentManager.GSimStats = new SimStats[] {StatAdminQLength, StatAdminWaitingTime, StatExaminationQlength, StatExaminationWaitingTime,
                                                               StatVaccinationQlength, StatVaccinationWaitingTime, StatWaitingRoomCapacity};

            GUISimComponentManager.SetSimulationControlForComponents(this);
            this.SimulationClock.SimulationControl = this;
            
            this.SetToDefault();
        }

        public void HandleComponentSelect(ISimComponent selectedComponent)
        {
            //Console.WriteLine($"Type {selectedComponent.SimComponentType.ToString()} ID: {selectedComponent.ID}");
            AppGUI.HandleGUIComponentSelect(selectedComponent);
            //GUIApp.Spracuj();
        }

        public void StartButtonClick()
        {
            AppGUI.StartPauseRealTimeSimulation();
        }

        public void SetClockValue(string text)
        {
            SimulationClock.ClockText = text;
        }

        public void SimulationSpeedChange(int speedIndex)
        {
            AppGUI.ChangeSimulationSpeed(speedIndex);
        }

        public void SetStartPauseButtonText(string text)
        {
            SimulationClock.StartPauseButtonText = text;
        }

        public void SetToDefault()
        {
            SimulationClock.StartPauseButtonText = "Start";
            SimulationClock.StartPauseButtonEnabled = true;
            SimulationClock.StopButtonEnabled = false;
        }
        
        public void SetStartSimulationSettings()
        {
            SimulationClock.StartPauseButtonText = "Pause";
            SimulationClock.StopButtonEnabled = true;
            SimulationClock.StartPauseButtonEnabled = true;
        }
        public void SetPauseSimulationSettings()
        {
            SimulationClock.StartPauseButtonText = "Continue";
            SimulationClock.StopButtonEnabled = true;
            SimulationClock.StartPauseButtonEnabled = true;
        }
        public void SetContinueSimulationSettings()
        {
            SimulationClock.StartPauseButtonText = "Pause";
            SimulationClock.StopButtonEnabled = true;
            SimulationClock.StartPauseButtonEnabled = true;
        }
        public void SimulationStopSignal()
        {
            AppGUI.RealTimeSimulationStopSignal();
        }

        public void DisableButtons()
        {
            SimulationClock.StartPauseButtonEnabled = false;
            SimulationClock.StopButtonEnabled = false;
        }

        public void UpdateValues()
        {

            GUISimComponentManager.GSimSource.UpdateAccordingToState();
            //PatientSource.UpdateAccordingToState(GUIData.SourceStateData);
            foreach (var guiService in GUISimComponentManager.GSimServices)
                guiService.UpdateAccordingToState();

            foreach (var resPool in GUISimComponentManager.GSimResourcePools)
                resPool.UpdateAccordingToState();

            foreach (var delay in GUISimComponentManager.GSimDelays)
                delay.UpdateAccordingToState();

            foreach (var stat in GUISimComponentManager.GSimStats)
                stat.UpdateAccordingToState();
            
            GUISimComponentManager.GSimSink.UpdateAccordingToState();
        }

    }
}
