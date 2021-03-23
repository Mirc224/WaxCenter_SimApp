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
            this.RealTimeSimulationWorker = new System.ComponentModel.BackgroundWorker();
            this.SimulationControlScreen = new WaxCenter_SimApp.GUIComponents.Screens.SimulationControl();
            this.MainMenuPanel.SuspendLayout();
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
            this.OptionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.OptionsPanel.Location = new System.Drawing.Point(1729, 0);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(214, 971);
            this.OptionsPanel.TabIndex = 2;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.SimulationControlScreen);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(155, 0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(1574, 971);
            this.ContentPanel.TabIndex = 3;
            // 
            // RealTimeSimulationWorker
            // 
            this.RealTimeSimulationWorker.WorkerReportsProgress = true;
            this.RealTimeSimulationWorker.WorkerSupportsCancellation = true;
            this.RealTimeSimulationWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RealTimeSimulationWorker_DoWork);
            this.RealTimeSimulationWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.RealTimeSimulationWorker_ProgressChanged);
            this.RealTimeSimulationWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RealTimeSimulationWorker_RunWorkerCompleted);
            // 
            // SimulationControlScreen
            // 
            this.SimulationControlScreen.AppGUI = null;
            this.SimulationControlScreen.Location = new System.Drawing.Point(0, 3);
            this.SimulationControlScreen.Name = "SimulationControlScreen";
            this.SimulationControlScreen.Size = new System.Drawing.Size(1574, 965);
            this.SimulationControlScreen.TabIndex = 0;
            // 
            // AppGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1943, 971);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.OptionsPanel);
            this.Controls.Add(this.MainMenuPanel);
            this.Name = "AppGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainMenuPanel.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
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
    }
}

