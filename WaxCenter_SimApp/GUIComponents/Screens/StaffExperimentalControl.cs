using OxyPlot.Axes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaxCenter_SimApp.Controller;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results;

namespace WaxCenter_SimApp.GUIComponents.Screens
{
    public partial class StaffExperimentalControl : UserControl
    {
        public AutoResetEvent WaitHandle { get; set; }
        public AppGUI AppGUI { get; set; }
        public ReplicationsResults ReplicationResults { get; set; }
        public bool ValuesProcessed { get; set; } = true;
        public OxyPlot.Series.LineSeries _currentLineSeries;
        public StaffExperimentalControl()
        {
            InitializeComponent();
            SetToDefault();
        }

        public void Initialize()
        {
            DependenceGraph.Model = new OxyPlot.PlotModel { Title = "Mean examination queue length" };
            var linearAxis1 = new LinearAxis();
            linearAxis1.MajorGridlineStyle = OxyPlot.LineStyle.Solid;
            linearAxis1.MinorGridlineStyle = OxyPlot.LineStyle.Dot;
            linearAxis1.Position = AxisPosition.Bottom;
            DependenceGraph.Model.Axes.Add(linearAxis1);

            var linearAxis2 = new LinearAxis();
            linearAxis2.MajorGridlineStyle = OxyPlot.LineStyle.Solid;
            linearAxis2.MinorGridlineStyle = OxyPlot.LineStyle.Dot;
            DependenceGraph.Model.Axes.Add(linearAxis2);

            DependenceGraph.Model.ResetAllAxes();
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

            int adminMaxStaff = adminResPool.ResourcePool.MaxStaff;
            double adminUtilization = adminResPool.Utilization / ReplicationResults.CurrentReplications;
            double adminQLength = ((StatResults)adminStatGroup["QLengthStat"]).MeanSum / ReplicationResults.CurrentReplications;
            double adminWTime = ((StatResults)adminStatGroup["WTimeStat"]).MeanSum / ReplicationResults.CurrentReplications;

            int examMaxStaff = examResPool.ResourcePool.MaxStaff;
            double doctorUtilization = examResPool.Utilization / ReplicationResults.CurrentReplications;
            double doctorQLength = ((StatResults)examinationStatGroup["QLengthStat"]).MeanSum / ReplicationResults.CurrentReplications;
            double doctorWTime = ((StatResults)examinationStatGroup["WTimeStat"]).MeanSum / ReplicationResults.CurrentReplications;

            int vaccMaxStaff = vaccResPool.ResourcePool.MaxStaff;
            double nurseUtilization = vaccResPool.Utilization / ReplicationResults.CurrentReplications; ;
            double nurseQLength = ((StatResults)vaccinationStatGroup["QLengthStat"]).MeanSum / ReplicationResults.CurrentReplications;
            double nurseWTime = ((StatResults)vaccinationStatGroup["WTimeStat"]).MeanSum / ReplicationResults.CurrentReplications;

            double wRoomCapacity = ((StatResults)delayStatGroup["StatCapacity"]).MeanSum / ReplicationResults.CurrentReplications;

            _currentLineSeries.Points.Add(new OxyPlot.DataPoint(examMaxStaff, doctorQLength));
            ValuesProcessed = true;
            WaitHandle.Set();

            ExperimentResultsGridView.Rows.Add(new string[] { adminMaxStaff.ToString(),
                                                              adminUtilization.ToString(),
                                                              adminQLength.ToString(),
                                                              adminWTime.ToString(),
                                                              examMaxStaff.ToString(),
                                                              doctorUtilization.ToString(),
                                                              doctorQLength.ToString(),
                                                              doctorWTime.ToString(),
                                                              vaccMaxStaff.ToString(),
                                                              nurseUtilization.ToString(),
                                                              nurseQLength.ToString(),
                                                              nurseWTime.ToString(),
                                                              wRoomCapacity.ToString()
                                                              });
            RedrawGraph();
        }

        public void RedrawGraph()
        {
            DependenceGraph.InvalidatePlot(true);
        }

        public void ClearGraphSeries()
        {
            DependenceGraph.Model.Series.Clear();
        }

        public void Reset()
        {
            ProgressBar.Value = 0;
            ExperimentResultsGridView.Rows.Clear();
            RedrawGraph();
        }

        public void AddNewSeries(string title)
        {
            _currentLineSeries = new OxyPlot.Series.LineSeries { Title = title };
            DependenceGraph.Model.Series.Add(_currentLineSeries);
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
