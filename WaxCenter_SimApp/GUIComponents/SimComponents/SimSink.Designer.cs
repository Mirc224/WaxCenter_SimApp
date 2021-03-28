
namespace WaxCenter_SimApp.GUIComponents.SimComponents
{
    partial class SimSink
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimSink));
            this.SinkPicture = new System.Windows.Forms.PictureBox();
            this.OutputSinkLabel = new System.Windows.Forms.Label();
            this.SinkTitleLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.SinkPicture)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SinkPicture
            // 
            this.SinkPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SinkPicture.Image = ((System.Drawing.Image)(resources.GetObject("SinkPicture.Image")));
            this.SinkPicture.Location = new System.Drawing.Point(1, 34);
            this.SinkPicture.Name = "SinkPicture";
            this.SinkPicture.Size = new System.Drawing.Size(94, 76);
            this.SinkPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SinkPicture.TabIndex = 1;
            this.SinkPicture.TabStop = false;
            this.SinkPicture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SinkPicture_MouseClick);
            // 
            // OutputSinkLabel
            // 
            this.OutputSinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputSinkLabel.AutoSize = true;
            this.OutputSinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.OutputSinkLabel.Location = new System.Drawing.Point(14, 123);
            this.OutputSinkLabel.Name = "OutputSinkLabel";
            this.OutputSinkLabel.Size = new System.Drawing.Size(55, 20);
            this.OutputSinkLabel.TabIndex = 2;
            this.OutputSinkLabel.Text = "output";
            // 
            // SinkTitleLabel
            // 
            this.SinkTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SinkTitleLabel.AutoSize = true;
            this.SinkTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.SinkTitleLabel.Location = new System.Drawing.Point(26, 0);
            this.SinkTitleLabel.Name = "SinkTitleLabel";
            this.SinkTitleLabel.Size = new System.Drawing.Size(43, 20);
            this.SinkTitleLabel.TabIndex = 0;
            this.SinkTitleLabel.Text = "sink";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SinkPicture);
            this.panel1.Controls.Add(this.SinkTitleLabel);
            this.panel1.Controls.Add(this.OutputSinkLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(95, 150);
            this.panel1.TabIndex = 3;
            // 
            // SimSink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SimSink";
            this.Size = new System.Drawing.Size(95, 150);
            ((System.ComponentModel.ISupportInitialize)(this.SinkPicture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox SinkPicture;
        private System.Windows.Forms.Label OutputSinkLabel;
        private System.Windows.Forms.Label SinkTitleLabel;
        private System.Windows.Forms.Panel panel1;

        public string TitleText
        {
            get => SinkTitleLabel.Text;
            set => SinkTitleLabel.Text = value;
        }

        public string InputText
        {
            get => OutputSinkLabel.Text;
            set => OutputSinkLabel.Text = value;
        }
    }
}
