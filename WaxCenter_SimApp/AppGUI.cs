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
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core;

namespace WaxCenter_SimApp
{
    public partial class AppGUI : Form
    {

        public Controller.Controller Controller { get; private set; }

        public AppGUI()
        {
            InitializeComponent();
            ExperimentControlScreen.Initialize();
            SimulationControlScreen.AppGUI = this;
            ReplicationControlScreen.AppGUI = this;
            ExperimentControlScreen.AppGUI = this;
            SimulationOptions.AppGUI = this;

            Controller = new Controller.Controller(this, SimulationControlScreen, ReplicationControlScreen,
                                                   ExperimentControlScreen, SimulationOptions);

            HideAllScreens();
            SimulationControlScreen.Show();
        }

        private void HideAllScreens()
        {
            SimulationControlScreen.Hide();
            ReplicationControlScreen.Hide();
            ExperimentControlScreen.Hide();
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
            Controller.SwitchToSimulationScreen();
        }

        private void ShowReplicationButton_Click(object sender, EventArgs e)
        {
            HideAllScreens();
            ReplicationControlScreen.Show();
            Controller.SwitchToReplicationScreen();
        }
        private void ShowExperimentsButton_Click(object sender, EventArgs e)
        {
            HideAllScreens();
            ExperimentControlScreen.Show();
            Controller.SwitchToExperimentalScreen();
        }

        public void SignalBaseOptionsConfirm()
        {
            Controller.TryApplyBaseSimulationSettings();
        }

    }
}
