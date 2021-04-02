using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaxCenter_SimApp.GUIComponents.Screens;

namespace WaxCenter_SimApp.GUIComponents.Clock
{
    public partial class SimulationClock : UserControl
    {
        public SimulationControl SimulationControl { get; set; } = null;
        public string ClockText { get => ClockLabel.Text; set => ClockLabel.Text = value; }
        public string StartPauseButtonText { get => StartPauseButton.Text; set => StartPauseButton.Text = value; }
        public bool StopButtonEnabled { get => StopButton.Enabled; set => StopButton.Enabled = value; }
        public bool StartPauseButtonEnabled { get => StartPauseButton.Enabled; set => StartPauseButton.Enabled = value; }
        public SimulationClock()
        {
            InitializeComponent();
        }

        private void StartPauseButton_Click(object sender, EventArgs e)
        {
            SimulationControl.StartButtonClick();
        }

        private void SpeedSlider_Scroll(object sender, EventArgs e)
        {
            SimulationControl.SimulationSpeedChange(SpeedSlider.Value);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            SimulationControl.SimulationStopSignal();
        }

        public void SetSpeedSlider(int numOfSpeeds)
        {
            SpeedSlider.Maximum = numOfSpeeds;
        }
    }
}
