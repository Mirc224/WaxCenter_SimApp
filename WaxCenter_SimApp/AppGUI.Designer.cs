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
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.BaseSettingsPanel = new System.Windows.Forms.Panel();
            this.RealTimeSimulationWorker = new System.ComponentModel.BackgroundWorker();
            this.SimulationOptions = new WaxCenter_SimApp.GUIComponents.OptionsComponents.SimulationOptions();
            this.SimulationControlScreen = new WaxCenter_SimApp.GUIComponents.Screens.SimulationControl();
            this.SourceOptions = new WaxCenter_SimApp.GUIComponents.OptionsComponents.SimSourceOptions();
            this.ResPoolOptions = new WaxCenter_SimApp.GUIComponents.OptionsComponents.SimResPoolOptions();
            this.MainMenuPanel.SuspendLayout();
            this.OptionsPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.BaseSettingsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuPanel
            // 
            this.MainMenuPanel.Controls.Add(this.ShowReplicationButton);
            this.MainMenuPanel.Controls.Add(this.ShowSimulationButton);
            this.MainMenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MainMenuPanel.Name = "MainMenuPanel";
            this.MainMenuPanel.Size = new System.Drawing.Size(155, 971);
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
            // OptionsPanel
            // 
            this.OptionsPanel.Controls.Add(this.SourceOptions);
            this.OptionsPanel.Controls.Add(this.ResPoolOptions);
            this.OptionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.OptionsPanel.Location = new System.Drawing.Point(1670, 0);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(314, 971);
            this.OptionsPanel.TabIndex = 2;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.BaseSettingsPanel);
            this.ContentPanel.Controls.Add(this.SimulationControlScreen);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(155, 0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(1515, 971);
            this.ContentPanel.TabIndex = 3;
            // 
            // BaseSettingsPanel
            // 
            this.BaseSettingsPanel.Controls.Add(this.SimulationOptions);
            this.BaseSettingsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.BaseSettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.BaseSettingsPanel.Name = "BaseSettingsPanel";
            this.BaseSettingsPanel.Size = new System.Drawing.Size(1515, 186);
            this.BaseSettingsPanel.TabIndex = 1;
            // 
            // RealTimeSimulationWorker
            // 
            this.RealTimeSimulationWorker.WorkerReportsProgress = true;
            this.RealTimeSimulationWorker.WorkerSupportsCancellation = true;
            this.RealTimeSimulationWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RealTimeSimulationWorker_DoWork);
            this.RealTimeSimulationWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.RealTimeSimulationWorker_ProgressChanged);
            this.RealTimeSimulationWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RealTimeSimulationWorker_RunWorkerCompleted);
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
            // SimulationControlScreen
            // 
            this.SimulationControlScreen.AppGUI = null;
            this.SimulationControlScreen.AutoSize = true;
            this.SimulationControlScreen.Location = new System.Drawing.Point(0, 189);
            this.SimulationControlScreen.MinimumSize = new System.Drawing.Size(1536, 642);
            this.SimulationControlScreen.Name = "SimulationControlScreen";
            this.SimulationControlScreen.Size = new System.Drawing.Size(1536, 642);
            this.SimulationControlScreen.TabIndex = 0;
            // 
            // SourceOptions
            // 
            this.SourceOptions.AgentsInputText = "";
            this.SourceOptions.AppGUI = null;
            this.SourceOptions.IntervalInputText = "";
            this.SourceOptions.Location = new System.Drawing.Point(3, 189);
            this.SourceOptions.MinimumSize = new System.Drawing.Size(292, 142);
            this.SourceOptions.Name = "SourceOptions";
            this.SourceOptions.Size = new System.Drawing.Size(299, 142);
            this.SourceOptions.TabIndex = 1;
            // 
            // ResPoolOptions
            // 
            this.ResPoolOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResPoolOptions.AppGUI = null;
            this.ResPoolOptions.Location = new System.Drawing.Point(3, 189);
            this.ResPoolOptions.MinimumSize = new System.Drawing.Size(292, 142);
            this.ResPoolOptions.Name = "ResPoolOptions";
            this.ResPoolOptions.SelectedText = "Selected";
            this.ResPoolOptions.Size = new System.Drawing.Size(304, 142);
            this.ResPoolOptions.StaffInputText = "";
            this.ResPoolOptions.TabIndex = 0;
            // 
            // AppGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1984, 971);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.OptionsPanel);
            this.Controls.Add(this.MainMenuPanel);
            this.Name = "AppGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainMenuPanel.ResumeLayout(false);
            this.OptionsPanel.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            this.ContentPanel.PerformLayout();
            this.BaseSettingsPanel.ResumeLayout(false);
            this.BaseSettingsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainMenuPanel;
        private System.Windows.Forms.Button ShowReplicationButton;
        private System.Windows.Forms.Button ShowSimulationButton;
        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.Panel ContentPanel;
        private SimulationControl SimulationControlScreen;
        private System.ComponentModel.BackgroundWorker RealTimeSimulationWorker;
        private System.Windows.Forms.Panel BaseSettingsPanel;
        private GUIComponents.OptionsComponents.SimulationOptions SimulationOptions;
        private GUIComponents.OptionsComponents.SimResPoolOptions ResPoolOptions;
        private GUIComponents.OptionsComponents.SimSourceOptions SourceOptions;
    }
}

