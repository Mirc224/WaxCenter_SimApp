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
            this.OptionsLabel = new System.Windows.Forms.Label();
            this.SourceOptions = new WaxCenter_SimApp.GUIComponents.OptionsComponents.SimSourceOptions();
            this.ResPoolOptions = new WaxCenter_SimApp.GUIComponents.OptionsComponents.SimResPoolOptions();
            this.StatAdminWaitingTime = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.SimulationClock = new WaxCenter_SimApp.GUIComponents.Clock.SimulationClock();
            this.StatAdminQLength = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.ResPoolNurse = new WaxCenter_SimApp.GUIComponents.SimComponents.SimResourcePool();
            this.StatWaitingRoomCapacity = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.ResPoolDoctor = new WaxCenter_SimApp.GUIComponents.SimComponents.SimResourcePool();
            this.StatExaminationWaitingTime = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.ResPoolAdmin = new WaxCenter_SimApp.GUIComponents.SimComponents.SimResourcePool();
            this.StatVaccinationQlength = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.PatientSink = new WaxCenter_SimApp.GUIComponents.SimComponents.SimSink();
            this.StatExaminationQlength = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.DelayWaitingRoom = new WaxCenter_SimApp.GUIComponents.SimComponents.SimDelay();
            this.PatientSource = new WaxCenter_SimApp.GUIComponents.SimComponents.SimSource();
            this.ServiceVaccination = new WaxCenter_SimApp.GUIComponents.SimComponents.SimService();
            this.StatVaccinationWaitingTime = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.ServiceExamination = new WaxCenter_SimApp.GUIComponents.SimComponents.SimService();
            this.ServiceAdministracia = new WaxCenter_SimApp.GUIComponents.SimComponents.SimService();
            this.RealTimeSimulationWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // SimulationTitleLabel
            // 
            this.SimulationTitleLabel.AutoSize = true;
            this.SimulationTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SimulationTitleLabel.Location = new System.Drawing.Point(3, 0);
            this.SimulationTitleLabel.Name = "SimulationTitleLabel";
            this.SimulationTitleLabel.Size = new System.Drawing.Size(178, 38);
            this.SimulationTitleLabel.TabIndex = 0;
            this.SimulationTitleLabel.Text = "Simulation";
            // 
            // OptionsLabel
            // 
            this.OptionsLabel.AutoSize = true;
            this.OptionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OptionsLabel.Location = new System.Drawing.Point(1624, 347);
            this.OptionsLabel.Name = "OptionsLabel";
            this.OptionsLabel.Size = new System.Drawing.Size(121, 32);
            this.OptionsLabel.TabIndex = 21;
            this.OptionsLabel.Text = "Options";
            // 
            // SourceOptions
            // 
            this.SourceOptions.AgentsInputText = "";
            this.SourceOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SourceOptions.IntervalInputText = "";
            this.SourceOptions.Location = new System.Drawing.Point(1524, 382);
            this.SourceOptions.MinimumSize = new System.Drawing.Size(292, 142);
            this.SourceOptions.Name = "SourceOptions";
            this.SourceOptions.SimulationControl = null;
            this.SourceOptions.Size = new System.Drawing.Size(314, 167);
            this.SourceOptions.TabIndex = 22;
            // 
            // ResPoolOptions
            // 
            this.ResPoolOptions.Location = new System.Drawing.Point(1533, 396);
            this.ResPoolOptions.MinimumSize = new System.Drawing.Size(292, 142);
            this.ResPoolOptions.Name = "ResPoolOptions";
            this.ResPoolOptions.SelectedText = "Selected";
            this.ResPoolOptions.SimulationControl = null;
            this.ResPoolOptions.Size = new System.Drawing.Size(293, 142);
            this.ResPoolOptions.StaffInputText = "";
            this.ResPoolOptions.TabIndex = 20;
            // 
            // StatAdminWaitingTime
            // 
            this.StatAdminWaitingTime.ID = -1;
            this.StatAdminWaitingTime.Location = new System.Drawing.Point(3, 67);
            this.StatAdminWaitingTime.Name = "StatAdminWaitingTime";
            this.StatAdminWaitingTime.SimulationControl = null;
            this.StatAdminWaitingTime.Size = new System.Drawing.Size(384, 58);
            this.StatAdminWaitingTime.StatisticModel = null;
            this.StatAdminWaitingTime.TabIndex = 11;
            this.StatAdminWaitingTime.TitleText = "Avg čas čakania - Administracia";
            this.StatAdminWaitingTime.ValueText = "value label";
            // 
            // SimulationClock
            // 
            this.SimulationClock.ClockText = "0,0";
            this.SimulationClock.Location = new System.Drawing.Point(975, 444);
            this.SimulationClock.Name = "SimulationClock";
            this.SimulationClock.SimulationControl = null;
            this.SimulationClock.Size = new System.Drawing.Size(256, 162);
            this.SimulationClock.StartPauseButtonEnabled = true;
            this.SimulationClock.StartPauseButtonText = "Start";
            this.SimulationClock.StopButtonEnabled = true;
            this.SimulationClock.TabIndex = 18;
            // 
            // StatAdminQLength
            // 
            this.StatAdminQLength.ID = -1;
            this.StatAdminQLength.Location = new System.Drawing.Point(3, 131);
            this.StatAdminQLength.Name = "StatAdminQLength";
            this.StatAdminQLength.SimulationControl = null;
            this.StatAdminQLength.Size = new System.Drawing.Size(384, 58);
            this.StatAdminQLength.StatisticModel = null;
            this.StatAdminQLength.TabIndex = 12;
            this.StatAdminQLength.TitleText = "Avg dĺžka radu - Administracia";
            this.StatAdminQLength.ValueText = "value label";
            // 
            // ResPoolNurse
            // 
            this.ResPoolNurse.ID = -1;
            this.ResPoolNurse.Location = new System.Drawing.Point(823, 461);
            this.ResPoolNurse.Name = "ResPoolNurse";
            this.ResPoolNurse.ServiceModelComponent = null;
            this.ResPoolNurse.SimulationControl = null;
            this.ResPoolNurse.Size = new System.Drawing.Size(95, 145);
            this.ResPoolNurse.StaffUsedText = "staffUsed";
            this.ResPoolNurse.TabIndex = 10;
            this.ResPoolNurse.TitleText = "Sestrička";
            this.ResPoolNurse.UtilizationText = "utilization%";
            // 
            // StatWaitingRoomCapacity
            // 
            this.StatWaitingRoomCapacity.ID = -1;
            this.StatWaitingRoomCapacity.Location = new System.Drawing.Point(1259, 131);
            this.StatWaitingRoomCapacity.Name = "StatWaitingRoomCapacity";
            this.StatWaitingRoomCapacity.SimulationControl = null;
            this.StatWaitingRoomCapacity.Size = new System.Drawing.Size(314, 58);
            this.StatWaitingRoomCapacity.StatisticModel = null;
            this.StatWaitingRoomCapacity.TabIndex = 17;
            this.StatWaitingRoomCapacity.TitleText = "Avg počet čakajúcich";
            this.StatWaitingRoomCapacity.ValueText = "value label";
            // 
            // ResPoolDoctor
            // 
            this.ResPoolDoctor.ID = -1;
            this.ResPoolDoctor.Location = new System.Drawing.Point(551, 461);
            this.ResPoolDoctor.Name = "ResPoolDoctor";
            this.ResPoolDoctor.ServiceModelComponent = null;
            this.ResPoolDoctor.SimulationControl = null;
            this.ResPoolDoctor.Size = new System.Drawing.Size(95, 141);
            this.ResPoolDoctor.StaffUsedText = "staffUsed";
            this.ResPoolDoctor.TabIndex = 9;
            this.ResPoolDoctor.TitleText = "Doktor";
            this.ResPoolDoctor.UtilizationText = "utilization%";
            // 
            // StatExaminationWaitingTime
            // 
            this.StatExaminationWaitingTime.ID = -1;
            this.StatExaminationWaitingTime.Location = new System.Drawing.Point(433, 67);
            this.StatExaminationWaitingTime.Name = "StatExaminationWaitingTime";
            this.StatExaminationWaitingTime.SimulationControl = null;
            this.StatExaminationWaitingTime.Size = new System.Drawing.Size(374, 58);
            this.StatExaminationWaitingTime.StatisticModel = null;
            this.StatExaminationWaitingTime.TabIndex = 14;
            this.StatExaminationWaitingTime.TitleText = "Avg čas čakania - Vyšetrenie";
            this.StatExaminationWaitingTime.ValueText = "value label";
            // 
            // ResPoolAdmin
            // 
            this.ResPoolAdmin.ID = -1;
            this.ResPoolAdmin.Location = new System.Drawing.Point(166, 457);
            this.ResPoolAdmin.Name = "ResPoolAdmin";
            this.ResPoolAdmin.ServiceModelComponent = null;
            this.ResPoolAdmin.SimulationControl = null;
            this.ResPoolAdmin.Size = new System.Drawing.Size(309, 145);
            this.ResPoolAdmin.StaffUsedText = "staffUsed";
            this.ResPoolAdmin.TabIndex = 8;
            this.ResPoolAdmin.TitleText = "Administratívny pracovník";
            this.ResPoolAdmin.UtilizationText = "utilization%";
            // 
            // StatVaccinationQlength
            // 
            this.StatVaccinationQlength.ID = -1;
            this.StatVaccinationQlength.Location = new System.Drawing.Point(868, 131);
            this.StatVaccinationQlength.Name = "StatVaccinationQlength";
            this.StatVaccinationQlength.SimulationControl = null;
            this.StatVaccinationQlength.Size = new System.Drawing.Size(363, 58);
            this.StatVaccinationQlength.StatisticModel = null;
            this.StatVaccinationQlength.TabIndex = 16;
            this.StatVaccinationQlength.TitleText = "Avg dĺžka radu - Vyšetrenie";
            this.StatVaccinationQlength.ValueText = "value label";
            // 
            // PatientSink
            // 
            this.PatientSink.ID = -1;
            this.PatientSink.InputText = "output";
            this.PatientSink.Location = new System.Drawing.Point(1283, 238);
            this.PatientSink.Name = "PatientSink";
            this.PatientSink.SimulationControl = null;
            this.PatientSink.SinkModelComponent = null;
            this.PatientSink.Size = new System.Drawing.Size(106, 141);
            this.PatientSink.TabIndex = 6;
            this.PatientSink.TitleText = "Východ";
            // 
            // StatExaminationQlength
            // 
            this.StatExaminationQlength.ID = -1;
            this.StatExaminationQlength.Location = new System.Drawing.Point(433, 131);
            this.StatExaminationQlength.Name = "StatExaminationQlength";
            this.StatExaminationQlength.SimulationControl = null;
            this.StatExaminationQlength.Size = new System.Drawing.Size(374, 58);
            this.StatExaminationQlength.StatisticModel = null;
            this.StatExaminationQlength.TabIndex = 13;
            this.StatExaminationQlength.TitleText = "Avg dĺžka radu - Vyšetrenie";
            this.StatExaminationQlength.ValueText = "value label";
            // 
            // DelayWaitingRoom
            // 
            this.DelayWaitingRoom.AutoSize = true;
            this.DelayWaitingRoom.CurrentlyUsedText = "actual";
            this.DelayWaitingRoom.DelayModelComponent = null;
            this.DelayWaitingRoom.ID = -1;
            this.DelayWaitingRoom.InputText = "input";
            this.DelayWaitingRoom.Location = new System.Drawing.Point(1079, 238);
            this.DelayWaitingRoom.Name = "DelayWaitingRoom";
            this.DelayWaitingRoom.OutputText = "output";
            this.DelayWaitingRoom.SimulationControl = null;
            this.DelayWaitingRoom.Size = new System.Drawing.Size(134, 149);
            this.DelayWaitingRoom.TabIndex = 4;
            this.DelayWaitingRoom.TitleText = "Čakáreň";
            // 
            // PatientSource
            // 
            this.PatientSource.ID = -1;
            this.PatientSource.Location = new System.Drawing.Point(-1, 238);
            this.PatientSource.Name = "PatientSource";
            this.PatientSource.OutputText = "0";
            this.PatientSource.SimulationControl = null;
            this.PatientSource.Size = new System.Drawing.Size(161, 141);
            this.PatientSource.SourceModelComponent = null;
            this.PatientSource.TabIndex = 5;
            this.PatientSource.TitleText = "Zdroj pacientov";
            // 
            // ServiceVaccination
            // 
            this.ServiceVaccination.CurrentlyUsedText = "dActual";
            this.ServiceVaccination.ID = -1;
            this.ServiceVaccination.InputText = "input";
            this.ServiceVaccination.Location = new System.Drawing.Point(760, 238);
            this.ServiceVaccination.Name = "ServiceVaccination";
            this.ServiceVaccination.OutputText = "output";
            this.ServiceVaccination.QueueText = "qActual";
            this.ServiceVaccination.ServiceModelComponent = null;
            this.ServiceVaccination.SimulationControl = null;
            this.ServiceVaccination.Size = new System.Drawing.Size(229, 149);
            this.ServiceVaccination.TabIndex = 3;
            this.ServiceVaccination.TitleText = "Očkovanie";
            // 
            // StatVaccinationWaitingTime
            // 
            this.StatVaccinationWaitingTime.ID = -1;
            this.StatVaccinationWaitingTime.Location = new System.Drawing.Point(868, 67);
            this.StatVaccinationWaitingTime.Name = "StatVaccinationWaitingTime";
            this.StatVaccinationWaitingTime.SimulationControl = null;
            this.StatVaccinationWaitingTime.Size = new System.Drawing.Size(363, 58);
            this.StatVaccinationWaitingTime.StatisticModel = null;
            this.StatVaccinationWaitingTime.TabIndex = 15;
            this.StatVaccinationWaitingTime.TitleText = "Avg čas čakania - Očkovanie";
            this.StatVaccinationWaitingTime.ValueText = "value label";
            // 
            // ServiceExamination
            // 
            this.ServiceExamination.CurrentlyUsedText = "dActual";
            this.ServiceExamination.ID = -1;
            this.ServiceExamination.InputText = "input";
            this.ServiceExamination.Location = new System.Drawing.Point(457, 238);
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
            this.ServiceAdministracia.Location = new System.Drawing.Point(166, 238);
            this.ServiceAdministracia.Name = "ServiceAdministracia";
            this.ServiceAdministracia.OutputText = "output";
            this.ServiceAdministracia.QueueText = "qActual";
            this.ServiceAdministracia.ServiceModelComponent = null;
            this.ServiceAdministracia.SimulationControl = null;
            this.ServiceAdministracia.Size = new System.Drawing.Size(229, 141);
            this.ServiceAdministracia.TabIndex = 1;
            this.ServiceAdministracia.TitleText = "Administrácia";
            // 
            // RealTimeSimulationWorker
            // 
            this.RealTimeSimulationWorker.WorkerReportsProgress = true;
            this.RealTimeSimulationWorker.WorkerSupportsCancellation = true;
            this.RealTimeSimulationWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RealTimeSimulationWorker_DoWork);
            this.RealTimeSimulationWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.RealTimeSimulationWorker_ProgressChanged);
            this.RealTimeSimulationWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RealTimeSimulationWorker_RunWorkerCompleted);
            // 
            // SimulationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SourceOptions);
            this.Controls.Add(this.SimulationTitleLabel);
            this.Controls.Add(this.OptionsLabel);
            this.Controls.Add(this.ResPoolOptions);
            this.Controls.Add(this.StatAdminWaitingTime);
            this.Controls.Add(this.SimulationClock);
            this.Controls.Add(this.StatAdminQLength);
            this.Controls.Add(this.ResPoolNurse);
            this.Controls.Add(this.StatWaitingRoomCapacity);
            this.Controls.Add(this.ResPoolDoctor);
            this.Controls.Add(this.StatExaminationWaitingTime);
            this.Controls.Add(this.ResPoolAdmin);
            this.Controls.Add(this.StatVaccinationQlength);
            this.Controls.Add(this.PatientSink);
            this.Controls.Add(this.StatExaminationQlength);
            this.Controls.Add(this.DelayWaitingRoom);
            this.Controls.Add(this.PatientSource);
            this.Controls.Add(this.ServiceVaccination);
            this.Controls.Add(this.StatVaccinationWaitingTime);
            this.Controls.Add(this.ServiceExamination);
            this.Controls.Add(this.ServiceAdministracia);
            this.Name = "SimulationControl";
            this.Size = new System.Drawing.Size(1841, 619);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SimulationTitleLabel;
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
        private OptionsComponents.SimResPoolOptions ResPoolOptions;
        private System.Windows.Forms.Label OptionsLabel;
        private OptionsComponents.SimSourceOptions SourceOptions;
        private System.ComponentModel.BackgroundWorker RealTimeSimulationWorker;
    }
}
