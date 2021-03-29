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
    public partial class SimStats : UserControl, ISimComponent
    {
        public SimStats()
        {
            InitializeComponent();
        }

        private void MyClickEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Kliknutie");
            SimulationControl.HandleComponentSelect(this);
        }
        public int ID { get; set; } = -1;
        public SimulationControl SimulationControl { get; set; }
        public SimComponentType SimComponentType { get => SimComponentType.STAT; }
        private void StatPicture_MouseClick(object sender, MouseEventArgs e)
        {
            MyClickEvent(sender, e);
        }
        public void UpdateAccordingToState(StatisticStateData stateData)
        {
            ValueText = $"[{String.Format("{0:0.####}", stateData.StatMin)}..{String.Format("{0:0.####}", stateData.StatMax)}] Mean: {String.Format("{0:0.####}", stateData.StatMean)}";
        }
    }
}
