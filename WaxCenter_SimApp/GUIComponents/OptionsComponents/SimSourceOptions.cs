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

namespace WaxCenter_SimApp.GUIComponents.OptionsComponents
{
    public partial class SimSourceOptions : UserControl, IGUIOptions
    {
        public SimulationControl SimulationControl { get; set; }
        public GUIOptionsType OptionsType { get => GUIOptionsType.SOURCE; }
        public SimSourceOptions()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            SimulationControl.HandleComponentOptionsConfirmSignal(this);
        }
    }
}
