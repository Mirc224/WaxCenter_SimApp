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
using WaxCenter_SimApp.Model.Simulation.GUIData;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;

namespace WaxCenter_SimApp
{
    public partial class AppGUI : Form
    {
        private Controller.Controller _controller;
        public AppGUI()
        {
            InitializeComponent();
            this.SimulationControlScreen.AppGUI = this;
            _controller = new Controller.Controller(this, SimulationControlScreen);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SimulationControlScreen.Hide();
            //ReplicationControlScreen.Hide();
        }

        private void ShowSimulationButton_Click(object sender, EventArgs e)
        {
            //SimulationControlScreen.Show();
            //ReplicationControlScreen.Hide();

        }

        private void ShowReplicationButton_Click(object sender, EventArgs e)
        {
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
                if (_controller.SimulationStatus == EventSimulationCore.SimulationStatus.FINISHED || _controller.SimulationStatus == EventSimulationCore.SimulationStatus.CANCELED)
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
            if(_controller.SimulationStatus == EventSimulationCore.SimulationStatus.PAUSED)
            {
                RealTimeSimulationWorker.ReportProgress((int)UpdateDataType.SIMULATION_CONTINUE);
            }
            else
            {
                RealTimeSimulationWorker.ReportProgress((int)UpdateDataType.SIMULATION_START);
            }
            if (!_controller.RunRealTimeSimulation(RealTimeSimulationWorker))
            {
                e.Cancel = true;
            }
        }

        public void ChangeSimulationSpeed(int speedIndex)
        {
            _controller.SetSimulationSpeed(speedIndex);
        }

        private void RealTimeSimulationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_controller.SimulationStatus != EventSimulationCore.SimulationStatus.FINISHED)
            {
                if(_controller.SimulationStatus == EventSimulationCore.SimulationStatus.PAUSED)
                {
                    _controller.PauseClicked = false;
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
            _controller.AfterRealTimeSimulationStopped();
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
            _controller.PauseClicked = false;
            //_controller.ResetRealTimeSimulation();
            //SimulationControlScreen.SetStartSimulationSettings();
            //SimulationControlScreen.DisableButtons();
            _controller.ResetRealTimeSimulation();
            RealTimeSimulationWorker.RunWorkerAsync();
        }

        private void PauseSimulation()
        {
            _controller.PauseClicked = true;
            SimulationControlScreen.DisableButtons();
            RealTimeSimulationWorker.CancelAsync();
        }

        private void SetRealTimeToDefault()
        {
            this.SimulationControlScreen.SetToDefault(); 
        }
    }
}
