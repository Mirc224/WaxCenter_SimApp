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
    public partial class SimService : UserControl, ISimComponent
    {
        public ServiceComponent ServiceModelComponent { get; set; }
        public SimService()
        {
            InitializeComponent();
        }
        public int ID { get; set; } = -1;
        public SimulationControl SimulationControl { get; set; }
        public SimComponentType SimComponentType { get => SimComponentType.SERVICE; }
        private void ServicePicture_MouseClick(object sender, MouseEventArgs e)
        {
            SimulationControl.HandleComponentSelect(this);
        }
        public void UpdateAccordingToState(ServiceStateData stateData)
        {
            InputText = stateData.AgentsEntered.ToString();
            OutputText = stateData.AgentsLeaved.ToString();
            QueueText = stateData.QueueSize.ToString();
            CurrentlyUsedText = stateData.CurrentlyUsed.ToString();
        }

        public void UpdateAccordingToState()
        {
            UpdateAccordingToState(ServiceModelComponent.ServiceStateData);
        }
    }
    
}
