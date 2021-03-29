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
using WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.SimulationComponents.ComponentValuesClasses;

namespace WaxCenter_SimApp.GUIComponents.SimComponents
{
    public partial class SimResourcePool : UserControl, ISimComponent
    {
        public SimResourcePool()
        {
            InitializeComponent();
        }

        public int ID { get; set; } = -1;
        public SimulationControl SimulationControl { get; set; }
        public SimComponentType SimComponentType { get => SimComponentType.RESOURCEPOOL; }
        private void ResourcePoolPicture_MouseClick(object sender, MouseEventArgs e)
        {
            SimulationControl.HandleComponentSelect(this);
        }

        public void UpdateAccordingToState(ServiceStateData stateData)
        {
            StaffUsedText = $"{stateData.ResourcePoolMaxStaff - stateData.CurrentlyUsed}/{stateData.ResourcePoolMaxStaff}";
            UtilizationText = $"{(int)(stateData.ResourcePoolUtilization * 100)}%";
        }
    }
}
