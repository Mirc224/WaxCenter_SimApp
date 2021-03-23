namespace WaxCenter_SimApp.GUIComponents.SimComponents
{
    partial class SimResourcePool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimResourcePool));
            this.ResourcePoolLabel = new System.Windows.Forms.Label();
            this.ResourcePoolPicture = new System.Windows.Forms.PictureBox();
            this.UtilizationLabel = new System.Windows.Forms.Label();
            this.StaffUsedLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ResourcePoolPicture)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResourcePoolLabel
            // 
            this.ResourcePoolLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResourcePoolLabel.AutoSize = true;
            this.ResourcePoolLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.ResourcePoolLabel.Location = new System.Drawing.Point(3, 0);
            this.ResourcePoolLabel.Name = "ResourcePoolLabel";
            this.ResourcePoolLabel.Size = new System.Drawing.Size(118, 20);
            this.ResourcePoolLabel.TabIndex = 0;
            this.ResourcePoolLabel.Text = "resourcepool";
            // 
            // ResourcePoolPicture
            // 
            this.ResourcePoolPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResourcePoolPicture.Image = ((System.Drawing.Image)(resources.GetObject("ResourcePoolPicture.Image")));
            this.ResourcePoolPicture.Location = new System.Drawing.Point(7, 43);
            this.ResourcePoolPicture.Name = "ResourcePoolPicture";
            this.ResourcePoolPicture.Size = new System.Drawing.Size(96, 72);
            this.ResourcePoolPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ResourcePoolPicture.TabIndex = 1;
            this.ResourcePoolPicture.TabStop = false;
            this.ResourcePoolPicture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ResourcePoolPicture_MouseClick);
            // 
            // UtilizationLabel
            // 
            this.UtilizationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UtilizationLabel.AutoSize = true;
            this.UtilizationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.UtilizationLabel.Location = new System.Drawing.Point(3, 20);
            this.UtilizationLabel.Name = "UtilizationLabel";
            this.UtilizationLabel.Size = new System.Drawing.Size(95, 20);
            this.UtilizationLabel.TabIndex = 2;
            this.UtilizationLabel.Text = "utilization%";
            // 
            // StaffUsedLabel
            // 
            this.StaffUsedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StaffUsedLabel.AutoSize = true;
            this.StaffUsedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.StaffUsedLabel.Location = new System.Drawing.Point(3, 118);
            this.StaffUsedLabel.Name = "StaffUsedLabel";
            this.StaffUsedLabel.Size = new System.Drawing.Size(81, 20);
            this.StaffUsedLabel.TabIndex = 3;
            this.StaffUsedLabel.Text = "staffUsed";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ResourcePoolLabel);
            this.panel1.Controls.Add(this.ResourcePoolPicture);
            this.panel1.Controls.Add(this.StaffUsedLabel);
            this.panel1.Controls.Add(this.UtilizationLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(123, 150);
            this.panel1.TabIndex = 4;
            // 
            // SimResourcePool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SimResourcePool";
            this.Size = new System.Drawing.Size(123, 150);
            ((System.ComponentModel.ISupportInitialize)(this.ResourcePoolPicture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ResourcePoolLabel;
        private System.Windows.Forms.PictureBox ResourcePoolPicture;
        private System.Windows.Forms.Label UtilizationLabel;
        private System.Windows.Forms.Label StaffUsedLabel;
        private System.Windows.Forms.Panel panel1;

        public string TitleText { get => ResourcePoolLabel.Text; set => ResourcePoolLabel.Text = value; }
        public string UtilizationText { get => UtilizationLabel.Text; set => UtilizationLabel.Text = value; }
        public string StaffUsedText { get => StaffUsedLabel.Text; set => StaffUsedLabel.Text = value; }
    }
}
