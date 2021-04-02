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
using WaxCenter_SimApp.GUIComponents.StatsComponents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results;

namespace WaxCenter_SimApp.GUIComponents.Screens
{
    public partial class ReplicationControl : UserControl
    {
        public AppGUI AppGUI { get; set; }

        private ReplicationsResults _replicationsResults;

        private StatsTable[] _statsTables;

        public bool PauseClicked { get; set; }
        public ReplicationControl()
        {
            InitializeComponent();
            _statsTables = new StatsTable[] { AdminStats, ExaminationStats, VaccinationStats, WaitingRoomStats};
        }
        public void SetReplicationResults(ReplicationsResults replicationResults)
        {
            _replicationsResults = replicationResults;
            for(int i = 0; i< _replicationsResults.ResultGroups.Length; ++i)
            {
                _statsTables[i].ResultGroup = _replicationsResults.ResultGroups[i];
                _statsTables[i].CreateRows();
            }
        }

        public void RebuildStatTables()
        {
            foreach (var stat in _statsTables)
                stat.CreateRows();
        }

        public void UpdateStatTables()
        {
            foreach (var stat in _statsTables)
                stat.UpdateValues();
        }


        private void RunReplicationButton_Click(object sender, EventArgs e)
        {
            if (!ReplicationsWorker.IsBusy)
            {
                if (AppGUI.Controller.ReplicationsSimulationStatus == SimulationStatus.FINISHED || 
                    AppGUI.Controller.ReplicationsSimulationStatus == SimulationStatus.CANCELED)
                {
                    StartSimulation();
                    SetStartSimulationSettings();
                }
                else
                {
                    ContinueSimulation();
                    SetContinueSimulationSettings();
                }
            }
            else
            {
                PauseSimulation();
            }
        }

        private void StartSimulation()
        {
            PauseClicked = false;
            AppGUI.Controller.ResetReplicationsSimulation();
            ReplicationsWorker.RunWorkerAsync();
        }

        private void ContinueSimulation()
        {
            DisableButtons();
            ReplicationsWorker.RunWorkerAsync();
        }
        private void PauseSimulation()
        {
            PauseClicked = true;
            DisableButtons();
            ReplicationsWorker.CancelAsync();
        }

        public void DisableButtons()
        {
            StartPauseButton.Enabled = false;
            StopButton.Enabled = false;
        }

        private void ReplicationsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!AppGUI.Controller.RunReplicationsWithGUIUpdate(ReplicationsWorker))
            {
                e.Cancel = true;
            }
        }

        private void SetStartSimulationSettings()
        {
            SetContinueSimulationSettings();
        }
        private void SetPauseSimulationSettings()
        {
            StartPauseButton.Text = "Continue";
            EnableButtons();
        }
        private void SetContinueSimulationSettings()
        {
            StartPauseButton.Text = "Pause";
            EnableButtons();
        }

        private void EnableButtons()
        {
            StopButton.Enabled = true;
            StartPauseButton.Enabled = true;
        }

        private void ReplicationsWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var dataType = (ReplicationsUpdateType)e.ProgressPercentage;
            ReplicationsUpdateData data;
            switch (dataType)
            {
                case ReplicationsUpdateType.SIMULATION_START:
                    data = (ReplicationsUpdateData)e.UserState;
                    ProgressBar.Value = data.Progress;
                    RebuildStatTables();
                    break;
                case ReplicationsUpdateType.SIMULATION_DATA:
                    data = (ReplicationsUpdateData)e.UserState;
                    ProgressBar.Value = data.Progress;
                    UpdateStatTables();
                    break;
                default:
                    break;
            }
        }

        private void ReplicationsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AppGUI.Controller.ReplicationsSimulationStatus != SimulationStatus.FINISHED)
            {
                if (AppGUI.Controller.ReplicationsSimulationStatus == SimulationStatus.PAUSED)
                {
                    PauseClicked = false;
                    SetPauseSimulationSettings();
                }
                else
                {
                    AfterReplicationsSimulationStopped();
                }
            }
            else
            {
                SetToDefault();
            }
        }


        private void AfterReplicationsSimulationStopped()
        {
            AppGUI.Controller.AfterReplicationsSimulationStopped();
            SetToDefault();
        }

        private void SetToDefault()
        {
            StartPauseButton.Text = "Start";
            StartPauseButton.Enabled = true;
            StopButton.Enabled = false;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            AppGUI.Controller.TryParseAndApplyReplicationsOptions();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (ReplicationsWorker.IsBusy)
            {
                ReplicationsWorker.CancelAsync();
            }
            else
            {
                AfterReplicationsSimulationStopped();
            }
        }
    }
}
