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
using WaxCenter_SimApp.Model.Simulation.VaccinationCenter;

namespace WaxCenter_SimApp.GUIComponents.SimComponents
{
    public partial class SimSource : UserControl, ISimComponent
    {
        public BaseSourceComponent SourceModelComponent { get; set; }
        public int ID { get; set; } = -1;
        public SimulationControl SimulationControl { get; set; }
        public SimComponentType SimComponentType { get => SimComponentType.SOURCE; }
        public SimSource()
        {
            InitializeComponent();
        }
        private void SourcePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            SimulationControl.HandleComponentSelect(this);
        }

        public void UpdateAccordingToState(SourceStateData stateData)
        {
            OutputText = stateData.SourceOutput.ToString();
        }

        public void UpdateAccordingToState()
        {
            UpdateAccordingToState(SourceModelComponent.StateData);
        }
    }
}
