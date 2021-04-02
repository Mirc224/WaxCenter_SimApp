using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Settings;
using static WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core.EventSimulationCore;

namespace WaxCenter_SimApp.GUIComponents.OptionsComponents
{
    public partial class SimulationOptions : UserControl
    {
        public AppGUI AppGUI { get; set; }
        public SimulationOptions()
        {
            InitializeComponent();
        }

        private void UseSettingsButton_Click(object sender, EventArgs e)
        {
            AppGUI.SignalBaseOptionsConfirm();
        }

        public void PreFillSettings(BaseEventSimulationSettings settings) 
        {
            MaxTimeInput.Text = settings.MaxTime.ToString();
            AfterMaxTimeCheck.Checked = settings.ContinueAfterMaxTime;
            AutoSeedCheckBox.Checked = settings.AutoSeed;
            SeedInput.Text = settings.LastUsedSeed.ToString();
            if (settings.AutoSeed)
                SeedInput.Enabled = false;

            switch(settings.Units)
            {
                case TimeUnits.SECONDS:
                    MaxTimeUnitListBox.SelectedIndex = 0;
                    break;
                case TimeUnits.MINUTES:
                    MaxTimeUnitListBox.SelectedIndex = 1;
                    break;
            }
        }

        private void AutoSeedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(AutoSeedCheckBox.Checked)
                SeedInput.Enabled = false;
            else
                SeedInput.Enabled = true;
        }
    }
}
