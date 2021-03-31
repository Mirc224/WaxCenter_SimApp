
namespace WaxCenter_SimApp.GUIComponents.Screens
{
    partial class ReplicationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReplicationTitleLabel = new System.Windows.Forms.Label();
            this.ReplicationsTopPanel = new System.Windows.Forms.Panel();
            this.ReplicationsOptionsPanel = new System.Windows.Forms.Panel();
            this.RepOptionsTitleLabel = new System.Windows.Forms.Label();
            this.RunReplicationButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.WaitingRoomStats = new WaxCenter_SimApp.GUIComponents.StatsComponents.StatsTable();
            this.VaccinationStats = new WaxCenter_SimApp.GUIComponents.StatsComponents.StatsTable();
            this.ExaminationStats = new WaxCenter_SimApp.GUIComponents.StatsComponents.StatsTable();
            this.AdminStats = new WaxCenter_SimApp.GUIComponents.StatsComponents.StatsTable();
            this.ReplicationsTopPanel.SuspendLayout();
            this.ReplicationsOptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReplicationTitleLabel
            // 
            this.ReplicationTitleLabel.AutoSize = true;
            this.ReplicationTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ReplicationTitleLabel.Location = new System.Drawing.Point(3, 0);
            this.ReplicationTitleLabel.Name = "ReplicationTitleLabel";
            this.ReplicationTitleLabel.Size = new System.Drawing.Size(207, 38);
            this.ReplicationTitleLabel.TabIndex = 0;
            this.ReplicationTitleLabel.Text = "Replications";
            // 
            // ReplicationsTopPanel
            // 
            this.ReplicationsTopPanel.Controls.Add(this.ReplicationTitleLabel);
            this.ReplicationsTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ReplicationsTopPanel.Location = new System.Drawing.Point(0, 0);
            this.ReplicationsTopPanel.Name = "ReplicationsTopPanel";
            this.ReplicationsTopPanel.Size = new System.Drawing.Size(1755, 49);
            this.ReplicationsTopPanel.TabIndex = 1;
            // 
            // ReplicationsOptionsPanel
            // 
            this.ReplicationsOptionsPanel.Controls.Add(this.RepOptionsTitleLabel);
            this.ReplicationsOptionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ReplicationsOptionsPanel.Location = new System.Drawing.Point(1521, 49);
            this.ReplicationsOptionsPanel.Name = "ReplicationsOptionsPanel";
            this.ReplicationsOptionsPanel.Size = new System.Drawing.Size(234, 794);
            this.ReplicationsOptionsPanel.TabIndex = 2;
            // 
            // RepOptionsTitleLabel
            // 
            this.RepOptionsTitleLabel.AutoSize = true;
            this.RepOptionsTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RepOptionsTitleLabel.Location = new System.Drawing.Point(3, 3);
            this.RepOptionsTitleLabel.Name = "RepOptionsTitleLabel";
            this.RepOptionsTitleLabel.Size = new System.Drawing.Size(121, 32);
            this.RepOptionsTitleLabel.TabIndex = 0;
            this.RepOptionsTitleLabel.Text = "Options";
            // 
            // RunReplicationButton
            // 
            this.RunReplicationButton.Location = new System.Drawing.Point(10, 586);
            this.RunReplicationButton.Name = "RunReplicationButton";
            this.RunReplicationButton.Size = new System.Drawing.Size(119, 40);
            this.RunReplicationButton.TabIndex = 7;
            this.RunReplicationButton.Text = "Run replications";
            this.RunReplicationButton.UseVisualStyleBackColor = true;
            this.RunReplicationButton.Click += new System.EventHandler(this.RunReplicationButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(10, 632);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(119, 42);
            this.StopButton.TabIndex = 8;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // WaitingRoomStats
            // 
            this.WaitingRoomStats.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.WaitingRoomStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WaitingRoomStats.Location = new System.Drawing.Point(1057, 49);
            this.WaitingRoomStats.MinimumSize = new System.Drawing.Size(204, 181);
            this.WaitingRoomStats.Name = "WaitingRoomStats";
            this.WaitingRoomStats.ResultGroup = null;
            this.WaitingRoomStats.Size = new System.Drawing.Size(347, 246);
            this.WaitingRoomStats.TabIndex = 6;
            this.WaitingRoomStats.TitleText = "Waiting room";
            // 
            // VaccinationStats
            // 
            this.VaccinationStats.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.VaccinationStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VaccinationStats.Location = new System.Drawing.Point(355, 49);
            this.VaccinationStats.MinimumSize = new System.Drawing.Size(204, 181);
            this.VaccinationStats.Name = "VaccinationStats";
            this.VaccinationStats.ResultGroup = null;
            this.VaccinationStats.Size = new System.Drawing.Size(345, 246);
            this.VaccinationStats.TabIndex = 5;
            this.VaccinationStats.TitleText = "Vaccination";
            // 
            // ExaminationStats
            // 
            this.ExaminationStats.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExaminationStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExaminationStats.Location = new System.Drawing.Point(706, 49);
            this.ExaminationStats.MinimumSize = new System.Drawing.Size(204, 181);
            this.ExaminationStats.Name = "ExaminationStats";
            this.ExaminationStats.ResultGroup = null;
            this.ExaminationStats.Size = new System.Drawing.Size(345, 246);
            this.ExaminationStats.TabIndex = 4;
            this.ExaminationStats.TitleText = "Examination";
            // 
            // AdminStats
            // 
            this.AdminStats.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AdminStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AdminStats.Location = new System.Drawing.Point(3, 49);
            this.AdminStats.MinimumSize = new System.Drawing.Size(204, 181);
            this.AdminStats.Name = "AdminStats";
            this.AdminStats.ResultGroup = null;
            this.AdminStats.Size = new System.Drawing.Size(346, 246);
            this.AdminStats.TabIndex = 3;
            this.AdminStats.TitleText = "Administration";
            // 
            // ReplicationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.RunReplicationButton);
            this.Controls.Add(this.WaitingRoomStats);
            this.Controls.Add(this.VaccinationStats);
            this.Controls.Add(this.ExaminationStats);
            this.Controls.Add(this.AdminStats);
            this.Controls.Add(this.ReplicationsOptionsPanel);
            this.Controls.Add(this.ReplicationsTopPanel);
            this.Name = "ReplicationControl";
            this.Size = new System.Drawing.Size(1755, 843);
            this.ReplicationsTopPanel.ResumeLayout(false);
            this.ReplicationsTopPanel.PerformLayout();
            this.ReplicationsOptionsPanel.ResumeLayout(false);
            this.ReplicationsOptionsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ReplicationTitleLabel;
        private System.Windows.Forms.Panel ReplicationsTopPanel;
        private System.Windows.Forms.Panel ReplicationsOptionsPanel;
        private System.Windows.Forms.Label RepOptionsTitleLabel;
        private StatsComponents.StatsTable AdminStats;
        private StatsComponents.StatsTable ExaminationStats;
        private StatsComponents.StatsTable VaccinationStats;
        private StatsComponents.StatsTable WaitingRoomStats;
        private System.Windows.Forms.Button RunReplicationButton;
        private System.Windows.Forms.Button StopButton;
    }
}
