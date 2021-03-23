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
using WaxCenter_SimApp.Model.Simulation.GUIData;

namespace WaxCenter_SimApp.GUIComponents.Screens
{
    public partial class SimulationControl : UserControl
    {
        public AppGUI AppGUI { get; set; }
        public GUIDataValues GUIData { get; set; }
        public SimulationControl()
        {
            InitializeComponent();

            this.StatAvgNOWaiting.SimulationControl = this;
            this.StatVaccinateQlength.SimulationControl = this;
            this.StatVaccinateWaitingTime.SimulationControl = this;
            this.StatCheckWaitingTime.SimulationControl = this;
            this.StatCheckQlength.SimulationControl = this;
            this.StatAdminQLength.SimulationControl = this;
            this.StatAdminWaitingTime.SimulationControl = this;
            this.ResPoolNurse.SimulationControl = this;
            this.ResPoolDoctor.SimulationControl = this;
            this.ResPoolAdmin.SimulationControl = this;
            this.DelaySelect.SimulationControl = this;
            this.ExitSink.SimulationControl = this;
            this.PatientSource.SimulationControl = this;
            this.DelayCakaren.SimulationControl = this;
            this.ServiceOckovanie.SimulationControl = this;
            this.ServiceVysetrenie.SimulationControl = this;
            this.ServiceAdministracia.SimulationControl = this;
            this.SimulationClock.SimulationControl = this;
            
            this.SetToDefault();
        }

        public void HandleComponentSelect(ISimComponent selectedComponent)
        {
            Console.WriteLine($"Type {selectedComponent.SimComponentType.ToString()} ID: {selectedComponent.ID}");
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
            CustomersSource.CounterText = GUIData.SourceOutput.ToString();
            PredajService.QueueText = GUIData.ServiceQueueActualLength.ToString();
            PredajService.DelayText = GUIData.CurrentlyUsedService.ToString();
            PredajService.InputText = GUIData.ServiceInput.ToString();
            PredajService.OutputText = GUIData.ServiceOutput.ToString();
            CustomerSink.CounterText = GUIData.SinkInput.ToString();
            NewsPaperResPool.StaffUsedText = $"{GUIData.MaxService - GUIData.CurrentlyUsedService}/{GUIData.MaxService}";
            CakanieStat.ValueText = $"[{GUIData.MinWaitingTime.ToString("F")}..{GUIData.MaxWaitingTime.ToString("F")}] Mean: {GUIData.AverageWaitingTime}";
            DlzkaStat.ValueText = $"[{GUIData.MinQLength}..{GUIData.MaxQLength}] Mean: {GUIData.AverageQLength}";
        }

    }
}
