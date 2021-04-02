using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            AppGUI.Controller.RunExperimentalSimulation();
        }
    }
}
