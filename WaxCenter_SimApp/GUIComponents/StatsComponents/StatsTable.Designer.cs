
namespace WaxCenter_SimApp.GUIComponents.StatsComponents
{
    partial class StatsTable
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
            this.StatTitleLabel = new System.Windows.Forms.Label();
            this.StatGridView = new System.Windows.Forms.DataGridView();
            this.Statistic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.StatGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StatTitleLabel
            // 
            this.StatTitleLabel.AutoSize = true;
            this.StatTitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StatTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.StatTitleLabel.Name = "StatTitleLabel";
            this.StatTitleLabel.Size = new System.Drawing.Size(85, 25);
            this.StatTitleLabel.TabIndex = 0;
            this.StatTitleLabel.Text = "Service";
            // 
            // StatGridView
            // 
            this.StatGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.StatGridView.ColumnHeadersHeight = 29;
            this.StatGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Statistic,
            this.Value});
            this.StatGridView.Location = new System.Drawing.Point(3, 28);
            this.StatGridView.Name = "StatGridView";
            this.StatGridView.ReadOnly = true;
            this.StatGridView.RowHeadersVisible = false;
            this.StatGridView.RowHeadersWidth = 51;
            this.StatGridView.RowTemplate.Height = 24;
            this.StatGridView.ShowCellErrors = false;
            this.StatGridView.ShowCellToolTips = false;
            this.StatGridView.ShowEditingIcon = false;
            this.StatGridView.ShowRowErrors = false;
            this.StatGridView.Size = new System.Drawing.Size(338, 214);
            this.StatGridView.TabIndex = 2;
            // 
            // Statistic
            // 
            this.Statistic.FillWeight = 93.04813F;
            this.Statistic.HeaderText = "Statistic";
            this.Statistic.MinimumWidth = 6;
            this.Statistic.Name = "Statistic";
            this.Statistic.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.FillWeight = 106.9519F;
            this.Value.HeaderText = "Value";
            this.Value.MinimumWidth = 6;
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // StatsTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.StatGridView);
            this.Controls.Add(this.StatTitleLabel);
            this.MinimumSize = new System.Drawing.Size(292, 224);
            this.Name = "StatsTable";
            this.Size = new System.Drawing.Size(275, 196);
            ((System.ComponentModel.ISupportInitialize)(this.StatGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StatTitleLabel;
        private System.Windows.Forms.DataGridView StatGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Statistic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;

        public string TitleText { get => StatTitleLabel.Text; set => StatTitleLabel.Text = value; }
    }
}
