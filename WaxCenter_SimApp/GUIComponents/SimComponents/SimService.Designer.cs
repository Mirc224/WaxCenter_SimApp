
namespace WaxCenter_SimApp.GUIComponents.SimComponents
{
    partial class SimService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimService));
            this.ServiceTitleLabel = new System.Windows.Forms.Label();
            this.ServicePicture = new System.Windows.Forms.PictureBox();
            this.ServiceInputLabel = new System.Windows.Forms.Label();
            this.ServiceOutputLabel = new System.Windows.Forms.Label();
            this.QueueActualLabel = new System.Windows.Forms.Label();
            this.DelayActualLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ServicePicture)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServiceTitleLabel
            // 
            this.ServiceTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServiceTitleLabel.AutoSize = true;
            this.ServiceTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.ServiceTitleLabel.Location = new System.Drawing.Point(80, 0);
            this.ServiceTitleLabel.Name = "ServiceTitleLabel";
            this.ServiceTitleLabel.Size = new System.Drawing.Size(70, 20);
            this.ServiceTitleLabel.TabIndex = 0;
            this.ServiceTitleLabel.Text = "service";
            // 
            // ServicePicture
            // 
            this.ServicePicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ServicePicture.Image = ((System.Drawing.Image)(resources.GetObject("ServicePicture.Image")));
            this.ServicePicture.Location = new System.Drawing.Point(24, 56);
            this.ServicePicture.Name = "ServicePicture";
            this.ServicePicture.Size = new System.Drawing.Size(162, 62);
            this.ServicePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ServicePicture.TabIndex = 1;
            this.ServicePicture.TabStop = false;
            this.ServicePicture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ServicePicture_MouseClick);
            // 
            // ServiceInputLabel
            // 
            this.ServiceInputLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServiceInputLabel.AutoSize = true;
            this.ServiceInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.ServiceInputLabel.Location = new System.Drawing.Point(3, 121);
            this.ServiceInputLabel.Name = "ServiceInputLabel";
            this.ServiceInputLabel.Size = new System.Drawing.Size(45, 20);
            this.ServiceInputLabel.TabIndex = 2;
            this.ServiceInputLabel.Text = "input";
            // 
            // ServiceOutputLabel
            // 
            this.ServiceOutputLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServiceOutputLabel.AutoSize = true;
            this.ServiceOutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.ServiceOutputLabel.Location = new System.Drawing.Point(156, 121);
            this.ServiceOutputLabel.Name = "ServiceOutputLabel";
            this.ServiceOutputLabel.Size = new System.Drawing.Size(55, 20);
            this.ServiceOutputLabel.TabIndex = 3;
            this.ServiceOutputLabel.Text = "output";
            // 
            // QueueActualLabel
            // 
            this.QueueActualLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QueueActualLabel.AutoSize = true;
            this.QueueActualLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.QueueActualLabel.Location = new System.Drawing.Point(3, 33);
            this.QueueActualLabel.Name = "QueueActualLabel";
            this.QueueActualLabel.Size = new System.Drawing.Size(65, 20);
            this.QueueActualLabel.TabIndex = 4;
            this.QueueActualLabel.Text = "qActual";
            // 
            // DelayActualLabel
            // 
            this.DelayActualLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DelayActualLabel.AutoSize = true;
            this.DelayActualLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.DelayActualLabel.Location = new System.Drawing.Point(156, 33);
            this.DelayActualLabel.Name = "DelayActualLabel";
            this.DelayActualLabel.Size = new System.Drawing.Size(65, 20);
            this.DelayActualLabel.TabIndex = 5;
            this.DelayActualLabel.Text = "dActual";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ServiceTitleLabel);
            this.panel1.Controls.Add(this.ServicePicture);
            this.panel1.Controls.Add(this.ServiceInputLabel);
            this.panel1.Controls.Add(this.ServiceOutputLabel);
            this.panel1.Controls.Add(this.DelayActualLabel);
            this.panel1.Controls.Add(this.QueueActualLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 150);
            this.panel1.TabIndex = 6;
            // 
            // SimService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SimService";
            this.Size = new System.Drawing.Size(228, 150);
            ((System.ComponentModel.ISupportInitialize)(this.ServicePicture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ServiceTitleLabel;
        private System.Windows.Forms.PictureBox ServicePicture;
        private System.Windows.Forms.Label ServiceInputLabel;
        private System.Windows.Forms.Label ServiceOutputLabel;
        private System.Windows.Forms.Label QueueActualLabel;
        private System.Windows.Forms.Label DelayActualLabel;
        private System.Windows.Forms.Panel panel1;
        public string TitleText
        {
            get => ServiceTitleLabel.Text;
            set => ServiceTitleLabel.Text = value;
        }

        public string InputText { get => ServiceInputLabel.Text; set => ServiceInputLabel.Text = value; }
        public string OutputText { get => ServiceOutputLabel.Text; set => ServiceOutputLabel.Text = value; }
        public string QueueText { get => QueueActualLabel.Text; set => QueueActualLabel.Text = value; }
        public string CurrentlyUsedText { get => DelayActualLabel.Text; set => DelayActualLabel.Text = value; }
    }
}
