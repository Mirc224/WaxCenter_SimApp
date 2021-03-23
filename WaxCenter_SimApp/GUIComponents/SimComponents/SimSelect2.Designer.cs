
namespace WaxCenter_SimApp.GUIComponents.SimComponents
{
    partial class SimSelect2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimSelect2));
            this.SelectOutputPicture = new System.Windows.Forms.PictureBox();
            this.InputSelectLabel = new System.Windows.Forms.Label();
            this.TrueOutputLabel = new System.Windows.Forms.Label();
            this.SelectOutputLabel = new System.Windows.Forms.Label();
            this.FalseOutputLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.SelectOutputPicture)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectOutputPicture
            // 
            this.SelectOutputPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectOutputPicture.Image = ((System.Drawing.Image)(resources.GetObject("SelectOutputPicture.Image")));
            this.SelectOutputPicture.Location = new System.Drawing.Point(7, 44);
            this.SelectOutputPicture.Name = "SelectOutputPicture";
            this.SelectOutputPicture.Size = new System.Drawing.Size(114, 67);
            this.SelectOutputPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SelectOutputPicture.TabIndex = 1;
            this.SelectOutputPicture.TabStop = false;
            this.SelectOutputPicture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SelectOutputPicture_MouseClick);
            // 
            // InputSelectLabel
            // 
            this.InputSelectLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputSelectLabel.AutoSize = true;
            this.InputSelectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.InputSelectLabel.Location = new System.Drawing.Point(3, 114);
            this.InputSelectLabel.Name = "InputSelectLabel";
            this.InputSelectLabel.Size = new System.Drawing.Size(45, 20);
            this.InputSelectLabel.TabIndex = 2;
            this.InputSelectLabel.Text = "input";
            // 
            // TrueOutputLabel
            // 
            this.TrueOutputLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrueOutputLabel.AutoSize = true;
            this.TrueOutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.TrueOutputLabel.Location = new System.Drawing.Point(93, 21);
            this.TrueOutputLabel.Name = "TrueOutputLabel";
            this.TrueOutputLabel.Size = new System.Drawing.Size(56, 20);
            this.TrueOutputLabel.TabIndex = 3;
            this.TrueOutputLabel.Text = "TrueO";
            // 
            // SelectOutputLabel
            // 
            this.SelectOutputLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectOutputLabel.AutoSize = true;
            this.SelectOutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.SelectOutputLabel.Location = new System.Drawing.Point(15, 0);
            this.SelectOutputLabel.Name = "SelectOutputLabel";
            this.SelectOutputLabel.Size = new System.Drawing.Size(118, 20);
            this.SelectOutputLabel.TabIndex = 0;
            this.SelectOutputLabel.Text = "SelectOutput";
            // 
            // FalseOutputLabel
            // 
            this.FalseOutputLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FalseOutputLabel.AutoSize = true;
            this.FalseOutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.FalseOutputLabel.Location = new System.Drawing.Point(93, 114);
            this.FalseOutputLabel.Name = "FalseOutputLabel";
            this.FalseOutputLabel.Size = new System.Drawing.Size(63, 20);
            this.FalseOutputLabel.TabIndex = 4;
            this.FalseOutputLabel.Text = "FalseO";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SelectOutputLabel);
            this.panel1.Controls.Add(this.SelectOutputPicture);
            this.panel1.Controls.Add(this.InputSelectLabel);
            this.panel1.Controls.Add(this.FalseOutputLabel);
            this.panel1.Controls.Add(this.TrueOutputLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 150);
            this.panel1.TabIndex = 5;
            // 
            // SimSelect2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SimSelect2";
            this.Size = new System.Drawing.Size(160, 150);
            ((System.ComponentModel.ISupportInitialize)(this.SelectOutputPicture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox SelectOutputPicture;
        private System.Windows.Forms.Label InputSelectLabel;
        private System.Windows.Forms.Label TrueOutputLabel;
        private System.Windows.Forms.Label SelectOutputLabel;
        private System.Windows.Forms.Label FalseOutputLabel;
        private System.Windows.Forms.Panel panel1;

        public string TitleText { get => SelectOutputLabel.Text; set => SelectOutputLabel.Text = value; }
        public string TrueOutputText { get => TrueOutputLabel.Text; set => TrueOutputLabel.Text = value; }
        public string FalseOutputText { get => FalseOutputLabel.Text; set => FalseOutputLabel.Text = value; }
    }
}
