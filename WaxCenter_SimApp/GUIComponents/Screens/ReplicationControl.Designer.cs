
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
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NumberOfRepLabel = new System.Windows.Forms.Label();
            this.ReplicationsInput = new System.Windows.Forms.TextBox();
            this.AdminLabel = new System.Windows.Forms.Label();
            this.NoPatientsLabel = new System.Windows.Forms.Label();
            this.GUIUpdateLabel = new System.Windows.Forms.Label();
            this.PatientInput = new System.Windows.Forms.TextBox();
            this.DoctorLabel = new System.Windows.Forms.Label();
            this.NurseLabel = new System.Windows.Forms.Label();
            this.AdminInput = new System.Windows.Forms.TextBox();
            this.NurseInput = new System.Windows.Forms.TextBox();
            this.DoctorInput = new System.Windows.Forms.TextBox();
            this.IntervalLabel = new System.Windows.Forms.Label();
            this.IntervalInput = new System.Windows.Forms.TextBox();
            this.UpdateIntervalInput = new System.Windows.Forms.TextBox();
            this.RepOptionsTitleLabel = new System.Windows.Forms.Label();
            this.StartPauseButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ReplicationsWorker = new System.ComponentModel.BackgroundWorker();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.WaitingRoomStats = new WaxCenter_SimApp.GUIComponents.StatsComponents.StatsTable();
            this.VaccinationStats = new WaxCenter_SimApp.GUIComponents.StatsComponents.StatsTable();
            this.ExaminationStats = new WaxCenter_SimApp.GUIComponents.StatsComponents.StatsTable();
            this.AdminStats = new WaxCenter_SimApp.GUIComponents.StatsComponents.StatsTable();
            this.AverageOvertimeLabel = new System.Windows.Forms.Label();
            this.CapacityConfidenceLabel = new System.Windows.Forms.Label();
            this.ReplicationsTopPanel.SuspendLayout();
            this.ReplicationsOptionsPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.ReplicationsOptionsPanel.Controls.Add(this.ConfirmButton);
            this.ReplicationsOptionsPanel.Controls.Add(this.tableLayoutPanel1);
            this.ReplicationsOptionsPanel.Controls.Add(this.RepOptionsTitleLabel);
            this.ReplicationsOptionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ReplicationsOptionsPanel.Location = new System.Drawing.Point(1428, 49);
            this.ReplicationsOptionsPanel.Name = "ReplicationsOptionsPanel";
            this.ReplicationsOptionsPanel.Size = new System.Drawing.Size(327, 794);
            this.ReplicationsOptionsPanel.TabIndex = 2;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(100, 302);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(133, 31);
            this.ConfirmButton.TabIndex = 2;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.NumberOfRepLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ReplicationsInput, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.AdminLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.NoPatientsLabel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.GUIUpdateLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PatientInput, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.DoctorLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.NurseLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.AdminInput, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.NurseInput, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.DoctorInput, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.IntervalLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.IntervalInput, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.UpdateIntervalInput, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 58);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(291, 218);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // NumberOfRepLabel
            // 
            this.NumberOfRepLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberOfRepLabel.AutoSize = true;
            this.NumberOfRepLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NumberOfRepLabel.Location = new System.Drawing.Point(3, 28);
            this.NumberOfRepLabel.Name = "NumberOfRepLabel";
            this.NumberOfRepLabel.Size = new System.Drawing.Size(139, 28);
            this.NumberOfRepLabel.TabIndex = 0;
            this.NumberOfRepLabel.Text = "Replications:";
            this.NumberOfRepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ReplicationsInput
            // 
            this.ReplicationsInput.Location = new System.Drawing.Point(148, 31);
            this.ReplicationsInput.Name = "ReplicationsInput";
            this.ReplicationsInput.Size = new System.Drawing.Size(140, 22);
            this.ReplicationsInput.TabIndex = 1;
            // 
            // AdminLabel
            // 
            this.AdminLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminLabel.AutoSize = true;
            this.AdminLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.AdminLabel.Location = new System.Drawing.Point(3, 56);
            this.AdminLabel.Name = "AdminLabel";
            this.AdminLabel.Size = new System.Drawing.Size(139, 28);
            this.AdminLabel.TabIndex = 2;
            this.AdminLabel.Text = "Admin staff:";
            this.AdminLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NoPatientsLabel
            // 
            this.NoPatientsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NoPatientsLabel.AutoSize = true;
            this.NoPatientsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.NoPatientsLabel.Location = new System.Drawing.Point(3, 168);
            this.NoPatientsLabel.Name = "NoPatientsLabel";
            this.NoPatientsLabel.Size = new System.Drawing.Size(139, 28);
            this.NoPatientsLabel.TabIndex = 10;
            this.NoPatientsLabel.Text = "Num of patients:";
            this.NoPatientsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GUIUpdateLabel
            // 
            this.GUIUpdateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GUIUpdateLabel.AutoSize = true;
            this.GUIUpdateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.GUIUpdateLabel.Location = new System.Drawing.Point(3, 0);
            this.GUIUpdateLabel.Name = "GUIUpdateLabel";
            this.GUIUpdateLabel.Size = new System.Drawing.Size(139, 28);
            this.GUIUpdateLabel.TabIndex = 13;
            this.GUIUpdateLabel.Text = "GUI update:";
            this.GUIUpdateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PatientInput
            // 
            this.PatientInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PatientInput.Location = new System.Drawing.Point(148, 171);
            this.PatientInput.Name = "PatientInput";
            this.PatientInput.Size = new System.Drawing.Size(140, 22);
            this.PatientInput.TabIndex = 12;
            // 
            // DoctorLabel
            // 
            this.DoctorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DoctorLabel.AutoSize = true;
            this.DoctorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.DoctorLabel.Location = new System.Drawing.Point(3, 84);
            this.DoctorLabel.Name = "DoctorLabel";
            this.DoctorLabel.Size = new System.Drawing.Size(139, 28);
            this.DoctorLabel.TabIndex = 3;
            this.DoctorLabel.Text = "Doctor staff:";
            this.DoctorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NurseLabel
            // 
            this.NurseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NurseLabel.AutoSize = true;
            this.NurseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.NurseLabel.Location = new System.Drawing.Point(3, 112);
            this.NurseLabel.Name = "NurseLabel";
            this.NurseLabel.Size = new System.Drawing.Size(139, 28);
            this.NurseLabel.TabIndex = 4;
            this.NurseLabel.Text = "Nurse staff:";
            this.NurseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AdminInput
            // 
            this.AdminInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminInput.Location = new System.Drawing.Point(148, 59);
            this.AdminInput.Name = "AdminInput";
            this.AdminInput.Size = new System.Drawing.Size(140, 22);
            this.AdminInput.TabIndex = 5;
            // 
            // NurseInput
            // 
            this.NurseInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NurseInput.Location = new System.Drawing.Point(148, 115);
            this.NurseInput.Name = "NurseInput";
            this.NurseInput.Size = new System.Drawing.Size(140, 22);
            this.NurseInput.TabIndex = 7;
            // 
            // DoctorInput
            // 
            this.DoctorInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DoctorInput.Location = new System.Drawing.Point(148, 87);
            this.DoctorInput.Name = "DoctorInput";
            this.DoctorInput.Size = new System.Drawing.Size(140, 22);
            this.DoctorInput.TabIndex = 8;
            // 
            // IntervalLabel
            // 
            this.IntervalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IntervalLabel.AutoSize = true;
            this.IntervalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.IntervalLabel.Location = new System.Drawing.Point(3, 140);
            this.IntervalLabel.Name = "IntervalLabel";
            this.IntervalLabel.Size = new System.Drawing.Size(139, 28);
            this.IntervalLabel.TabIndex = 9;
            this.IntervalLabel.Text = "Arrival interval:";
            this.IntervalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IntervalInput
            // 
            this.IntervalInput.Location = new System.Drawing.Point(148, 143);
            this.IntervalInput.Name = "IntervalInput";
            this.IntervalInput.Size = new System.Drawing.Size(140, 22);
            this.IntervalInput.TabIndex = 11;
            // 
            // UpdateIntervalInput
            // 
            this.UpdateIntervalInput.Location = new System.Drawing.Point(148, 3);
            this.UpdateIntervalInput.Name = "UpdateIntervalInput";
            this.UpdateIntervalInput.Size = new System.Drawing.Size(140, 22);
            this.UpdateIntervalInput.TabIndex = 14;
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
            // StartPauseButton
            // 
            this.StartPauseButton.Location = new System.Drawing.Point(10, 586);
            this.StartPauseButton.Name = "StartPauseButton";
            this.StartPauseButton.Size = new System.Drawing.Size(119, 40);
            this.StartPauseButton.TabIndex = 7;
            this.StartPauseButton.Text = "Start";
            this.StartPauseButton.UseVisualStyleBackColor = true;
            this.StartPauseButton.Click += new System.EventHandler(this.RunReplicationButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(10, 632);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(119, 42);
            this.StopButton.TabIndex = 8;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ReplicationsWorker
            // 
            this.ReplicationsWorker.WorkerReportsProgress = true;
            this.ReplicationsWorker.WorkerSupportsCancellation = true;
            this.ReplicationsWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ReplicationsWorker_DoWork);
            this.ReplicationsWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ReplicationsWorker_ProgressChanged);
            this.ReplicationsWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ReplicationsWorker_RunWorkerCompleted);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(239, 775);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(1059, 36);
            this.ProgressBar.TabIndex = 9;
            // 
            // WaitingRoomStats
            // 
            this.WaitingRoomStats.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.WaitingRoomStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WaitingRoomStats.Location = new System.Drawing.Point(1057, 49);
            this.WaitingRoomStats.MinimumSize = new System.Drawing.Size(204, 181);
            this.WaitingRoomStats.Name = "WaitingRoomStats";
            this.WaitingRoomStats.ResultGroup = null;
            this.WaitingRoomStats.Size = new System.Drawing.Size(347, 318);
            this.WaitingRoomStats.TabIndex = 6;
            this.WaitingRoomStats.TitleText = "Waiting room";
            // 
            // VaccinationStats
            // 
            this.VaccinationStats.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.VaccinationStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VaccinationStats.Location = new System.Drawing.Point(706, 49);
            this.VaccinationStats.MinimumSize = new System.Drawing.Size(204, 181);
            this.VaccinationStats.Name = "VaccinationStats";
            this.VaccinationStats.ResultGroup = null;
            this.VaccinationStats.Size = new System.Drawing.Size(345, 318);
            this.VaccinationStats.TabIndex = 5;
            this.VaccinationStats.TitleText = "Vaccination";
            // 
            // ExaminationStats
            // 
            this.ExaminationStats.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExaminationStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExaminationStats.Location = new System.Drawing.Point(355, 49);
            this.ExaminationStats.MinimumSize = new System.Drawing.Size(204, 181);
            this.ExaminationStats.Name = "ExaminationStats";
            this.ExaminationStats.ResultGroup = null;
            this.ExaminationStats.Size = new System.Drawing.Size(345, 318);
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
            this.AdminStats.Size = new System.Drawing.Size(346, 318);
            this.AdminStats.TabIndex = 3;
            this.AdminStats.TitleText = "Administration";
            // 
            // AverageOvertimeLabel
            // 
            this.AverageOvertimeLabel.AutoSize = true;
            this.AverageOvertimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AverageOvertimeLabel.Location = new System.Drawing.Point(15, 433);
            this.AverageOvertimeLabel.Name = "AverageOvertimeLabel";
            this.AverageOvertimeLabel.Size = new System.Drawing.Size(180, 24);
            this.AverageOvertimeLabel.TabIndex = 10;
            this.AverageOvertimeLabel.Text = "Average overtime:";
            // 
            // CapacityConfidenceLabel
            // 
            this.CapacityConfidenceLabel.AutoSize = true;
            this.CapacityConfidenceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CapacityConfidenceLabel.Location = new System.Drawing.Point(15, 484);
            this.CapacityConfidenceLabel.Name = "CapacityConfidenceLabel";
            this.CapacityConfidenceLabel.Size = new System.Drawing.Size(269, 30);
            this.CapacityConfidenceLabel.TabIndex = 11;
            this.CapacityConfidenceLabel.Text = "WRoom conf. interval:";
            // 
            // ReplicationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.CapacityConfidenceLabel);
            this.Controls.Add(this.AverageOvertimeLabel);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartPauseButton);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button StartPauseButton;
        private System.Windows.Forms.Button StopButton;
        private System.ComponentModel.BackgroundWorker ReplicationsWorker;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label NumberOfRepLabel;
        private System.Windows.Forms.TextBox ReplicationsInput;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Label AdminLabel;
        private System.Windows.Forms.Label DoctorLabel;
        private System.Windows.Forms.Label NurseLabel;
        private System.Windows.Forms.TextBox AdminInput;
        private System.Windows.Forms.TextBox NurseInput;
        private System.Windows.Forms.TextBox DoctorInput;
        private System.Windows.Forms.Label GUIUpdateLabel;
        private System.Windows.Forms.TextBox PatientInput;
        private System.Windows.Forms.Label IntervalLabel;
        private System.Windows.Forms.Label NoPatientsLabel;
        private System.Windows.Forms.TextBox IntervalInput;
        private System.Windows.Forms.TextBox UpdateIntervalInput;
        private System.Windows.Forms.Label AverageOvertimeLabel;
        private System.Windows.Forms.Label CapacityConfidenceLabel;

        public string ReplicationsInputText { get => ReplicationsInput.Text; set => ReplicationsInput.Text = value; }
        public string AdminInputText { get => AdminInput.Text; set => AdminInput.Text = value; }
        public string DoctorInputText { get => DoctorInput.Text; set => DoctorInput.Text = value; }
        public string NurseInputText { get => NurseInput.Text; set => NurseInput.Text = value; }
        public string PatientInputText { get => PatientInput.Text; set => PatientInput.Text = value; }
        public string IntervalInputText { get => IntervalInput.Text; set => IntervalInput.Text = value; }
        public string UpdateIntervalInputText { get => UpdateIntervalInput.Text; set => UpdateIntervalInput.Text = value; }
        public string AvgOvertimeLabel { set => AverageOvertimeLabel.Text = value; }
        public string ConfIntervalLabel { set => CapacityConfidenceLabel.Text = value; }
    }
}
