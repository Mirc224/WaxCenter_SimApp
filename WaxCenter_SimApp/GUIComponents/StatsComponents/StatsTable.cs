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

namespace WaxCenter_SimApp.GUIComponents.StatsComponents
{
    public partial class StatsTable : UserControl
    {
        public ResultGroup ResultGroup { get; set; }
        public StatsTable()
        {
            InitializeComponent();
        }

        public void CreateRows()
        {
            if (ResultGroup != null)
            {
                StatGridView.Rows.Clear();
                foreach(var Result in ResultGroup.GroupResults)
                {
                    for (int i = 0; i < Result.Names.Length; ++i)
                    {
                        StatGridView.Rows.Add(new string[] { Result.Names[i], 
                            (ResultGroup.ReplicationsResult.CurrentReplications == 0 ? 
                            "0" : string.Format("{0:0.####}", Result.Values[i]/ResultGroup.ReplicationsResult.CurrentReplications))});
                    }
                }
            }
        }

        public void UpdateValues()
        {
            if (ResultGroup != null)
            {
                int index = 0;
                foreach (var Result in ResultGroup.GroupResults)
                {
                    for (int i = 0; i < Result.Names.Length; ++i)
                    {
                        var dataRow = StatGridView.Rows[index++];
                        dataRow.Cells[1].Value = (ResultGroup.ReplicationsResult.CurrentReplications == 0 ?
                                                  "0" : string.Format("{0:0.####}", Result.Values[i] / ResultGroup.ReplicationsResult.CurrentReplications));
                    }
                }
            }
        }
    }
}
