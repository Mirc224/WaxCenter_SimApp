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
            this.SizeStat = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.ReadDelay = new WaxCenter_SimApp.GUIComponents.SimComponents.SimDelay();
            this.DlzkaStat = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.CakanieStat = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.PredajService = new WaxCenter_SimApp.GUIComponents.SimComponents.SimService();
            this.CustomerSink = new WaxCenter_SimApp.GUIComponents.SimComponents.SimSink();
            this.CustomersSource = new WaxCenter_SimApp.GUIComponents.SimComponents.SimSource();
            this.NewsPaperResPool = new WaxCenter_SimApp.GUIComponents.SimComponents.SimResourcePool();
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
            this.SimulationTopPanel.Size = new System.Drawing.Size(1555, 79);
            this.SimulationTopPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.SizeStat);
            this.panel1.Controls.Add(this.ReadDelay);
            this.panel1.Controls.Add(this.DlzkaStat);
            this.panel1.Controls.Add(this.CakanieStat);
            this.panel1.Controls.Add(this.PredajService);
            this.panel1.Controls.Add(this.CustomerSink);
            this.panel1.Controls.Add(this.CustomersSource);
            this.panel1.Controls.Add(this.NewsPaperResPool);
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
            this.panel1.Size = new System.Drawing.Size(1549, 728);
            this.panel1.TabIndex = 3;
            // 
            // SizeStat
            // 
            this.SizeStat.ID = -1;
            this.SizeStat.Location = new System.Drawing.Point(956, 475);
            this.SizeStat.Name = "SizeStat";
            this.SizeStat.SimulationControl = null;
            this.SizeStat.Size = new System.Drawing.Size(300, 65);
            this.SizeStat.TabIndex = 26;
            this.SizeStat.TitleText = "Pocet cakajucich";
            this.SizeStat.ValueText = "value label";
            // 
            // ReadDelay
            // 
            this.ReadDelay.AutoSize = true;
            this.ReadDelay.CurrentlyUsedText = "actual";
            this.ReadDelay.ID = -1;
            this.ReadDelay.InputText = "input";
            this.ReadDelay.Location = new System.Drawing.Point(557, 570);
            this.ReadDelay.Name = "ReadDelay";
            this.ReadDelay.OutputText = "output";
            this.ReadDelay.SimulationControl = null;
            this.ReadDelay.Size = new System.Drawing.Size(161, 137);
            this.ReadDelay.TabIndex = 25;
            this.ReadDelay.TitleText = "Citanie novin";
            // 
            // DlzkaStat
            // 
            this.DlzkaStat.ID = -1;
            this.DlzkaStat.Location = new System.Drawing.Point(498, 476);
            this.DlzkaStat.Name = "DlzkaStat";
            this.DlzkaStat.SimulationControl = null;
            this.DlzkaStat.Size = new System.Drawing.Size(400, 64);
            this.DlzkaStat.TabIndex = 24;
            this.DlzkaStat.TitleText = "Priemerna dlzka radu";
            this.DlzkaStat.ValueText = "value label";
            // 
            // CakanieStat
            // 
            this.CakanieStat.ID = -1;
            this.CakanieStat.Location = new System.Drawing.Point(180, 476);
            this.CakanieStat.Name = "CakanieStat";
            this.CakanieStat.SimulationControl = null;
            this.CakanieStat.Size = new System.Drawing.Size(393, 64);
            this.CakanieStat.TabIndex = 23;
            this.CakanieStat.TitleText = "Priemerna doba cakania";
            this.CakanieStat.ValueText = "value label";
            // 
            // PredajService
            // 
            this.PredajService.CurrentlyUsedText = "dActual";
            this.PredajService.ID = -1;
            this.PredajService.InputText = "input";
            this.PredajService.Location = new System.Drawing.Point(180, 562);
            this.PredajService.Name = "PredajService";
            this.PredajService.OutputText = "output";
            this.PredajService.QueueText = "qActual";
            this.PredajService.SimulationControl = null;
            this.PredajService.Size = new System.Drawing.Size(243, 145);
            this.PredajService.TabIndex = 22;
            this.PredajService.TitleText = "Predaj novin";
            // 
            // CustomerSink
            // 
            this.CustomerSink.ID = -1;
            this.CustomerSink.InputText = "output";
            this.CustomerSink.Location = new System.Drawing.Point(800, 562);
            this.CustomerSink.Name = "CustomerSink";
            this.CustomerSink.SimulationControl = null;
            this.CustomerSink.Size = new System.Drawing.Size(196, 145);
            this.CustomerSink.TabIndex = 21;
            this.CustomerSink.TitleText = "Odchod zakanzika";
            // 
            // CustomersSource
            // 
            this.CustomersSource.ID = -1;
            this.CustomersSource.Location = new System.Drawing.Point(18, 562);
            this.CustomersSource.Name = "CustomersSource";
            this.CustomersSource.OutputText = "0";
            this.CustomersSource.SimulationControl = null;
            this.CustomersSource.Size = new System.Drawing.Size(93, 149);
            this.CustomersSource.TabIndex = 20;
            this.CustomersSource.TitleText = "Zakaznici";
            // 
            // NewsPaperResPool
            // 
            this.NewsPaperResPool.ID = -1;
            this.NewsPaperResPool.Location = new System.Drawing.Point(1019, 562);
            this.NewsPaperResPool.Name = "NewsPaperResPool";
            this.NewsPaperResPool.SimulationControl = null;
            this.NewsPaperResPool.Size = new System.Drawing.Size(170, 145);
            this.NewsPaperResPool.StaffUsedText = "staffUsed";
            this.NewsPaperResPool.TabIndex = 19;
            this.NewsPaperResPool.TitleText = "Predavačka novín";
            this.NewsPaperResPool.UtilizationText = "utilization%";
            // 
            // SimulationClock
            // 
            this.SimulationClock.ClockText = "0,0";
            this.SimulationClock.Location = new System.Drawing.Point(1257, 549);
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
            this.StatWaitingRoomCapacity.Location = new System.Drawing.Point(1224, 80);
            this.StatWaitingRoomCapacity.Name = "StatWaitingRoomCapacity";
            this.StatWaitingRoomCapacity.SimulationControl = null;
            this.StatWaitingRoomCapacity.Size = new System.Drawing.Size(289, 58);
            this.StatWaitingRoomCapacity.TabIndex = 17;
            this.StatWaitingRoomCapacity.TitleText = "Avg počet čakajúcich";
            this.StatWaitingRoomCapacity.ValueText = "value label";
            // 
            // StatVaccinationQlength
            // 
            this.StatVaccinationQlength.ID = -1;
            this.StatVaccinationQlength.Location = new System.Drawing.Point(893, 80);
            this.StatVaccinationQlength.Name = "StatVaccinationQlength";
            this.StatVaccinationQlength.SimulationControl = null;
            this.StatVaccinationQlength.Size = new System.Drawing.Size(363, 58);
            this.StatVaccinationQlength.TabIndex = 16;
            this.StatVaccinationQlength.TitleText = "Avg dĺžka radu - Vyšetrenie";
            this.StatVaccinationQlength.ValueText = "value label";
            // 
            // StatVaccinationWaitingTime
            // 
            this.StatVaccinationWaitingTime.ID = -1;
            this.StatVaccinationWaitingTime.Location = new System.Drawing.Point(893, 16);
            this.StatVaccinationWaitingTime.Name = "StatVaccinationWaitingTime";
            this.StatVaccinationWaitingTime.SimulationControl = null;
            this.StatVaccinationWaitingTime.Size = new System.Drawing.Size(363, 58);
            this.StatVaccinationWaitingTime.TabIndex = 15;
            this.StatVaccinationWaitingTime.TitleText = "Avg čas čakania - Očkovanie";
            this.StatVaccinationWaitingTime.ValueText = "value label";
            // 
            // StatExaminationWaitingTime
            // 
            this.StatExaminationWaitingTime.ID = -1;
            this.StatExaminationWaitingTime.Location = new System.Drawing.Point(498, 16);
            this.StatExaminationWaitingTime.Name = "StatExaminationWaitingTime";
            this.StatExaminationWaitingTime.SimulationControl = null;
            this.StatExaminationWaitingTime.Size = new System.Drawing.Size(374, 58);
            this.StatExaminationWaitingTime.TabIndex = 14;
            this.StatExaminationWaitingTime.TitleText = "Avg čas čakania - Vyšetrenie";
            this.StatExaminationWaitingTime.ValueText = "value label";
            // 
            // StatExaminationQlength
            // 
            this.StatExaminationQlength.ID = -1;
            this.StatExaminationQlength.Location = new System.Drawing.Point(498, 80);
            this.StatExaminationQlength.Name = "StatExaminationQlength";
            this.StatExaminationQlength.SimulationControl = null;
            this.StatExaminationQlength.Size = new System.Drawing.Size(374, 58);
            this.StatExaminationQlength.TabIndex = 13;
            this.StatExaminationQlength.TitleText = "Avg dĺžka radu - Vyšetrenie";
            this.StatExaminationQlength.ValueText = "value label";
            // 
            // StatAdminQLength
            // 
            this.StatAdminQLength.ID = -1;
            this.StatAdminQLength.Location = new System.Drawing.Point(108, 80);
            this.StatAdminQLength.Name = "StatAdminQLength";
            this.StatAdminQLength.SimulationControl = null;
            this.StatAdminQLength.Size = new System.Drawing.Size(384, 58);
            this.StatAdminQLength.TabIndex = 12;
            this.StatAdminQLength.TitleText = "Avg dĺžka radu - Administracia";
            this.StatAdminQLength.ValueText = "value label";
            // 
            // StatAdminWaitingTime
            // 
            this.StatAdminWaitingTime.ID = -1;
            this.StatAdminWaitingTime.Location = new System.Drawing.Point(108, 16);
            this.StatAdminWaitingTime.Name = "StatAdminWaitingTime";
            this.StatAdminWaitingTime.SimulationControl = null;
            this.StatAdminWaitingTime.Size = new System.Drawing.Size(384, 58);
            this.StatAdminWaitingTime.TabIndex = 11;
            this.StatAdminWaitingTime.TitleText = "Avg čas čakania - Administracia";
            this.StatAdminWaitingTime.ValueText = "value label";
            // 
            // ResPoolNurse
            // 
            this.ResPoolNurse.ID = -1;
            this.ResPoolNurse.Location = new System.Drawing.Point(995, 299);
            this.ResPoolNurse.Name = "ResPoolNurse";
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
            this.ResPoolDoctor.Location = new System.Drawing.Point(623, 303);
            this.ResPoolDoctor.Name = "ResPoolDoctor";
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
            this.ResPoolAdmin.Location = new System.Drawing.Point(208, 303);
            this.ResPoolAdmin.Name = "ResPoolAdmin";
            this.ResPoolAdmin.SimulationControl = null;
            this.ResPoolAdmin.Size = new System.Drawing.Size(230, 145);
            this.ResPoolAdmin.StaffUsedText = "staffUsed";
            this.ResPoolAdmin.TabIndex = 8;
            this.ResPoolAdmin.TitleText = "Administratívny pracovník";
            this.ResPoolAdmin.UtilizationText = "utilization%";
            // 
            // PatientSink
            // 
            this.PatientSink.ID = -1;
            this.PatientSink.InputText = "output";
            this.PatientSink.Location = new System.Drawing.Point(1419, 144);
            this.PatientSink.Name = "PatientSink";
            this.PatientSink.SimulationControl = null;
            this.PatientSink.Size = new System.Drawing.Size(106, 141);
            this.PatientSink.TabIndex = 6;
            this.PatientSink.TitleText = "Východ";
            // 
            // PatientSource
            // 
            this.PatientSource.ID = -1;
            this.PatientSource.Location = new System.Drawing.Point(18, 152);
            this.PatientSource.Name = "PatientSource";
            this.PatientSource.OutputText = "0";
            this.PatientSource.SimulationControl = null;
            this.PatientSource.Size = new System.Drawing.Size(161, 141);
            this.PatientSource.TabIndex = 5;
            this.PatientSource.TitleText = "Zdroj pacientov";
            // 
            // DelayWaitingRoom
            // 
            this.DelayWaitingRoom.AutoSize = true;
            this.DelayWaitingRoom.CurrentlyUsedText = "actual";
            this.DelayWaitingRoom.ID = -1;
            this.DelayWaitingRoom.InputText = "input";
            this.DelayWaitingRoom.Location = new System.Drawing.Point(1224, 144);
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
            this.ServiceVaccination.Location = new System.Drawing.Point(925, 144);
            this.ServiceVaccination.Name = "ServiceVaccination";
            this.ServiceVaccination.OutputText = "output";
            this.ServiceVaccination.QueueText = "qActual";
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
            this.ServiceExamination.Location = new System.Drawing.Point(557, 144);
            this.ServiceExamination.Name = "ServiceExamination";
            this.ServiceExamination.OutputText = "output";
            this.ServiceExamination.QueueText = "qActual";
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
            this.ServiceAdministracia.Location = new System.Drawing.Point(208, 144);
            this.ServiceAdministracia.Name = "ServiceAdministracia";
            this.ServiceAdministracia.OutputText = "output";
            this.ServiceAdministracia.QueueText = "qActual";
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
            this.Name = "SimulationControl";
            this.Size = new System.Drawing.Size(1555, 810);
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
        private SimStats DlzkaStat;
        private SimStats CakanieStat;
        private SimService PredajService;
        private SimSink CustomerSink;
        private SimSource CustomersSource;
        private SimResourcePool NewsPaperResPool;
        private SimStats SizeStat;
        private SimDelay ReadDelay;
    }
}
