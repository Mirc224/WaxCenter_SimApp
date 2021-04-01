using WaxCenter_SimApp.GUIComponents.Screens;
namespace WaxCenter_SimApp
{
    partial class AppGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainMenuPanel = new System.Windows.Forms.Panel();
            this.ShowReplicationButton = new System.Windows.Forms.Button();
            this.ShowSimulationButton = new System.Windows.Forms.Button();
            this.ReplicationsWorker = new System.ComponentModel.BackgroundWorker();
            this.BaseSettingsPanel = new System.Windows.Forms.Panel();
            this.SimulationOptions = new WaxCenter_SimApp.GUIComponents.OptionsComponents.SimulationOptions();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.ReplicationControlScreen = new WaxCenter_SimApp.GUIComponents.Screens.ReplicationControl();
            this.SimulationControlScreen = new WaxCenter_SimApp.GUIComponents.Screens.SimulationControl();
            this.MainMenuPanel.SuspendLayout();
            this.BaseSettingsPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuPanel
            // 
            this.MainMenuPanel.Controls.Add(this.ShowReplicationButton);
            this.MainMenuPanel.Controls.Add(this.ShowSimulationButton);
            this.MainMenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MainMenuPanel.Name = "MainMenuPanel";
            this.MainMenuPanel.Size = new System.Drawing.Size(155, 1019);
            this.MainMenuPanel.TabIndex = 0;
            // 
            // ShowReplicationButton
            // 
            this.ShowReplicationButton.Location = new System.Drawing.Point(27, 100);
            this.ShowReplicationButton.Name = "ShowReplicationButton";
            this.ShowReplicationButton.Size = new System.Drawing.Size(105, 32);
            this.ShowReplicationButton.TabIndex = 1;
            this.ShowReplicationButton.Text = "Replications";
            this.ShowReplicationButton.UseVisualStyleBackColor = true;
            this.ShowReplicationButton.Click += new System.EventHandler(this.ShowReplicationButton_Click);
            // 
            // ShowSimulationButton
            // 
            this.ShowSimulationButton.Location = new System.Drawing.Point(27, 42);
            this.ShowSimulationButton.Name = "ShowSimulationButton";
            this.ShowSimulationButton.Size = new System.Drawing.Size(105, 29);
            this.ShowSimulationButton.TabIndex = 0;
            this.ShowSimulationButton.Text = "Simulation";
            this.ShowSimulationButton.UseVisualStyleBackColor = true;
            this.ShowSimulationButton.Click += new System.EventHandler(this.ShowSimulationButton_Click);
            // 
            // ReplicationsWorker
            // 
            this.ReplicationsWorker.WorkerReportsProgress = true;
            this.ReplicationsWorker.WorkerSupportsCancellation = true;
            this.ReplicationsWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ReplicationsWorker_DoWork);
            // 
            // BaseSettingsPanel
            // 
            this.BaseSettingsPanel.Controls.Add(this.SimulationOptions);
            this.BaseSettingsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.BaseSettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.BaseSettingsPanel.Name = "BaseSettingsPanel";
            this.BaseSettingsPanel.Size = new System.Drawing.Size(1835, 186);
            this.BaseSettingsPanel.TabIndex = 1;
            // 
            // SimulationOptions
            // 
            this.SimulationOptions.AppGUI = null;
            this.SimulationOptions.AutoSize = true;
            this.SimulationOptions.Location = new System.Drawing.Point(6, 0);
            this.SimulationOptions.MaxTimeInputText = "";
            this.SimulationOptions.MinimumSize = new System.Drawing.Size(529, 130);
            this.SimulationOptions.Name = "SimulationOptions";
            this.SimulationOptions.SeedInputText = "";
            this.SimulationOptions.Size = new System.Drawing.Size(564, 183);
            this.SimulationOptions.TabIndex = 0;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.ReplicationControlScreen);
            this.ContentPanel.Controls.Add(this.BaseSettingsPanel);
            this.ContentPanel.Controls.Add(this.SimulationControlScreen);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(155, 0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(1835, 1019);
            this.ContentPanel.TabIndex = 3;
            // 
            // ReplicationControlScreen
            // 
            this.ReplicationControlScreen.AppGUI = null;
            this.ReplicationControlScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReplicationControlScreen.Location = new System.Drawing.Point(0, 189);
            this.ReplicationControlScreen.Name = "ReplicationControlScreen";
            this.ReplicationControlScreen.Size = new System.Drawing.Size(1832, 818);
            this.ReplicationControlScreen.TabIndex = 2;
            // 
            // SimulationControlScreen
            // 
            this.SimulationControlScreen.AppGUI = null;
            this.SimulationControlScreen.AutoSize = true;
            this.SimulationControlScreen.Location = new System.Drawing.Point(6, 189);
            this.SimulationControlScreen.MinimumSize = new System.Drawing.Size(1536, 642);
            this.SimulationControlScreen.Name = "SimulationControlScreen";
            this.SimulationControlScreen.Size = new System.Drawing.Size(1835, 642);
            this.SimulationControlScreen.TabIndex = 0;
            // 
            // AppGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1990, 1019);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.MainMenuPanel);
            this.Name = "AppGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainMenuPanel.ResumeLayout(false);
            this.BaseSettingsPanel.ResumeLayout(false);
            this.BaseSettingsPanel.PerformLayout();
            this.ContentPanel.ResumeLayout(false);
            this.ContentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainMenuPanel;
        private System.Windows.Forms.Button ShowReplicationButton;
        private System.Windows.Forms.Button ShowSimulationButton;
        private System.ComponentModel.BackgroundWorker ReplicationsWorker;
        private SimulationControl SimulationControlScreen;
        private System.Windows.Forms.Panel BaseSettingsPanel;
        private GUIComponents.OptionsComponents.SimulationOptions SimulationOptions;
        private ReplicationControl ReplicationControlScreen;
        private System.Windows.Forms.Panel ContentPanel;
    }
}

