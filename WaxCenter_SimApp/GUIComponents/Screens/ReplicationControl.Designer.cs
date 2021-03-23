
namespace WaxCenter_SimApp.GUIComponents.Screens
{
    partial class ReplicationControl
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
            this.ReplicationTitleLabel = new System.Windows.Forms.Label();
            this.ReplicationsTopPanel = new System.Windows.Forms.Panel();
            this.ReplicationsOptionsPanel = new System.Windows.Forms.Panel();
            this.RepOptionsTitleLabel = new System.Windows.Forms.Label();
            this.ReplicationsTopPanel.SuspendLayout();
            this.ReplicationsOptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReplicationTitleLabel
            // 
            this.ReplicationTitleLabel.AutoSize = true;
            this.ReplicationTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ReplicationTitleLabel.Location = new System.Drawing.Point(3, 16);
            this.ReplicationTitleLabel.Name = "ReplicationTitleLabel";
            this.ReplicationTitleLabel.Size = new System.Drawing.Size(207, 38);
            this.ReplicationTitleLabel.TabIndex = 0;
            this.ReplicationTitleLabel.Text = "Replications";
            // 
            // ReplicationsTopPanel
            // 
            this.ReplicationsTopPanel.Controls.Add(this.ReplicationTitleLabel);
            this.ReplicationsTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ReplicationsTopPanel.Location = new System.Drawing.Point(0, 0);
            this.ReplicationsTopPanel.Name = "ReplicationsTopPanel";
            this.ReplicationsTopPanel.Size = new System.Drawing.Size(1501, 79);
            this.ReplicationsTopPanel.TabIndex = 1;
            // 
            // ReplicationsOptionsPanel
            // 
            this.ReplicationsOptionsPanel.Controls.Add(this.RepOptionsTitleLabel);
            this.ReplicationsOptionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ReplicationsOptionsPanel.Location = new System.Drawing.Point(1272, 79);
            this.ReplicationsOptionsPanel.Name = "ReplicationsOptionsPanel";
            this.ReplicationsOptionsPanel.Size = new System.Drawing.Size(229, 766);
            this.ReplicationsOptionsPanel.TabIndex = 2;
            // 
            // RepOptionsTitleLabel
            // 
            this.RepOptionsTitleLabel.AutoSize = true;
            this.RepOptionsTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RepOptionsTitleLabel.Location = new System.Drawing.Point(49, 3);
            this.RepOptionsTitleLabel.Name = "RepOptionsTitleLabel";
            this.RepOptionsTitleLabel.Size = new System.Drawing.Size(121, 32);
            this.RepOptionsTitleLabel.TabIndex = 0;
            this.RepOptionsTitleLabel.Text = "Options";
            // 
            // ReplicationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ReplicationsOptionsPanel);
            this.Controls.Add(this.ReplicationsTopPanel);
            this.Name = "ReplicationControl";
            this.Size = new System.Drawing.Size(1501, 845);
            this.ReplicationsTopPanel.ResumeLayout(false);
            this.ReplicationsTopPanel.PerformLayout();
            this.ReplicationsOptionsPanel.ResumeLayout(false);
            this.ReplicationsOptionsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ReplicationTitleLabel;
        private System.Windows.Forms.Panel ReplicationsTopPanel;
        private System.Windows.Forms.Panel ReplicationsOptionsPanel;
        private System.Windows.Forms.Label RepOptionsTitleLabel;
    }
}
