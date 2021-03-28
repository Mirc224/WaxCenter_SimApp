
namespace WaxCenter_SimApp.GUIComponents.SimComponents
{
    partial class SimDelay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimDelay));
            this.DelayTitleLabel = new System.Windows.Forms.Label();
            this.DelayPicture = new System.Windows.Forms.PictureBox();
            this.DelayInputLabel = new System.Windows.Forms.Label();
            this.OutputDelayLabel = new System.Windows.Forms.Label();
            this.ActualDelayLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DelayPicture)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DelayTitleLabel
            // 
            this.DelayTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DelayTitleLabel.AutoSize = true;
            this.DelayTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.DelayTitleLabel.Location = new System.Drawing.Point(32, 0);
            this.DelayTitleLabel.Name = "DelayTitleLabel";
            this.DelayTitleLabel.Size = new System.Drawing.Size(53, 20);
            this.DelayTitleLabel.TabIndex = 0;
            this.DelayTitleLabel.Text = "delay";
            // 
            // DelayPicture
            // 
            this.DelayPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DelayPicture.Image = ((System.Drawing.Image)(resources.GetObject("DelayPicture.Image")));
            this.DelayPicture.Location = new System.Drawing.Point(36, 47);
            this.DelayPicture.Name = "DelayPicture";
            this.DelayPicture.Size = new System.Drawing.Size(58, 60);
            this.DelayPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DelayPicture.TabIndex = 1;
            this.DelayPicture.TabStop = false;
            this.DelayPicture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DelayPicture_MouseClick);
            // 
            // DelayInputLabel
            // 
            this.DelayInputLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DelayInputLabel.AutoSize = true;
            this.DelayInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.DelayInputLabel.Location = new System.Drawing.Point(3, 110);
            this.DelayInputLabel.Name = "DelayInputLabel";
            this.DelayInputLabel.Size = new System.Drawing.Size(45, 20);
            this.DelayInputLabel.TabIndex = 2;
            this.DelayInputLabel.Text = "input";
            // 
            // OutputDelayLabel
            // 
            this.OutputDelayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputDelayLabel.AutoSize = true;
            this.OutputDelayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.OutputDelayLabel.Location = new System.Drawing.Point(73, 110);
            this.OutputDelayLabel.Name = "OutputDelayLabel";
            this.OutputDelayLabel.Size = new System.Drawing.Size(55, 20);
            this.OutputDelayLabel.TabIndex = 3;
            this.OutputDelayLabel.Text = "output";
            // 
            // ActualDelayLabel
            // 
            this.ActualDelayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ActualDelayLabel.AutoSize = true;
            this.ActualDelayLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActualDelayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.ActualDelayLabel.Location = new System.Drawing.Point(32, 24);
            this.ActualDelayLabel.Name = "ActualDelayLabel";
            this.ActualDelayLabel.Size = new System.Drawing.Size(54, 20);
            this.ActualDelayLabel.TabIndex = 4;
            this.ActualDelayLabel.Text = "actual";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DelayPicture);
            this.panel1.Controls.Add(this.DelayInputLabel);
            this.panel1.Controls.Add(this.OutputDelayLabel);
            this.panel1.Controls.Add(this.ActualDelayLabel);
            this.panel1.Controls.Add(this.DelayTitleLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(136, 150);
            this.panel1.TabIndex = 5;
            // 
            // SimDelay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Name = "SimDelay";
            this.Size = new System.Drawing.Size(136, 150);
            ((System.ComponentModel.ISupportInitialize)(this.DelayPicture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label DelayTitleLabel;
        private System.Windows.Forms.PictureBox DelayPicture;
        private System.Windows.Forms.Label DelayInputLabel;
        private System.Windows.Forms.Label OutputDelayLabel;
        private System.Windows.Forms.Label ActualDelayLabel;
        private System.Windows.Forms.Panel panel1;

        public string TitleText { get => DelayTitleLabel.Text; set => DelayTitleLabel.Text = value; }
        public string InputText { get => DelayInputLabel.Text; set => DelayInputLabel.Text = value; }
        public string OutputText { get => OutputDelayLabel.Text; set => OutputDelayLabel.Text = value; }
        public string CurrentlyUsedText { get => ActualDelayLabel.Text; set => ActualDelayLabel.Text = value; }
    }
}
