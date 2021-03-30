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
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents;
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.ComponentValuesClasses;

namespace WaxCenter_SimApp.GUIComponents.SimComponents
{
    public partial class SimSink : UserControl, ISimComponent
    {
        public SinkComponent SinkModelComponent { get; set; }
        public SimSink()
        {
            InitializeComponent();
        }

        public int ID { get; set; } = -1;
        public SimulationControl SimulationControl { get; set; }
        public SimComponentType SimComponentType { get => SimComponentType.SINK; }
        private void SinkPicture_MouseClick(object sender, MouseEventArgs e)
        {
            SimulationControl.HandleComponentSelect(this);
        }

        public void UpdateAccordingToState(SinkStateData stateData)
        {
            InputText = stateData.SinkInput.ToString();
        }

        public void UpdateAccordingToState()
        {
            UpdateAccordingToState(SinkModelComponent.StateData);
        }
    }
}
