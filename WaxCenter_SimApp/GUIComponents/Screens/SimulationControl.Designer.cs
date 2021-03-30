using WaxCenter_SimApp.GUIComponents.SimComponents;
namespace WaxCenter_SimApp.GUIComponents.Screens
{
    partial class SimulationControl
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
            this.SimulationTitleLabel = new System.Windows.Forms.Label();
            this.SimulationTopPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SimulationClock = new WaxCenter_SimApp.GUIComponents.Clock.SimulationClock();
            this.StatWaitingRoomCapacity = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.StatVaccinationQlength = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.StatVaccinationWaitingTime = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.StatExaminationWaitingTime = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.StatExaminationQlength = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.StatAdminQLength = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.StatAdminWaitingTime = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.ResPoolNurse = new WaxCenter_SimApp.GUIComponents.SimComponents.SimResourcePool();
            this.ResPoolDoctor = new WaxCenter_SimApp.GUIComponents.SimComponents.SimResourcePool();
            this.ResPoolAdmin = new WaxCenter_SimApp.GUIComponents.SimComponents.SimResourcePool();
            this.PatientSink = new WaxCenter_SimApp.GUIComponents.SimComponents.SimSink();
            this.PatientSource = new WaxCenter_SimApp.GUIComponents.SimComponents.SimSource();
            this.DelayWaitingRoom = new WaxCenter_SimApp.GUIComponents.SimComponents.SimDelay();
            this.ServiceVaccination = new WaxCenter_SimApp.GUIComponents.SimComponents.SimService();
            this.ServiceExamination = new WaxCenter_SimApp.GUIComponents.SimComponents.SimService();
            this.ServiceAdministracia = new WaxCenter_SimApp.GUIComponents.SimComponents.SimService();
            this.SimulationTopPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SimulationTitleLabel
            // 
            this.SimulationTitleLabel.AutoSize = true;
            this.SimulationTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SimulationTitleLabel.Location = new System.Drawing.Point(3, 14);
            this.SimulationTitleLabel.Name = "SimulationTitleLabel";
            this.SimulationTitleLabel.Size = new System.Drawing.Size(178, 38);
            this.SimulationTitleLabel.TabIndex = 0;
            this.SimulationTitleLabel.Text = "Simulation";
            // 
            // SimulationTopPanel
            // 
            this.SimulationTopPanel.Controls.Add(this.SimulationTitleLabel);
            this.SimulationTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SimulationTopPanel.Location = new System.Drawing.Point(0, 0);
            this.SimulationTopPanel.Name = "SimulationTopPanel";
            this.SimulationTopPanel.Size = new System.Drawing.Size(1920, 243);
            this.SimulationTopPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.SimulationClock);
            this.panel1.Controls.Add(this.StatWaitingRoomCapacity);
            this.panel1.Controls.Add(this.StatVaccinationQlength);
            this.panel1.Controls.Add(this.StatVaccinationWaitingTime);
            this.panel1.Controls.Add(this.StatExaminationWaitingTime);
            this.panel1.Controls.Add(this.StatExaminationQlength);
            this.panel1.Controls.Add(this.StatAdminQLength);
            this.panel1.Controls.Add(this.StatAdminWaitingTime);
            this.panel1.Controls.Add(this.ResPoolNurse);
            this.panel1.Controls.Add(this.ResPoolDoctor);
            this.panel1.Controls.Add(this.ResPoolAdmin);
            this.panel1.Controls.Add(this.PatientSink);
            this.panel1.Controls.Add(this.PatientSource);
            this.panel1.Controls.Add(this.DelayWaitingRoom);
            this.panel1.Controls.Add(this.ServiceVaccination);
            this.panel1.Controls.Add(this.ServiceExamination);
            this.panel1.Controls.Add(this.ServiceAdministracia);
            this.panel1.Location = new System.Drawing.Point(3, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2298, 882);
            this.panel1.TabIndex = 3;
            // 
            // SimulationClock
            // 
            this.SimulationClock.ClockText = "0,0";
            this.SimulationClock.Location = new System.Drawing.Point(1115, 373);
            this.SimulationClock.Name = "SimulationClock";
            this.SimulationClock.SimulationControl = null;
            this.SimulationClock.Size = new System.Drawing.Size(256, 162);
            this.SimulationClock.StartPauseButtonEnabled = true;
            this.SimulationClock.StartPauseButtonText = "Start";
            this.SimulationClock.StopButtonEnabled = true;
            this.SimulationClock.TabIndex = 18;
            // 
            // StatWaitingRoomCapacity
            // 
            this.StatWaitingRoomCapacity.ID = -1;
            this.StatWaitingRoomCapacity.Location = new System.Drawing.Point(1242, 70);
            this.StatWaitingRoomCapacity.Name = "StatWaitingRoomCapacity";
            this.StatWaitingRoomCapacity.SimulationControl = null;
            this.StatWaitingRoomCapacity.Size = new System.Drawing.Size(314, 58);
            this.StatWaitingRoomCapacity.StatisticModel = null;
            this.StatWaitingRoomCapacity.TabIndex = 17;
            this.StatWaitingRoomCapacity.TitleText = "Avg počet čakajúcich";
            this.StatWaitingRoomCapacity.ValueText = "value label";
            // 
            // StatVaccinationQlength
            // 
            this.StatVaccinationQlength.ID = -1;
            this.StatVaccinationQlength.Location = new System.Drawing.Point(873, 70);
            this.StatVaccinationQlength.Name = "StatVaccinationQlength";
            this.StatVaccinationQlength.SimulationControl = null;
            this.StatVaccinationQlength.Size = new System.Drawing.Size(363, 58);
            this.StatVaccinationQlength.StatisticModel = null;
            this.StatVaccinationQlength.TabIndex = 16;
            this.StatVaccinationQlength.TitleText = "Avg dĺžka radu - Vyšetrenie";
            this.StatVaccinationQlength.ValueText = "value label";
            // 
            // StatVaccinationWaitingTime
            // 
            this.StatVaccinationWaitingTime.ID = -1;
            this.StatVaccinationWaitingTime.Location = new System.Drawing.Point(873, 6);
            this.StatVaccinationWaitingTime.Name = "StatVaccinationWaitingTime";
            this.StatVaccinationWaitingTime.SimulationControl = null;
            this.StatVaccinationWaitingTime.Size = new System.Drawing.Size(363, 58);
            this.StatVaccinationWaitingTime.StatisticModel = null;
            this.StatVaccinationWaitingTime.TabIndex = 15;
            this.StatVaccinationWaitingTime.TitleText = "Avg čas čakania - Očkovanie";
            this.StatVaccinationWaitingTime.ValueText = "value label";
            // 
            // StatExaminationWaitingTime
            // 
            this.StatExaminationWaitingTime.ID = -1;
            this.StatExaminationWaitingTime.Location = new System.Drawing.Point(452, 6);
            this.StatExaminationWaitingTime.Name = "StatExaminationWaitingTime";
            this.StatExaminationWaitingTime.SimulationControl = null;
            this.StatExaminationWaitingTime.Size = new System.Drawing.Size(374, 58);
            this.StatExaminationWaitingTime.StatisticModel = null;
            this.StatExaminationWaitingTime.TabIndex = 14;
            this.StatExaminationWaitingTime.TitleText = "Avg čas čakania - Vyšetrenie";
            this.StatExaminationWaitingTime.ValueText = "value label";
            // 
            // StatExaminationQlength
            // 
            this.StatExaminationQlength.ID = -1;
            this.StatExaminationQlength.Location = new System.Drawing.Point(452, 70);
            this.StatExaminationQlength.Name = "StatExaminationQlength";
            this.StatExaminationQlength.SimulationControl = null;
            this.StatExaminationQlength.Size = new System.Drawing.Size(374, 58);
            this.StatExaminationQlength.StatisticModel = null;
            this.StatExaminationQlength.TabIndex = 13;
            this.StatExaminationQlength.TitleText = "Avg dĺžka radu - Vyšetrenie";
            this.StatExaminationQlength.ValueText = "value label";
            // 
            // StatAdminQLength
            // 
            this.StatAdminQLength.ID = -1;
            this.StatAdminQLength.Location = new System.Drawing.Point(7, 70);
            this.StatAdminQLength.Name = "StatAdminQLength";
            this.StatAdminQLength.SimulationControl = null;
            this.StatAdminQLength.Size = new System.Drawing.Size(384, 58);
            this.StatAdminQLength.StatisticModel = null;
            this.StatAdminQLength.TabIndex = 12;
            this.StatAdminQLength.TitleText = "Avg dĺžka radu - Administracia";
            this.StatAdminQLength.ValueText = "value label";
            // 
            // StatAdminWaitingTime
            // 
            this.StatAdminWaitingTime.ID = -1;
            this.StatAdminWaitingTime.Location = new System.Drawing.Point(7, 6);
            this.StatAdminWaitingTime.Name = "StatAdminWaitingTime";
            this.StatAdminWaitingTime.SimulationControl = null;
            this.StatAdminWaitingTime.Size = new System.Drawing.Size(384, 58);
            this.StatAdminWaitingTime.StatisticModel = null;
            this.StatAdminWaitingTime.TabIndex = 11;
            this.StatAdminWaitingTime.TitleText = "Avg čas čakania - Administracia";
            this.StatAdminWaitingTime.ValueText = "value label";
            // 
            // ResPoolNurse
            // 
            this.ResPoolNurse.ID = -1;
            this.ResPoolNurse.Location = new System.Drawing.Point(873, 386);
            this.ResPoolNurse.Name = "ResPoolNurse";
            this.ResPoolNurse.ServiceModelComponent = null;
            this.ResPoolNurse.SimulationControl = null;
            this.ResPoolNurse.Size = new System.Drawing.Size(95, 145);
            this.ResPoolNurse.StaffUsedText = "staffUsed";
            this.ResPoolNurse.TabIndex = 10;
            this.ResPoolNurse.TitleText = "Sestrička";
            this.ResPoolNurse.UtilizationText = "utilization%";
            // 
            // ResPoolDoctor
            // 
            this.ResPoolDoctor.ID = -1;
            this.ResPoolDoctor.Location = new System.Drawing.Point(567, 390);
            this.ResPoolDoctor.Name = "ResPoolDoctor";
            this.ResPoolDoctor.ServiceModelComponent = null;
            this.ResPoolDoctor.SimulationControl = null;
            this.ResPoolDoctor.Size = new System.Drawing.Size(95, 141);
            this.ResPoolDoctor.StaffUsedText = "staffUsed";
            this.ResPoolDoctor.TabIndex = 9;
            this.ResPoolDoctor.TitleText = "Doktor";
            this.ResPoolDoctor.UtilizationText = "utilization%";
            // 
            // ResPoolAdmin
            // 
            this.ResPoolAdmin.ID = -1;
            this.ResPoolAdmin.Location = new System.Drawing.Point(209, 390);
            this.ResPoolAdmin.Name = "ResPoolAdmin";
            this.ResPoolAdmin.ServiceModelComponent = null;
            this.ResPoolAdmin.SimulationControl = null;
            this.ResPoolAdmin.Size = new System.Drawing.Size(309, 145);
            this.ResPoolAdmin.StaffUsedText = "staffUsed";
            this.ResPoolAdmin.TabIndex = 8;
            this.ResPoolAdmin.TitleText = "Administratívny pracovník";
            this.ResPoolAdmin.UtilizationText = "utilization%";
            // 
            // PatientSink
            // 
            this.PatientSink.ID = -1;
            this.PatientSink.InputText = "output";
            this.PatientSink.Location = new System.Drawing.Point(1315, 212);
            this.PatientSink.Name = "PatientSink";
            this.PatientSink.SimulationControl = null;
            this.PatientSink.SinkModelComponent = null;
            this.PatientSink.Size = new System.Drawing.Size(106, 141);
            this.PatientSink.TabIndex = 6;
            this.PatientSink.TitleText = "Východ";
            // 
            // PatientSource
            // 
            this.PatientSource.ID = -1;
            this.PatientSource.Location = new System.Drawing.Point(7, 212);
            this.PatientSource.Name = "PatientSource";
            this.PatientSource.OutputText = "0";
            this.PatientSource.SimulationControl = null;
            this.PatientSource.Size = new System.Drawing.Size(161, 141);
            this.PatientSource.SourceModelComponent = null;
            this.PatientSource.TabIndex = 5;
            this.PatientSource.TitleText = "Zdroj pacientov";
            // 
            // DelayWaitingRoom
            // 
            this.DelayWaitingRoom.AutoSize = true;
            this.DelayWaitingRoom.CurrentlyUsedText = "actual";
            this.DelayWaitingRoom.DelayModelComponent = null;
            this.DelayWaitingRoom.ID = -1;
            this.DelayWaitingRoom.InputText = "input";
            this.DelayWaitingRoom.Location = new System.Drawing.Point(1115, 212);
            this.DelayWaitingRoom.Name = "DelayWaitingRoom";
            this.DelayWaitingRoom.OutputText = "output";
            this.DelayWaitingRoom.SimulationControl = null;
            this.DelayWaitingRoom.Size = new System.Drawing.Size(134, 149);
            this.DelayWaitingRoom.TabIndex = 4;
            this.DelayWaitingRoom.TitleText = "Čakáreň";
            // 
            // ServiceVaccination
            // 
            this.ServiceVaccination.CurrentlyUsedText = "dActual";
            this.ServiceVaccination.ID = -1;
            this.ServiceVaccination.InputText = "input";
            this.ServiceVaccination.Location = new System.Drawing.Point(793, 212);
            this.ServiceVaccination.Name = "ServiceVaccination";
            this.ServiceVaccination.OutputText = "output";
            this.ServiceVaccination.QueueText = "qActual";
            this.ServiceVaccination.ServiceModelComponent = null;
            this.ServiceVaccination.SimulationControl = null;
            this.ServiceVaccination.Size = new System.Drawing.Size(229, 149);
            this.ServiceVaccination.TabIndex = 3;
            this.ServiceVaccination.TitleText = "Očkovanie";
            // 
            // ServiceExamination
            // 
            this.ServiceExamination.CurrentlyUsedText = "dActual";
            this.ServiceExamination.ID = -1;
            this.ServiceExamination.InputText = "input";
            this.ServiceExamination.Location = new System.Drawing.Point(489, 212);
            this.ServiceExamination.Name = "ServiceExamination";
            this.ServiceExamination.OutputText = "output";
            this.ServiceExamination.QueueText = "qActual";
            this.ServiceExamination.ServiceModelComponent = null;
            this.ServiceExamination.SimulationControl = null;
            this.ServiceExamination.Size = new System.Drawing.Size(229, 141);
            this.ServiceExamination.TabIndex = 2;
            this.ServiceExamination.TitleText = "Vyšetrenie";
            // 
            // ServiceAdministracia
            // 
            this.ServiceAdministracia.CurrentlyUsedText = "dActual";
            this.ServiceAdministracia.ID = -1;
            this.ServiceAdministracia.InputText = "input";
            this.ServiceAdministracia.Location = new System.Drawing.Point(192, 212);
            this.ServiceAdministracia.Name = "ServiceAdministracia";
            this.ServiceAdministracia.OutputText = "output";
            this.ServiceAdministracia.QueueText = "qActual";
            this.ServiceAdministracia.ServiceModelComponent = null;
            this.ServiceAdministracia.SimulationControl = null;
            this.ServiceAdministracia.Size = new System.Drawing.Size(229, 141);
            this.ServiceAdministracia.TabIndex = 1;
            this.ServiceAdministracia.TitleText = "Administrácia";
            // 
            // SimulationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SimulationTopPanel);
            this.MinimumSize = new System.Drawing.Size(1536, 642);
            this.Name = "SimulationControl";
            this.Size = new System.Drawing.Size(1920, 803);
            this.SimulationTopPanel.ResumeLayout(false);
            this.SimulationTopPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label SimulationTitleLabel;
        private System.Windows.Forms.Panel SimulationTopPanel;
        private System.Windows.Forms.Panel panel1;
        private SimDelay DelayWaitingRoom;
        private SimService ServiceVaccination;
        private SimService ServiceExamination;
        private SimService ServiceAdministracia;
        private SimSink PatientSink;
        private SimSource PatientSource;
        private SimStats StatVaccinationQlength;
        private SimStats StatVaccinationWaitingTime;
        private SimStats StatExaminationWaitingTime;
        private SimStats StatExaminationQlength;
        private SimStats StatAdminQLength;
        private SimStats StatAdminWaitingTime;
        private SimResourcePool ResPoolNurse;
        private SimResourcePool ResPoolDoctor;
        private SimResourcePool ResPoolAdmin;
        private SimStats StatWaitingRoomCapacity;
        private Clock.SimulationClock SimulationClock;
    }
}
