
namespace WaxCenter_SimApp.GUIComponents.SimComponents
{
    partial class SimStats
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimStats));
            this.StatTitleLabel = new System.Windows.Forms.Label();
            this.StatValueLabel = new System.Windows.Forms.Label();
            this.StatPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.StatPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // StatTitleLabel
            // 
            this.StatTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatTitleLabel.AutoSize = true;
            this.StatTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.StatTitleLabel.Location = new System.Drawing.Point(54, 0);
            this.StatTitleLabel.Name = "StatTitleLabel";
            this.StatTitleLabel.Size = new System.Drawing.Size(43, 20);
            this.StatTitleLabel.TabIndex = 0;
            this.StatTitleLabel.Text = "Stat";
            // 
            // StatValueLabel
            // 
            this.StatValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatValueLabel.AutoSize = true;
            this.StatValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.StatValueLabel.Location = new System.Drawing.Point(54, 33);
            this.StatValueLabel.Name = "StatValueLabel";
            this.StatValueLabel.Size = new System.Drawing.Size(88, 20);
            this.StatValueLabel.TabIndex = 1;
            this.StatValueLabel.Text = "value label";
            // 
            // StatPicture
            // 
            this.StatPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StatPicture.Image = ((System.Drawing.Image)(resources.GetObject("StatPicture.Image")));
            this.StatPicture.Location = new System.Drawing.Point(0, 3);
            this.StatPicture.Name = "StatPicture";
            this.StatPicture.Size = new System.Drawing.Size(54, 50);
            this.StatPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StatPicture.TabIndex = 2;
            this.StatPicture.TabStop = false;
            this.StatPicture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StatPicture_MouseClick);
            // 
            // SimStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StatPicture);
            this.Controls.Add(this.StatValueLabel);
            this.Controls.Add(this.StatTitleLabel);
            this.Name = "SimStats";
            this.Size = new System.Drawing.Size(191, 61);
            ((System.ComponentModel.ISupportInitialize)(this.StatPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StatTitleLabel;
        private System.Windows.Forms.Label StatValueLabel;
        private System.Windows.Forms.PictureBox StatPicture;
        public string TitleText
        {
            get => StatTitleLabel.Text;
            set => StatTitleLabel.Text = value;
        }

        public string ValueText
        {
            get => StatValueLabel.Text;
            set => StatValueLabel.Text = value;
        }
    }
}
