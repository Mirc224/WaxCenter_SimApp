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
using WaxCenter_SimApp.Model.Simulation.GUIData;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;

namespace WaxCenter_SimApp
{
    public partial class AppGUI : Form
    {

        public Controller.Controller Controller { get; private set; }

        public AppGUI()
        {
            InitializeComponent();
            SimulationControlScreen.AppGUI = this;
            ReplicationControlScreen.AppGUI = this;
            SimulationOptions.AppGUI = this;

            Controller = new Controller.Controller(this, SimulationControlScreen, ReplicationControlScreen, SimulationOptions);
            HideAllScreens();
        }

        private void HideAllScreens()
        {
            SimulationControlScreen.Hide();
            ReplicationControlScreen.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SimulationControlScreen.Hide();
            //ReplicationControlScreen.Hide();
        }

        private void ShowSimulationButton_Click(object sender, EventArgs e)
        {
            HideAllScreens();
            SimulationControlScreen.Show();
            //ReplicationControlScreen.Hide();

        }

        private void ShowReplicationButton_Click(object sender, EventArgs e)
        {
            HideAllScreens();
            ReplicationControlScreen.Show();
            //SimulationControlScreen.Hide();
            //ReplicationControlScreen.Show();
        }

        public void RealTimeSimulationStopSignal()
        {
            if(RealTimeSimulationWorker.IsBusy)
            {
                this.RealTimeSimulationWorker.CancelAsync();
            }
            else
            {
                AfterRealTimeSimulationStopped();
            }
        }

        public void StartPauseRealTimeSimulation()
        {
            if(!RealTimeSimulationWorker.IsBusy)
            {
                if (Controller.SimulationStatus == EventSimulationCore.SimulationStatus.FINISHED || Controller.SimulationStatus == EventSimulationCore.SimulationStatus.CANCELED)
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

        private void RealTimeSimulationWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch((UpdateDataType)e.ProgressPercentage)
            {
                case UpdateDataType.SIMULATION_START:
                    SimulationControlScreen.SetStartSimulationSettings();
                    break;
                case UpdateDataType.SIMULATION_CONTINUE:
                    SimulationControlScreen.SetContinueSimulationSettings();
                    break;
                case UpdateDataType.CLOCK_DATA:
                    var data = (ClockUpdateData)e.UserState;
                    SimulationControlScreen.SetClockValue(data.CurrentTime);
                    break;
                case UpdateDataType.SIMULATION_DATA:
                    SimulationControlScreen.UpdateValues();
                    break;
                default:
                    break;
            }
        }

        private void RealTimeSimulationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if(Controller.SimulationStatus == EventSimulationCore.SimulationStatus.PAUSED)
            {
                RealTimeSimulationWorker.ReportProgress((int)UpdateDataType.SIMULATION_CONTINUE);
            }
            else
            {
                RealTimeSimulationWorker.ReportProgress((int)UpdateDataType.SIMULATION_START);
            }
            if (!Controller.RunRealTimeSimulation(RealTimeSimulationWorker))
            {
                e.Cancel = true;
            }
        }

        public void ChangeSimulationSpeed(int speedIndex)
        {
            Controller.SetSimulationSpeed(speedIndex);
        }

        public void SignalRunPauseReplications()
        {
            if (!ReplicationsWorker.IsBusy)
            {
                ReplicationsWorker.RunWorkerAsync();
                /*if (_controller.SimulationStatus == EventSimulationCore.SimulationStatus.FINISHED || _controller.SimulationStatus == EventSimulationCore.SimulationStatus.CANCELED)
                {
                    //StartSimulation();
                }
                else
                    //ContinueSimulation();*/
            }
            else
            {
                //PauseSimulation();
            }
        }
        public void RunReplications()
        {

        }

        private void RealTimeSimulationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Controller.SimulationStatus != EventSimulationCore.SimulationStatus.FINISHED)
            {
                if(Controller.SimulationStatus == EventSimulationCore.SimulationStatus.PAUSED)
                {
                    Controller.PauseClicked = false;
                    SimulationControlScreen.SetPauseSimulationSettings();
                }
                else
                {
                    AfterRealTimeSimulationStopped();
                }
            }
            else
            {
                AfterRealTimeSimulationCompleted();
            }
        }

        private void AfterRealTimeSimulationStopped()
        {
            Controller.AfterRealTimeSimulationStopped();
            SetRealTimeToDefault();
        }
        private void AfterRealTimeSimulationCompleted()
        {
            SetRealTimeToDefault();
        }

        private void ContinueSimulation()
        {
            SimulationControlScreen.DisableButtons();
            RealTimeSimulationWorker.RunWorkerAsync();
        }

        private void StartSimulation()
        {
            Controller.PauseClicked = false;
            //_controller.ResetRealTimeSimulation();
            //SimulationControlScreen.SetStartSimulationSettings();
            //SimulationControlScreen.DisableButtons();
            Controller.ResetRealTimeSimulation();
            RealTimeSimulationWorker.RunWorkerAsync();
        }

        private void PauseSimulation()
        {
            Controller.PauseClicked = true;
            SimulationControlScreen.DisableButtons();
            RealTimeSimulationWorker.CancelAsync();
        }

        private void SetRealTimeToDefault()
        {
            this.SimulationControlScreen.SetToDefault(); 
        }

        public void SignalBaseOptionsConfirm()
        {
            Controller.TryApplyBaseSimulationSettings();
        }
        private void ReplicationsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Controller.RunReplicationsWithGUIUpdate(ReplicationsWorker);
        }

        private void ReplicationsWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
    }
}
