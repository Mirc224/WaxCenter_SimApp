
namespace WaxCenter_SimApp.GUIComponents.Screens
{
    partial class StaffExperimentalControl
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
            this.OptionsLabel = new System.Windows.Forms.Label();
            this.ScreenTitleLabel = new System.Windows.Forms.Label();
            this.ExperimentResultsGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PatientsInput = new System.Windows.Forms.TextBox();
            this.ArrivalInput = new System.Windows.Forms.TextBox();
            this.ReplicationPerCInput = new System.Windows.Forms.TextBox();
            this.NurseInput = new System.Windows.Forms.TextBox();
            this.DoctorInput = new System.Windows.Forms.TextBox();
            this.ArrivalLabel = new System.Windows.Forms.Label();
            this.PatientsLabel = new System.Windows.Forms.Label();
            this.RepCombLabel = new System.Windows.Forms.Label();
            this.NurseLabel = new System.Windows.Forms.Label();
            this.DoctorLabel = new System.Windows.Forms.Label();
            this.AdminLabel = new System.Windows.Forms.Label();
            this.AdminInput = new System.Windows.Forms.TextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.StartPauseButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.DependenceGraph = new OxyPlot.WindowsForms.PlotView();
            this.NumOfAdmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdminUtilization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvgAdminQL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvgAdminWTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumOfDoctors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorUtilization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeanExamQLenth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeanExamWTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumOfNurse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NurseUtilization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeanVaccQLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeanVaccWTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeanWRoomCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ExperimentResultsGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OptionsLabel
            // 
            this.OptionsLabel.AutoSize = true;
            this.OptionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.OptionsLabel.Location = new System.Drawing.Point(1581, 35);
            this.OptionsLabel.Name = "OptionsLabel";
            this.OptionsLabel.Size = new System.Drawing.Size(121, 32);
            this.OptionsLabel.TabIndex = 0;
            this.OptionsLabel.Text = "Options";
            // 
            // ScreenTitleLabel
            // 
            this.ScreenTitleLabel.AutoSize = true;
            this.ScreenTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ScreenTitleLabel.Location = new System.Drawing.Point(3, 0);
            this.ScreenTitleLabel.Name = "ScreenTitleLabel";
            this.ScreenTitleLabel.Size = new System.Drawing.Size(288, 38);
            this.ScreenTitleLabel.TabIndex = 1;
            this.ScreenTitleLabel.Text = "Staff experiments";
            // 
            // ExperimentResultsGridView
            // 
            this.ExperimentResultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExperimentResultsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumOfAdmin,
            this.AdminUtilization,
            this.AvgAdminQL,
            this.AvgAdminWTime,
            this.NumOfDoctors,
            this.DoctorUtilization,
            this.MeanExamQLenth,
            this.MeanExamWTime,
            this.NumOfNurse,
            this.NurseUtilization,
            this.MeanVaccQLength,
            this.MeanVaccWTime,
            this.MeanWRoomCapacity});
            this.ExperimentResultsGridView.Location = new System.Drawing.Point(3, 392);
            this.ExperimentResultsGridView.Name = "ExperimentResultsGridView";
            this.ExperimentResultsGridView.RowHeadersVisible = false;
            this.ExperimentResultsGridView.RowHeadersWidth = 51;
            this.ExperimentResultsGridView.RowTemplate.Height = 24;
            this.ExperimentResultsGridView.Size = new System.Drawing.Size(1628, 271);
            this.ExperimentResultsGridView.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.40072F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.59928F));
            this.tableLayoutPanel1.Controls.Add(this.PatientsInput, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.ArrivalInput, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ReplicationPerCInput, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.NurseInput, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.DoctorInput, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ArrivalLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.PatientsLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.RepCombLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.NurseLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.DoctorLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.AdminLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AdminInput, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1405, 79);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(372, 219);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // PatientsInput
            // 
            this.PatientsInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PatientsInput.Location = new System.Drawing.Point(216, 155);
            this.PatientsInput.Name = "PatientsInput";
            this.PatientsInput.Size = new System.Drawing.Size(153, 22);
            this.PatientsInput.TabIndex = 12;
            // 
            // ArrivalInput
            // 
            this.ArrivalInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArrivalInput.Location = new System.Drawing.Point(216, 127);
            this.ArrivalInput.Name = "ArrivalInput";
            this.ArrivalInput.Size = new System.Drawing.Size(153, 22);
            this.ArrivalInput.TabIndex = 11;
            // 
            // ReplicationPerCInput
            // 
            this.ReplicationPerCInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReplicationPerCInput.Location = new System.Drawing.Point(216, 87);
            this.ReplicationPerCInput.Name = "ReplicationPerCInput";
            this.ReplicationPerCInput.Size = new System.Drawing.Size(153, 22);
            this.ReplicationPerCInput.TabIndex = 10;
            // 
            // NurseInput
            // 
            this.NurseInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NurseInput.Location = new System.Drawing.Point(216, 59);
            this.NurseInput.Name = "NurseInput";
            this.NurseInput.Size = new System.Drawing.Size(153, 22);
            this.NurseInput.TabIndex = 9;
            // 
            // DoctorInput
            // 
            this.DoctorInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DoctorInput.Location = new System.Drawing.Point(216, 31);
            this.DoctorInput.Name = "DoctorInput";
            this.DoctorInput.Size = new System.Drawing.Size(153, 22);
            this.DoctorInput.TabIndex = 8;
            // 
            // ArrivalLabel
            // 
            this.ArrivalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArrivalLabel.AutoSize = true;
            this.ArrivalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ArrivalLabel.Location = new System.Drawing.Point(3, 124);
            this.ArrivalLabel.Name = "ArrivalLabel";
            this.ArrivalLabel.Size = new System.Drawing.Size(207, 28);
            this.ArrivalLabel.TabIndex = 6;
            this.ArrivalLabel.Text = "Arrival interval:";
            this.ArrivalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PatientsLabel
            // 
            this.PatientsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PatientsLabel.AutoSize = true;
            this.PatientsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PatientsLabel.Location = new System.Drawing.Point(3, 152);
            this.PatientsLabel.Name = "PatientsLabel";
            this.PatientsLabel.Size = new System.Drawing.Size(207, 28);
            this.PatientsLabel.TabIndex = 5;
            this.PatientsLabel.Text = "Patients entered:";
            this.PatientsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RepCombLabel
            // 
            this.RepCombLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RepCombLabel.AutoSize = true;
            this.RepCombLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RepCombLabel.Location = new System.Drawing.Point(3, 84);
            this.RepCombLabel.Name = "RepCombLabel";
            this.RepCombLabel.Size = new System.Drawing.Size(207, 40);
            this.RepCombLabel.TabIndex = 4;
            this.RepCombLabel.Text = "Replications per combination:";
            this.RepCombLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NurseLabel
            // 
            this.NurseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NurseLabel.AutoSize = true;
            this.NurseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NurseLabel.Location = new System.Drawing.Point(3, 56);
            this.NurseLabel.Name = "NurseLabel";
            this.NurseLabel.Size = new System.Drawing.Size(207, 28);
            this.NurseLabel.TabIndex = 4;
            this.NurseLabel.Text = "Nurses:";
            this.NurseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DoctorLabel
            // 
            this.DoctorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DoctorLabel.AutoSize = true;
            this.DoctorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DoctorLabel.Location = new System.Drawing.Point(3, 28);
            this.DoctorLabel.Name = "DoctorLabel";
            this.DoctorLabel.Size = new System.Drawing.Size(207, 28);
            this.DoctorLabel.TabIndex = 1;
            this.DoctorLabel.Text = "Doctors:";
            this.DoctorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AdminLabel
            // 
            this.AdminLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminLabel.AutoSize = true;
            this.AdminLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AdminLabel.Location = new System.Drawing.Point(3, 0);
            this.AdminLabel.Name = "AdminLabel";
            this.AdminLabel.Size = new System.Drawing.Size(207, 28);
            this.AdminLabel.TabIndex = 0;
            this.AdminLabel.Text = "Admin.:";
            this.AdminLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AdminInput
            // 
            this.AdminInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminInput.Location = new System.Drawing.Point(216, 3);
            this.AdminInput.Name = "AdminInput";
            this.AdminInput.Size = new System.Drawing.Size(153, 22);
            this.AdminInput.TabIndex = 7;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(1539, 310);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(115, 32);
            this.ConfirmButton.TabIndex = 4;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            // 
            // StartPauseButton
            // 
            this.StartPauseButton.Location = new System.Drawing.Point(12, 246);
            this.StartPauseButton.Name = "StartPauseButton";
            this.StartPauseButton.Size = new System.Drawing.Size(92, 39);
            this.StartPauseButton.TabIndex = 5;
            this.StartPauseButton.Text = "Start";
            this.StartPauseButton.UseVisualStyleBackColor = true;
            this.StartPauseButton.Click += new System.EventHandler(this.StartPauseButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(12, 303);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(92, 39);
            this.StopButton.TabIndex = 6;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // DependenceGraph
            // 
            this.DependenceGraph.Location = new System.Drawing.Point(195, 79);
            this.DependenceGraph.Name = "DependenceGraph";
            this.DependenceGraph.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.DependenceGraph.Size = new System.Drawing.Size(1183, 291);
            this.DependenceGraph.TabIndex = 7;
            this.DependenceGraph.Text = "DepndenceGraph";
            this.DependenceGraph.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.DependenceGraph.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.DependenceGraph.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // NumOfAdmin
            // 
            this.NumOfAdmin.HeaderText = "N. of administrators";
            this.NumOfAdmin.MinimumWidth = 6;
            this.NumOfAdmin.Name = "NumOfAdmin";
            this.NumOfAdmin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NumOfAdmin.Width = 125;
            // 
            // AdminUtilization
            // 
            this.AdminUtilization.HeaderText = "Admin utilization";
            this.AdminUtilization.MinimumWidth = 6;
            this.AdminUtilization.Name = "AdminUtilization";
            this.AdminUtilization.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AdminUtilization.Width = 125;
            // 
            // AvgAdminQL
            // 
            this.AvgAdminQL.HeaderText = "Mean admin. QLength";
            this.AvgAdminQL.MinimumWidth = 6;
            this.AvgAdminQL.Name = "AvgAdminQL";
            this.AvgAdminQL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AvgAdminQL.Width = 125;
            // 
            // AvgAdminWTime
            // 
            this.AvgAdminWTime.HeaderText = "Mean admin. WTime";
            this.AvgAdminWTime.MinimumWidth = 6;
            this.AvgAdminWTime.Name = "AvgAdminWTime";
            this.AvgAdminWTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AvgAdminWTime.Width = 125;
            // 
            // NumOfDoctors
            // 
            this.NumOfDoctors.HeaderText = "N. of doctors";
            this.NumOfDoctors.MinimumWidth = 6;
            this.NumOfDoctors.Name = "NumOfDoctors";
            this.NumOfDoctors.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NumOfDoctors.Width = 125;
            // 
            // DoctorUtilization
            // 
            this.DoctorUtilization.HeaderText = "Doctors utilization";
            this.DoctorUtilization.MinimumWidth = 6;
            this.DoctorUtilization.Name = "DoctorUtilization";
            this.DoctorUtilization.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DoctorUtilization.Width = 125;
            // 
            // MeanExamQLenth
            // 
            this.MeanExamQLenth.HeaderText = "Mean exam. QLength";
            this.MeanExamQLenth.MinimumWidth = 6;
            this.MeanExamQLenth.Name = "MeanExamQLenth";
            this.MeanExamQLenth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MeanExamQLenth.Width = 125;
            // 
            // MeanExamWTime
            // 
            this.MeanExamWTime.HeaderText = "Mean exam. WTime";
            this.MeanExamWTime.MinimumWidth = 6;
            this.MeanExamWTime.Name = "MeanExamWTime";
            this.MeanExamWTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MeanExamWTime.Width = 125;
            // 
            // NumOfNurse
            // 
            this.NumOfNurse.HeaderText = "N. of nurses";
            this.NumOfNurse.MinimumWidth = 6;
            this.NumOfNurse.Name = "NumOfNurse";
            this.NumOfNurse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NumOfNurse.Width = 125;
            // 
            // NurseUtilization
            // 
            this.NurseUtilization.HeaderText = "Nurse utilization";
            this.NurseUtilization.MinimumWidth = 6;
            this.NurseUtilization.Name = "NurseUtilization";
            this.NurseUtilization.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NurseUtilization.Width = 125;
            // 
            // MeanVaccQLength
            // 
            this.MeanVaccQLength.HeaderText = "Mean vacc. QLength";
            this.MeanVaccQLength.MinimumWidth = 6;
            this.MeanVaccQLength.Name = "MeanVaccQLength";
            this.MeanVaccQLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MeanVaccQLength.Width = 125;
            // 
            // MeanVaccWTime
            // 
            this.MeanVaccWTime.HeaderText = "Mean vacc. WTime";
            this.MeanVaccWTime.MinimumWidth = 6;
            this.MeanVaccWTime.Name = "MeanVaccWTime";
            this.MeanVaccWTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MeanVaccWTime.Width = 125;
            // 
            // MeanWRoomCapacity
            // 
            this.MeanWRoomCapacity.HeaderText = "Mean w. room occupation";
            this.MeanWRoomCapacity.MinimumWidth = 6;
            this.MeanWRoomCapacity.Name = "MeanWRoomCapacity";
            this.MeanWRoomCapacity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MeanWRoomCapacity.Width = 125;
            // 
            // StaffExperimentalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DependenceGraph);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartPauseButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ExperimentResultsGridView);
            this.Controls.Add(this.ScreenTitleLabel);
            this.Controls.Add(this.OptionsLabel);
            this.Name = "StaffExperimentalControl";
            this.Size = new System.Drawing.Size(1787, 666);
            ((System.ComponentModel.ISupportInitialize)(this.ExperimentResultsGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OptionsLabel;
        private System.Windows.Forms.Label ScreenTitleLabel;
        private System.Windows.Forms.DataGridView ExperimentResultsGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox PatientsInput;
        private System.Windows.Forms.TextBox ArrivalInput;
        private System.Windows.Forms.TextBox ReplicationPerCInput;
        private System.Windows.Forms.TextBox NurseInput;
        private System.Windows.Forms.TextBox DoctorInput;
        private System.Windows.Forms.Label ArrivalLabel;
        private System.Windows.Forms.Label PatientsLabel;
        private System.Windows.Forms.Label RepCombLabel;
        private System.Windows.Forms.Label NurseLabel;
        private System.Windows.Forms.Label DoctorLabel;
        private System.Windows.Forms.Label AdminLabel;
        private System.Windows.Forms.TextBox AdminInput;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button StartPauseButton;
        private System.Windows.Forms.Button StopButton;
        private OxyPlot.WindowsForms.PlotView DependenceGraph;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumOfAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdminUtilization;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgAdminQL;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgAdminWTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumOfDoctors;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorUtilization;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeanExamQLenth;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeanExamWTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumOfNurse;
        private System.Windows.Forms.DataGridViewTextBoxColumn NurseUtilization;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeanVaccQLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeanVaccWTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeanWRoomCapacity;

        public string AdminInputText { get=>AdminInput.Text; set=>AdminInput.Text = value; }
        public string DoctorInputText { get=>DoctorInput.Text; set=>DoctorInput.Text = value; }
        public string NurseInputText { get=>NurseInput.Text; set=>NurseInput.Text = value; }
        public string ReplicationsInput { get=>ReplicationPerCInput.Text; set=>ReplicationPerCInput.Text = value; }
        public string ArrivalInputText { get=>ArrivalInput.Text; set=>ArrivalInput.Text = value; }
        public string PatientsInputText { get=>PatientsInput.Text; set=>PatientsInput.Text = value; }
    }
}
