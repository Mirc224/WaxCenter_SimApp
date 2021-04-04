using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaxCenter_SimApp.Controller;
using WaxCenter_SimApp.GUIComponents.OptionsComponents;
using WaxCenter_SimApp.GUIComponents.SimComponents;
using WaxCenter_SimApp.GUIComponents.SimComponents.GUISimComponentsWrapper;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.SimulationComponentsWrapper;

namespace WaxCenter_SimApp.GUIComponents.Screens
{
    public partial class SimulationControl : UserControl
    {
        public AppGUI AppGUI { get; set; }
        public bool PauseClicked { get; private set; }
        private ISimComponent _selectedComponent;
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
            ResPoolOptions.SimulationControl = this;
            SourceOptions.SimulationControl = this;
            this.SetToDefault();
            HideAllComponentOptions();
        }

        private void HideAllComponentOptions()
        {
            ResPoolOptions.Hide();
            SourceOptions.Hide();
        }
            public void HandleComponentSelect(ISimComponent selectedComponent)
        {
            //Console.WriteLine($"Type {selectedComponent.SimComponentType.ToString()} ID: {selectedComponent.ID}");
            _selectedComponent = selectedComponent;

            HideAllComponentOptions();
            switch (selectedComponent.SimComponentType)
            {
                case SimComponentType.SOURCE:
                    _selectedComponent = selectedComponent;
                    AppGUI.Controller.HandleGUIComponentSelection(_selectedComponent, SourceOptions);
                    SourceOptions.Show();
                    break;
                case SimComponentType.RESOURCEPOOL:
                    _selectedComponent = selectedComponent;
                    ResPoolOptions.SelectedText = selectedComponent.TitleText;
                    AppGUI.Controller.HandleGUIComponentSelection(_selectedComponent, ResPoolOptions);
                    ResPoolOptions.Show();
                    break;
                default:
                    break;
            }

            //AppGUI.HandleGUIComponentSelect(selectedComponent);
            //GUIApp.Spracuj();
        }

        public void HandleComponentOptionsConfirmSignal(IGUIOptions optionsGUI)
        {
            switch (optionsGUI.OptionsType)
            {
                case GUIOptionsType.SOURCE:
                    AppGUI.Controller.HandleGUIComponentOptionsConfirmation(_selectedComponent, optionsGUI);
                    break;
                case GUIOptionsType.RESPOOL:
                    AppGUI.Controller.HandleGUIComponentOptionsConfirmation(_selectedComponent, optionsGUI);
                    break;
                default:
                    break;
            }
            AppGUI.Controller.ResetRealTimeSimulation();
        }

        public void StartButtonClick()
        {
            StartPauseRealTimeSimulation();
        }

        public void StartPauseRealTimeSimulation()
        {
            if (!RealTimeSimulationWorker.IsBusy)
            {
                if (AppGUI.Controller.RealTimeSimulationStatus == SimulationStatus.FINISHED ||
                    AppGUI.Controller.RealTimeSimulationStatus == SimulationStatus.CANCELED)
                {
                    StartSimulation();
                }
                else
                    ContinueSimulation();
            }
            else
            {
                PauseSimulation();
            }

        }

        private void ContinueSimulation()
        {
            DisableButtons();
            RealTimeSimulationWorker.RunWorkerAsync();
        }

        public void ChangeSimulationSpeed(int speedIndex)
        {
            AppGUI.Controller.SetSimulationSpeed(speedIndex);
        }

        private void StartSimulation()
        {
            PauseClicked = false;
            AppGUI.Controller.ResetRealTimeSimulation();
            RealTimeSimulationWorker.RunWorkerAsync();
        }
        private void PauseSimulation()
        {
            PauseClicked = true;
            DisableButtons();
            RealTimeSimulationWorker.CancelAsync();
        }

        public void SetClockValue(string text)
        {
            SimulationClock.ClockText = text;
        }

        public void SimulationSpeedChange(int speedIndex)
        {
            ChangeSimulationSpeed(speedIndex);
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
            RealTimeSimulationStopSignal();
        }

        public void RealTimeSimulationStopSignal()
        {
            if (RealTimeSimulationWorker.IsBusy)
            {
                this.RealTimeSimulationWorker.CancelAsync();
            }
            else
            {
                AfterRealTimeSimulationStopped();
            }
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

        private void RealTimeSimulationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (AppGUI.Controller.RealTimeSimulationStatus == SimulationStatus.PAUSED)
            {
                RealTimeSimulationWorker.ReportProgress((int)RealTimeUpdateDataType.SIMULATION_CONTINUE);
            }
            else
            {
                RealTimeSimulationWorker.ReportProgress((int)RealTimeUpdateDataType.SIMULATION_START);
            }
            if (!AppGUI.Controller.RunRealTimeSimulation(RealTimeSimulationWorker))
            {
                e.Cancel = true;
            }
        }

        private void RealTimeSimulationWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch ((RealTimeUpdateDataType)e.ProgressPercentage)
            {
                case RealTimeUpdateDataType.SIMULATION_START:
                    this.SetStartSimulationSettings();
                    break;
                case RealTimeUpdateDataType.SIMULATION_CONTINUE:
                    this.SetContinueSimulationSettings();
                    break;
                case RealTimeUpdateDataType.CLOCK_DATA:
                    var data = (ClockUpdateData)e.UserState;
                    this.SetClockValue(data.CurrentTime);
                    break;
                case RealTimeUpdateDataType.SIMULATION_DATA:
                    this.UpdateValues();
                    break;
                default:
                    break;
            }
        }

        private void RealTimeSimulationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AppGUI.Controller.RealTimeSimulationStatus != SimulationStatus.FINISHED)
            {
                if (AppGUI.Controller.RealTimeSimulationStatus == SimulationStatus.PAUSED)
                {
                    PauseClicked = false;
                    SetPauseSimulationSettings();
                }
                else
                {
                    AfterRealTimeSimulationStopped();
                }
            }
            else
            {
                SetToDefault();
            }
        }

        private void AfterRealTimeSimulationStopped()
        {
            AppGUI.Controller.AfterRealTimeSimulationStopped();
            SetToDefault();
        }

        public void SetClockTicks(int ticks)
        {
            SimulationClock.SetSpeedSlider(ticks);
        }

        internal void Reset()
        {
            UpdateValues();
        }
    }
}
