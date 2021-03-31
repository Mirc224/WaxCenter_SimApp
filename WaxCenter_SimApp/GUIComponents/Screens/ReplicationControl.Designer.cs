
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
            this.AdminStats = new WaxCenter_SimApp.GUIComponents.StatsComponents.StatsTable();
            this.ExaminationStats = new WaxCenter_SimApp.GUIComponents.StatsComponents.StatsTable();
            this.VaccinationStats = new WaxCenter_SimApp.GUIComponents.StatsComponents.StatsTable();
            this.WaitingRoomStats = new WaxCenter_SimApp.GUIComponents.StatsComponents.StatsTable();
            this.ReplicationsTopPanel.SuspendLayout();
            this.ReplicationsOptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReplicationTitleLabel
            // 
            this.ReplicationTitleLabel.AutoSize = true;
            this.ReplicationTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ReplicationTitleLabel.Location = new System.Drawing.Point(3, 16);
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
            this.ReplicationsTopPanel.Size = new System.Drawing.Size(1501, 79);
            this.ReplicationsTopPanel.TabIndex = 1;
            // 
            // ReplicationsOptionsPanel
            // 
            this.ReplicationsOptionsPanel.Controls.Add(this.RepOptionsTitleLabel);
            this.ReplicationsOptionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ReplicationsOptionsPanel.Location = new System.Drawing.Point(1272, 79);
            this.ReplicationsOptionsPanel.Name = "ReplicationsOptionsPanel";
            this.ReplicationsOptionsPanel.Size = new System.Drawing.Size(229, 766);
            this.ReplicationsOptionsPanel.TabIndex = 2;
            // 
            // RepOptionsTitleLabel
            // 
            this.RepOptionsTitleLabel.AutoSize = true;
            this.RepOptionsTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RepOptionsTitleLabel.Location = new System.Drawing.Point(49, 3);
            this.RepOptionsTitleLabel.Name = "RepOptionsTitleLabel";
            this.RepOptionsTitleLabel.Size = new System.Drawing.Size(121, 32);
            this.RepOptionsTitleLabel.TabIndex = 0;
            this.RepOptionsTitleLabel.Text = "Options";
            // 
            // AdminStats
            // 
            this.AdminStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AdminStats.Location = new System.Drawing.Point(3, 85);
            this.AdminStats.MinimumSize = new System.Drawing.Size(204, 181);
            this.AdminStats.Name = "AdminStats";
            this.AdminStats.Size = new System.Drawing.Size(204, 260);
            this.AdminStats.TabIndex = 3;
            this.AdminStats.TitleText = "Administration";
            // 
            // ExaminationStats
            // 
            this.ExaminationStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExaminationStats.Location = new System.Drawing.Point(213, 85);
            this.ExaminationStats.MinimumSize = new System.Drawing.Size(204, 181);
            this.ExaminationStats.Name = "ExaminationStats";
            this.ExaminationStats.Size = new System.Drawing.Size(204, 260);
            this.ExaminationStats.TabIndex = 4;
            this.ExaminationStats.TitleText = "Examination";
            // 
            // VaccinationStats
            // 
            this.VaccinationStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VaccinationStats.Location = new System.Drawing.Point(423, 85);
            this.VaccinationStats.MinimumSize = new System.Drawing.Size(204, 181);
            this.VaccinationStats.Name = "VaccinationStats";
            this.VaccinationStats.Size = new System.Drawing.Size(204, 260);
            this.VaccinationStats.TabIndex = 5;
            this.VaccinationStats.TitleText = "Vaccination";
            // 
            // WaitingRoomStats
            // 
            this.WaitingRoomStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WaitingRoomStats.Location = new System.Drawing.Point(633, 85);
            this.WaitingRoomStats.MinimumSize = new System.Drawing.Size(204, 181);
            this.WaitingRoomStats.Name = "WaitingRoomStats";
            this.WaitingRoomStats.Size = new System.Drawing.Size(204, 181);
            this.WaitingRoomStats.TabIndex = 6;
            this.WaitingRoomStats.TitleText = "Waiting room";
            // 
            // ReplicationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WaitingRoomStats);
            this.Controls.Add(this.VaccinationStats);
            this.Controls.Add(this.ExaminationStats);
            this.Controls.Add(this.AdminStats);
            this.Controls.Add(this.ReplicationsOptionsPanel);
            this.Controls.Add(this.ReplicationsTopPanel);
            this.Name = "ReplicationControl";
            this.Size = new System.Drawing.Size(1501, 845);
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
    }
}
