
namespace WaxCenter_SimApp.GUIComponents.OptionsComponents
{
    partial class SimResPoolOptions
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SelectedResPool = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ResPoolButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MaxStaffLabel = new System.Windows.Forms.Label();
            this.StaffInput = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TitleLabel.Location = new System.Drawing.Point(28, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(231, 25);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Resource pool Options";
            // 
            // SelectedResPool
            // 
            this.SelectedResPool.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedResPool.AutoSize = true;
            this.SelectedResPool.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SelectedResPool.Location = new System.Drawing.Point(29, 25);
            this.SelectedResPool.Name = "SelectedResPool";
            this.SelectedResPool.Size = new System.Drawing.Size(74, 20);
            this.SelectedResPool.TabIndex = 1;
            this.SelectedResPool.Text = "Selected";
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.ResPoolButton);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.TitleLabel);
            this.panel1.Controls.Add(this.SelectedResPool);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(292, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 142);
            this.panel1.TabIndex = 2;
            // 
            // ResPoolButton
            // 
            this.ResPoolButton.Location = new System.Drawing.Point(78, 106);
            this.ResPoolButton.Name = "ResPoolButton";
            this.ResPoolButton.Size = new System.Drawing.Size(131, 33);
            this.ResPoolButton.TabIndex = 3;
            this.ResPoolButton.Text = "Apply";
            this.ResPoolButton.UseVisualStyleBackColor = true;
            this.ResPoolButton.Click += new System.EventHandler(this.ResPoolButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.MaxStaffLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.StaffInput, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(286, 30);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // MaxStaffLabel
            // 
            this.MaxStaffLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxStaffLabel.AutoSize = true;
            this.MaxStaffLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MaxStaffLabel.Location = new System.Drawing.Point(3, 0);
            this.MaxStaffLabel.Name = "MaxStaffLabel";
            this.MaxStaffLabel.Size = new System.Drawing.Size(137, 30);
            this.MaxStaffLabel.TabIndex = 0;
            this.MaxStaffLabel.Text = "Staff number:";
            // 
            // StaffInput
            // 
            this.StaffInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StaffInput.Location = new System.Drawing.Point(146, 3);
            this.StaffInput.Name = "StaffInput";
            this.StaffInput.Size = new System.Drawing.Size(137, 22);
            this.StaffInput.TabIndex = 1;
            // 
            // SimResPoolOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(292, 142);
            this.Name = "SimResPoolOptions";
            this.Size = new System.Drawing.Size(292, 142);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label SelectedResPool;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ResPoolButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label MaxStaffLabel;
        private System.Windows.Forms.TextBox StaffInput;

        public string SelectedText { get => SelectedResPool.Text; set => SelectedResPool.Text = value; }
    }
}
