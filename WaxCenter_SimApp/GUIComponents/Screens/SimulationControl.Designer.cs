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
            this.DlzkaStat = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.CakanieStat = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.PredajService = new WaxCenter_SimApp.GUIComponents.SimComponents.SimService();
            this.CustomerSink = new WaxCenter_SimApp.GUIComponents.SimComponents.SimSink();
            this.CustomersSource = new WaxCenter_SimApp.GUIComponents.SimComponents.SimSource();
            this.NewsPaperResPool = new WaxCenter_SimApp.GUIComponents.SimComponents.SimResourcePool();
            this.SimulationClock = new WaxCenter_SimApp.GUIComponents.Clock.SimulationClock();
            this.StatAvgNOWaiting = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.StatVaccinateQlength = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.StatVaccinateWaitingTime = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.StatCheckWaitingTime = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.StatCheckQlength = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.StatAdminQLength = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.StatAdminWaitingTime = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
            this.ResPoolNurse = new WaxCenter_SimApp.GUIComponents.SimComponents.SimResourcePool();
            this.ResPoolDoctor = new WaxCenter_SimApp.GUIComponents.SimComponents.SimResourcePool();
            this.ResPoolAdmin = new WaxCenter_SimApp.GUIComponents.SimComponents.SimResourcePool();
            this.DelaySelect = new WaxCenter_SimApp.GUIComponents.SimComponents.SimSelect2();
            this.ExitSink = new WaxCenter_SimApp.GUIComponents.SimComponents.SimSink();
            this.PatientSource = new WaxCenter_SimApp.GUIComponents.SimComponents.SimSource();
            this.DelayCakaren = new WaxCenter_SimApp.GUIComponents.SimComponents.SimDelay();
            this.ServiceOckovanie = new WaxCenter_SimApp.GUIComponents.SimComponents.SimService();
            this.ServiceVysetrenie = new WaxCenter_SimApp.GUIComponents.SimComponents.SimService();
            this.ServiceAdministracia = new WaxCenter_SimApp.GUIComponents.SimComponents.SimService();
            this.ReadDelay = new WaxCenter_SimApp.GUIComponents.SimComponents.SimDelay();
            this.SizeStat = new WaxCenter_SimApp.GUIComponents.SimComponents.SimStats();
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
            this.panel1.Controls.Add(this.StatAvgNOWaiting);
            this.panel1.Controls.Add(this.StatVaccinateQlength);
            this.panel1.Controls.Add(this.StatVaccinateWaitingTime);
            this.panel1.Controls.Add(this.StatCheckWaitingTime);
            this.panel1.Controls.Add(this.StatCheckQlength);
            this.panel1.Controls.Add(this.StatAdminQLength);
            this.panel1.Controls.Add(this.StatAdminWaitingTime);
            this.panel1.Controls.Add(this.ResPoolNurse);
            this.panel1.Controls.Add(this.ResPoolDoctor);
            this.panel1.Controls.Add(this.ResPoolAdmin);
            this.panel1.Controls.Add(this.DelaySelect);
            this.panel1.Controls.Add(this.ExitSink);
            this.panel1.Controls.Add(this.PatientSource);
            this.panel1.Controls.Add(this.DelayCakaren);
            this.panel1.Controls.Add(this.ServiceOckovanie);
            this.panel1.Controls.Add(this.ServiceVysetrenie);
            this.panel1.Controls.Add(this.ServiceAdministracia);
            this.panel1.Location = new System.Drawing.Point(3, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1549, 728);
            this.panel1.TabIndex = 3;
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
            this.PredajService.DelayText = "dActual";
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
            this.CustomerSink.CounterText = "output";
            this.CustomerSink.ID = -1;
            this.CustomerSink.Location = new System.Drawing.Point(800, 562);
            this.CustomerSink.Name = "CustomerSink";
            this.CustomerSink.SimulationControl = null;
            this.CustomerSink.Size = new System.Drawing.Size(196, 145);
            this.CustomerSink.TabIndex = 21;
            this.CustomerSink.TitleText = "Odchod zakanzika";
            // 
            // CustomersSource
            // 
            this.CustomersSource.CounterText = "0";
            this.CustomersSource.ID = -1;
            this.CustomersSource.Location = new System.Drawing.Point(18, 562);
            this.CustomersSource.Name = "CustomersSource";
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
            // StatAvgNOWaiting
            // 
            this.StatAvgNOWaiting.ID = -1;
            this.StatAvgNOWaiting.Location = new System.Drawing.Point(1224, 80);
            this.StatAvgNOWaiting.Name = "StatAvgNOWaiting";
            this.StatAvgNOWaiting.SimulationControl = null;
            this.StatAvgNOWaiting.Size = new System.Drawing.Size(289, 58);
            this.StatAvgNOWaiting.TabIndex = 17;
            this.StatAvgNOWaiting.TitleText = "Avg počet čakajúcich";
            this.StatAvgNOWaiting.ValueText = "value label";
            // 
            // StatVaccinateQlength
            // 
            this.StatVaccinateQlength.ID = -1;
            this.StatVaccinateQlength.Location = new System.Drawing.Point(893, 80);
            this.StatVaccinateQlength.Name = "StatVaccinateQlength";
            this.StatVaccinateQlength.SimulationControl = null;
            this.StatVaccinateQlength.Size = new System.Drawing.Size(363, 58);
            this.StatVaccinateQlength.TabIndex = 16;
            this.StatVaccinateQlength.TitleText = "Avg dĺžka radu - Vyšetrenie";
            this.StatVaccinateQlength.ValueText = "value label";
            // 
            // StatVaccinateWaitingTime
            // 
            this.StatVaccinateWaitingTime.ID = -1;
            this.StatVaccinateWaitingTime.Location = new System.Drawing.Point(893, 16);
            this.StatVaccinateWaitingTime.Name = "StatVaccinateWaitingTime";
            this.StatVaccinateWaitingTime.SimulationControl = null;
            this.StatVaccinateWaitingTime.Size = new System.Drawing.Size(363, 58);
            this.StatVaccinateWaitingTime.TabIndex = 15;
            this.StatVaccinateWaitingTime.TitleText = "Avg čas čakania - Očkovanie";
            this.StatVaccinateWaitingTime.ValueText = "value label";
            // 
            // StatCheckWaitingTime
            // 
            this.StatCheckWaitingTime.ID = -1;
            this.StatCheckWaitingTime.Location = new System.Drawing.Point(498, 16);
            this.StatCheckWaitingTime.Name = "StatCheckWaitingTime";
            this.StatCheckWaitingTime.SimulationControl = null;
            this.StatCheckWaitingTime.Size = new System.Drawing.Size(374, 58);
            this.StatCheckWaitingTime.TabIndex = 14;
            this.StatCheckWaitingTime.TitleText = "Avg čas čakania - Vyšetrenie";
            this.StatCheckWaitingTime.ValueText = "value label";
            // 
            // StatCheckQlength
            // 
            this.StatCheckQlength.ID = -1;
            this.StatCheckQlength.Location = new System.Drawing.Point(498, 80);
            this.StatCheckQlength.Name = "StatCheckQlength";
            this.StatCheckQlength.SimulationControl = null;
            this.StatCheckQlength.Size = new System.Drawing.Size(374, 58);
            this.StatCheckQlength.TabIndex = 13;
            this.StatCheckQlength.TitleText = "Avg dĺžka radu - Vyšetrenie";
            this.StatCheckQlength.ValueText = "value label";
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
            this.ResPoolNurse.Location = new System.Drawing.Point(588, 291);
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
            this.ResPoolDoctor.Location = new System.Drawing.Point(314, 291);
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
            this.ResPoolAdmin.Location = new System.Drawing.Point(18, 291);
            this.ResPoolAdmin.Name = "ResPoolAdmin";
            this.ResPoolAdmin.SimulationControl = null;
            this.ResPoolAdmin.Size = new System.Drawing.Size(230, 145);
            this.ResPoolAdmin.StaffUsedText = "staffUsed";
            this.ResPoolAdmin.TabIndex = 8;
            this.ResPoolAdmin.TitleText = "Administratívny pracovník";
            this.ResPoolAdmin.UtilizationText = "utilization%";
            // 
            // DelaySelect
            // 
            this.DelaySelect.FalseOutputText = "FalseO";
            this.DelaySelect.ID = -1;
            this.DelaySelect.Location = new System.Drawing.Point(1019, 144);
            this.DelaySelect.Name = "DelaySelect";
            this.DelaySelect.SimulationControl = null;
            this.DelaySelect.Size = new System.Drawing.Size(170, 141);
            this.DelaySelect.TabIndex = 7;
            this.DelaySelect.TitleText = "Dĺžka čakania";
            this.DelaySelect.TrueOutputText = "TrueO";
            // 
            // ExitSink
            // 
            this.ExitSink.CounterText = "output";
            this.ExitSink.ID = -1;
            this.ExitSink.Location = new System.Drawing.Point(1419, 144);
            this.ExitSink.Name = "ExitSink";
            this.ExitSink.SimulationControl = null;
            this.ExitSink.Size = new System.Drawing.Size(106, 141);
            this.ExitSink.TabIndex = 6;
            this.ExitSink.TitleText = "Východ";
            // 
            // PatientSource
            // 
            this.PatientSource.CounterText = "0";
            this.PatientSource.ID = -1;
            this.PatientSource.Location = new System.Drawing.Point(20, 144);
            this.PatientSource.Name = "PatientSource";
            this.PatientSource.SimulationControl = null;
            this.PatientSource.Size = new System.Drawing.Size(161, 141);
            this.PatientSource.TabIndex = 5;
            this.PatientSource.TitleText = "Zdroj pacientov";
            // 
            // DelayCakaren
            // 
            this.DelayCakaren.ActualDelayText = "actual";
            this.DelayCakaren.AutoSize = true;
            this.DelayCakaren.ID = -1;
            this.DelayCakaren.InputDelayText = "input";
            this.DelayCakaren.Location = new System.Drawing.Point(1238, 144);
            this.DelayCakaren.Name = "DelayCakaren";
            this.DelayCakaren.OutputDelayText = "output";
            this.DelayCakaren.SimulationControl = null;
            this.DelayCakaren.Size = new System.Drawing.Size(134, 149);
            this.DelayCakaren.TabIndex = 4;
            this.DelayCakaren.TitleText = "Čakáreň";
            // 
            // ServiceOckovanie
            // 
            this.ServiceOckovanie.DelayText = "dActual";
            this.ServiceOckovanie.ID = -1;
            this.ServiceOckovanie.InputText = "input";
            this.ServiceOckovanie.Location = new System.Drawing.Point(750, 144);
            this.ServiceOckovanie.Name = "ServiceOckovanie";
            this.ServiceOckovanie.OutputText = "output";
            this.ServiceOckovanie.QueueText = "qActual";
            this.ServiceOckovanie.SimulationControl = null;
            this.ServiceOckovanie.Size = new System.Drawing.Size(229, 149);
            this.ServiceOckovanie.TabIndex = 3;
            this.ServiceOckovanie.TitleText = "Očkovanie";
            // 
            // ServiceVysetrenie
            // 
            this.ServiceVysetrenie.DelayText = "dActual";
            this.ServiceVysetrenie.ID = -1;
            this.ServiceVysetrenie.InputText = "input";
            this.ServiceVysetrenie.Location = new System.Drawing.Point(476, 144);
            this.ServiceVysetrenie.Name = "ServiceVysetrenie";
            this.ServiceVysetrenie.OutputText = "output";
            this.ServiceVysetrenie.QueueText = "qActual";
            this.ServiceVysetrenie.SimulationControl = null;
            this.ServiceVysetrenie.Size = new System.Drawing.Size(229, 141);
            this.ServiceVysetrenie.TabIndex = 2;
            this.ServiceVysetrenie.TitleText = "Vyšetrenie";
            // 
            // ServiceAdministracia
            // 
            this.ServiceAdministracia.DelayText = "dActual";
            this.ServiceAdministracia.ID = -1;
            this.ServiceAdministracia.InputText = "input";
            this.ServiceAdministracia.Location = new System.Drawing.Point(180, 144);
            this.ServiceAdministracia.Name = "ServiceAdministracia";
            this.ServiceAdministracia.OutputText = "output";
            this.ServiceAdministracia.QueueText = "qActual";
            this.ServiceAdministracia.SimulationControl = null;
            this.ServiceAdministracia.Size = new System.Drawing.Size(229, 141);
            this.ServiceAdministracia.TabIndex = 1;
            this.ServiceAdministracia.TitleText = "Administrácia";
            // 
            // ReadDelay
            // 
            this.ReadDelay.ActualDelayText = "actual";
            this.ReadDelay.AutoSize = true;
            this.ReadDelay.ID = -1;
            this.ReadDelay.InputDelayText = "input";
            this.ReadDelay.Location = new System.Drawing.Point(557, 570);
            this.ReadDelay.Name = "ReadDelay";
            this.ReadDelay.OutputDelayText = "output";
            this.ReadDelay.SimulationControl = null;
            this.ReadDelay.Size = new System.Drawing.Size(161, 137);
            this.ReadDelay.TabIndex = 25;
            this.ReadDelay.TitleText = "Citanie novin";
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
        private SimDelay DelayCakaren;
        private SimService ServiceOckovanie;
        private SimService ServiceVysetrenie;
        private SimService ServiceAdministracia;
        private SimSelect2 DelaySelect;
        private SimSink ExitSink;
        private SimSource PatientSource;
        private SimStats StatVaccinateQlength;
        private SimStats StatVaccinateWaitingTime;
        private SimStats StatCheckWaitingTime;
        private SimStats StatCheckQlength;
        private SimStats StatAdminQLength;
        private SimStats StatAdminWaitingTime;
        private SimResourcePool ResPoolNurse;
        private SimResourcePool ResPoolDoctor;
        private SimResourcePool ResPoolAdmin;
        private SimStats StatAvgNOWaiting;
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
