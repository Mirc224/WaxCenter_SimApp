using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaxCenter_SimApp.GUIComponents.StatsComponents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Results;

namespace WaxCenter_SimApp.GUIComponents.Screens
{
    public partial class ReplicationControl : UserControl
    {
        public AppGUI AppGUI { get; set; }

        private ReplicationsResults _replicationsResults;

        private StatsTable[] _statsTables;
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

        public void UpdateStatTables()
        {
            foreach (var stat in _statsTables)
                stat.UpdateValues();
        }

        private void RunReplicationButton_Click(object sender, EventArgs e)
        {
            AppGUI.SignalRunPauseReplications();
        }
    }
}
