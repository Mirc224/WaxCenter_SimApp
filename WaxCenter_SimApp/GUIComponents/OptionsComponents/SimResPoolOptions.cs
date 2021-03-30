using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaxCenter_SimApp.GUIComponents.OptionsComponents
{
    public partial class SimResPoolOptions : UserControl, IGUIOptions
    {
        public SimResPoolOptions()
        {
            InitializeComponent();
        }
        public AppGUI AppGUI { get; set; }
        public GUIOptionsType OptionsType { get => _optionsType; }
        public string StaffInputText { get => StaffInput.Text; set => StaffInput.Text = value; }

        private GUIOptionsType _optionsType = GUIOptionsType.RESPOOL;

        private void ResPoolButton_Click(object sender, EventArgs e)
        {
            AppGUI.HandleComponentOptionsConfirmSignal(this);
        }
    }
}
