
namespace WaxCenter_SimApp.GUIComponents.SimComponents
{
    partial class SimSource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimSource));
            this.SourceTitleLabel = new System.Windows.Forms.Label();
            this.SourcePictureBox = new System.Windows.Forms.PictureBox();
            this.CounterLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SourcePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SourceTitleLabel
            // 
            this.SourceTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceTitleLabel.AutoSize = true;
            this.SourceTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SourceTitleLabel.Location = new System.Drawing.Point(3, 0);
            this.SourceTitleLabel.Name = "SourceTitleLabel";
            this.SourceTitleLabel.Size = new System.Drawing.Size(66, 20);
            this.SourceTitleLabel.TabIndex = 0;
            this.SourceTitleLabel.Text = "source";
            // 
            // SourcePictureBox
            // 
            this.SourcePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SourcePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("SourcePictureBox.Image")));
            this.SourcePictureBox.Location = new System.Drawing.Point(7, 36);
            this.SourcePictureBox.Name = "SourcePictureBox";
            this.SourcePictureBox.Size = new System.Drawing.Size(69, 70);
            this.SourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SourcePictureBox.TabIndex = 1;
            this.SourcePictureBox.TabStop = false;
            this.SourcePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SourcePictureBox_MouseClick);
            // 
            // CounterLabel
            // 
            this.CounterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CounterLabel.AutoSize = true;
            this.CounterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CounterLabel.Location = new System.Drawing.Point(30, 119);
            this.CounterLabel.Name = "CounterLabel";
            this.CounterLabel.Size = new System.Drawing.Size(18, 20);
            this.CounterLabel.TabIndex = 2;
            this.CounterLabel.Text = "0";
            // 
            // SimSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CounterLabel);
            this.Controls.Add(this.SourcePictureBox);
            this.Controls.Add(this.SourceTitleLabel);
            this.Name = "SimSource";
            this.Size = new System.Drawing.Size(80, 150);
            ((System.ComponentModel.ISupportInitialize)(this.SourcePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SourceTitleLabel;
        private System.Windows.Forms.PictureBox SourcePictureBox;
        private System.Windows.Forms.Label CounterLabel;

        public string TitleText
        {
            get => SourceTitleLabel.Text;
            set => SourceTitleLabel.Text = value;
        }

        public string CounterText
        {
            get => CounterLabel.Text;
            set => CounterLabel.Text = value;
        }
    }
}
