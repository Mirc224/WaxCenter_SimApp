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
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results;

namespace WaxCenter_SimApp.GUIComponents.Screens
{
    public partial class StaffExperimentalControl : UserControl
    {
        public AppGUI AppGUI { get; set; }
        public ReplicationsResults ReplicationResults { get; set; }
        public StaffExperimentalControl()
        {
            InitializeComponent();
            SetToDefault();
        }

        public void Initialize()
        {
            DependenceGraph.Model = new OxyPlot.PlotModel { Title = "Mean examination queue length" };
        }

        public void UpdateValues()
        {

            var adminStatGroup = ReplicationResults["AdminGroup"];
            var examinationStatGroup = ReplicationResults["ExaminationGroup"];
            var vaccinationStatGroup = ReplicationResults["VaccinationGroup"];
            var delayStatGroup = ReplicationResults["DelayGroup"];

            var adminResPool = (ResourcePoolResults)adminStatGroup["ResPool"];
            var examResPool = (ResourcePoolResults)examinationStatGroup["ResPool"];
            var vaccResPool = (ResourcePoolResults)vaccinationStatGroup["ResPool"];

            ExperimentResultsGridView.Rows.Add(new string[] { adminResPool.ResourcePool.MaxStaff.ToString(),
                                                              (adminResPool.Utilization / ReplicationResults.CurrentReplications).ToString(),
                                                              (((StatResults)adminStatGroup["QLengthStat"]).Mean/ReplicationResults.CurrentReplications).ToString(),
                                                              (((StatResults)adminStatGroup["WTimeStat"]).Mean/ReplicationResults.CurrentReplications).ToString(),
                                                              examResPool.ResourcePool.MaxStaff.ToString(),
                                                              (examResPool.Utilization / ReplicationResults.CurrentReplications).ToString(),
                                                              (((StatResults)examinationStatGroup["QLengthStat"]).Mean/ReplicationResults.CurrentReplications).ToString(),
                                                              (((StatResults)examinationStatGroup["WTimeStat"]).Mean/ReplicationResults.CurrentReplications).ToString(),
                                                              vaccResPool.ResourcePool.MaxStaff.ToString(),
                                                              (vaccResPool.Utilization / ReplicationResults.CurrentReplications).ToString(),
                                                              (((StatResults)vaccinationStatGroup["QLengthStat"]).Mean/ReplicationResults.CurrentReplications).ToString(),
                                                              (((StatResults)vaccinationStatGroup["WTimeStat"]).Mean/ReplicationResults.CurrentReplications).ToString(),
                                                              (((StatResults)delayStatGroup["StatCapacity"]).Mean/ReplicationResults.CurrentReplications).ToString()
                                                              });
        }

        public void Reset()
        {
            ExperimentResultsGridView.Rows.Clear();
        }

        private void StartPauseButton_Click(object sender, EventArgs e)
        {
            if (!ExperimentalWorker.IsBusy)
            {
                if (AppGUI.Controller.ExperimentalSimulationStatus == SimulationStatus.FINISHED ||
                    AppGUI.Controller.ExperimentalSimulationStatus == SimulationStatus.CANCELED)
                {
                    StartSimulation();
                    SetStartSimulationSettings();
                }
            }
        }

        private void ExperimentalWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!AppGUI.Controller.RunExperimentalSimulation(ExperimentalWorker))
            {
                e.Cancel = true;
            }
        }
        private void ExperimentalWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var dataType = (ProgressUpdateType)e.ProgressPercentage;
            ExperimentalUpdateData data;
            switch (dataType)
            {
                case ProgressUpdateType.SIMULATION_START:
                    data = (ExperimentalUpdateData)e.UserState;
                    Reset();
                    ProgressBar.Value = data.Progress;
                    break;
                case ProgressUpdateType.SIMULATION_PROGRESS:
                    data = (ExperimentalUpdateData)e.UserState;
                    ProgressBar.Value = data.Progress;
                    break;
                case ProgressUpdateType.SIMULATION_DATA:
                    data = (ExperimentalUpdateData)e.UserState;
                    ProgressBar.Value = data.Progress;
                    UpdateValues();
                    break;
                default:
                    break;
            }
        }

        private void ExperimentalWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AppGUI.Controller.ReplicationsSimulationStatus != SimulationStatus.FINISHED)
            {
                AfterExperimentalSimulationStopped();
            }
            else
            {
                SetToDefault();
            }
        }


        private void AfterExperimentalSimulationStopped()
        {
            AppGUI.Controller.AfterExperimentalSimulationStopped();
            SetToDefault();
        }

        private void SetToDefault()
        {
            StartPauseButton.Text = "Start";
            StartPauseButton.Enabled = true;
            StopButton.Enabled = false;
        }

        private void StartSimulation()
        {
            AppGUI.Controller.ResetReplicationsSimulation();
            ExperimentalWorker.RunWorkerAsync();
        }

        private void SetStartSimulationSettings()
        {
            SetContinueSimulationSettings();
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
        public void DisableButtons()
        {
            StartPauseButton.Enabled = false;
            StopButton.Enabled = false;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (ExperimentalWorker.IsBusy)
            {
                ExperimentalWorker.CancelAsync();
            }
            else
            {
                AfterExperimentalSimulationStopped();
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            AppGUI.Controller.TryParseAndApplyExperimentalOptions();
        }
    }
}
