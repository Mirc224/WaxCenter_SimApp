
using static WaxCenter_SimApp.Model.Simulation.SimulationBaseClasses.Core.EventSimulationCore;

namespace WaxCenter_SimApp.GUIComponents.OptionsComponents
{
    partial class SimulationOptions
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
            this.TableOptionsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MaxTimeLabel = new System.Windows.Forms.Label();
            this.AfterMaxLable = new System.Windows.Forms.Label();
            this.SeedLabel = new System.Windows.Forms.Label();
            this.MaxTimeInput = new System.Windows.Forms.TextBox();
            this.MaxTimeUnitListBox = new System.Windows.Forms.ListBox();
            this.SeedInput = new System.Windows.Forms.TextBox();
            this.AutoSeedCheckBox = new System.Windows.Forms.CheckBox();
            this.AfterMaxTimeCheck = new System.Windows.Forms.CheckBox();
            this.SimOptionsTitle = new System.Windows.Forms.Label();
            this.UseSettingsButton = new System.Windows.Forms.Button();
            this.TableOptionsLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableOptionsLayout
            // 
            this.TableOptionsLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableOptionsLayout.ColumnCount = 3;
            this.TableOptionsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableOptionsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableOptionsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableOptionsLayout.Controls.Add(this.MaxTimeLabel, 0, 0);
            this.TableOptionsLayout.Controls.Add(this.AfterMaxLable, 0, 1);
            this.TableOptionsLayout.Controls.Add(this.SeedLabel, 0, 2);
            this.TableOptionsLayout.Controls.Add(this.MaxTimeInput, 1, 0);
            this.TableOptionsLayout.Controls.Add(this.MaxTimeUnitListBox, 2, 0);
            this.TableOptionsLayout.Controls.Add(this.SeedInput, 1, 2);
            this.TableOptionsLayout.Controls.Add(this.AutoSeedCheckBox, 2, 2);
            this.TableOptionsLayout.Controls.Add(this.AfterMaxTimeCheck, 1, 1);
            this.TableOptionsLayout.Location = new System.Drawing.Point(0, 44);
            this.TableOptionsLayout.Name = "TableOptionsLayout";
            this.TableOptionsLayout.RowCount = 3;
            this.TableOptionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableOptionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableOptionsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableOptionsLayout.Size = new System.Drawing.Size(548, 88);
            this.TableOptionsLayout.TabIndex = 0;
            // 
            // MaxTimeLabel
            // 
            this.MaxTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxTimeLabel.AutoSize = true;
            this.MaxTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MaxTimeLabel.Location = new System.Drawing.Point(3, 0);
            this.MaxTimeLabel.Name = "MaxTimeLabel";
            this.MaxTimeLabel.Size = new System.Drawing.Size(215, 28);
            this.MaxTimeLabel.TabIndex = 0;
            this.MaxTimeLabel.Text = "Maximal time:";
            // 
            // AfterMaxLable
            // 
            this.AfterMaxLable.AutoSize = true;
            this.AfterMaxLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AfterMaxLable.Location = new System.Drawing.Point(3, 28);
            this.AfterMaxLable.Name = "AfterMaxLable";
            this.AfterMaxLable.Size = new System.Drawing.Size(215, 20);
            this.AfterMaxLable.TabIndex = 1;
            this.AfterMaxLable.Text = "Continue after MaxTime:";
            // 
            // SeedLabel
            // 
            this.SeedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SeedLabel.AutoSize = true;
            this.SeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SeedLabel.Location = new System.Drawing.Point(3, 55);
            this.SeedLabel.Name = "SeedLabel";
            this.SeedLabel.Size = new System.Drawing.Size(215, 33);
            this.SeedLabel.TabIndex = 2;
            this.SeedLabel.Text = "SimulationSeed";
            // 
            // MaxTimeInput
            // 
            this.MaxTimeInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxTimeInput.Location = new System.Drawing.Point(224, 3);
            this.MaxTimeInput.Name = "MaxTimeInput";
            this.MaxTimeInput.Size = new System.Drawing.Size(140, 22);
            this.MaxTimeInput.TabIndex = 3;
            // 
            // MaxTimeUnitListBox
            // 
            this.MaxTimeUnitListBox.FormattingEnabled = true;
            this.MaxTimeUnitListBox.ItemHeight = 16;
            this.MaxTimeUnitListBox.Items.AddRange(new object[] {
            "Seconds",
            "Minutes"});
            this.MaxTimeUnitListBox.Location = new System.Drawing.Point(370, 3);
            this.MaxTimeUnitListBox.Name = "MaxTimeUnitListBox";
            this.MaxTimeUnitListBox.Size = new System.Drawing.Size(159, 20);
            this.MaxTimeUnitListBox.TabIndex = 4;
            // 
            // SeedInput
            // 
            this.SeedInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SeedInput.Location = new System.Drawing.Point(224, 58);
            this.SeedInput.Name = "SeedInput";
            this.SeedInput.Size = new System.Drawing.Size(140, 22);
            this.SeedInput.TabIndex = 5;
            // 
            // AutoSeedCheckBox
            // 
            this.AutoSeedCheckBox.AutoSize = true;
            this.AutoSeedCheckBox.Location = new System.Drawing.Point(370, 58);
            this.AutoSeedCheckBox.Name = "AutoSeedCheckBox";
            this.AutoSeedCheckBox.Size = new System.Drawing.Size(92, 21);
            this.AutoSeedCheckBox.TabIndex = 6;
            this.AutoSeedCheckBox.Text = "AutoSeed";
            this.AutoSeedCheckBox.UseVisualStyleBackColor = true;
            this.AutoSeedCheckBox.CheckedChanged += new System.EventHandler(this.AutoSeedCheckBox_CheckedChanged);
            // 
            // AfterMaxTimeCheck
            // 
            this.AfterMaxTimeCheck.AutoSize = true;
            this.AfterMaxTimeCheck.Location = new System.Drawing.Point(224, 31);
            this.AfterMaxTimeCheck.Name = "AfterMaxTimeCheck";
            this.AfterMaxTimeCheck.Size = new System.Drawing.Size(86, 21);
            this.AfterMaxTimeCheck.TabIndex = 7;
            this.AfterMaxTimeCheck.Text = "Continue";
            this.AfterMaxTimeCheck.UseVisualStyleBackColor = true;
            // 
            // SimOptionsTitle
            // 
            this.SimOptionsTitle.AutoSize = true;
            this.SimOptionsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SimOptionsTitle.Location = new System.Drawing.Point(3, 0);
            this.SimOptionsTitle.Name = "SimOptionsTitle";
            this.SimOptionsTitle.Size = new System.Drawing.Size(291, 29);
            this.SimOptionsTitle.TabIndex = 1;
            this.SimOptionsTitle.Text = "Base simulation options";
            // 
            // UseSettingsButton
            // 
            this.UseSettingsButton.Location = new System.Drawing.Point(182, 150);
            this.UseSettingsButton.Name = "UseSettingsButton";
            this.UseSettingsButton.Size = new System.Drawing.Size(159, 29);
            this.UseSettingsButton.TabIndex = 2;
            this.UseSettingsButton.Text = "Use settings";
            this.UseSettingsButton.UseVisualStyleBackColor = true;
            this.UseSettingsButton.Click += new System.EventHandler(this.UseSettingsButton_Click);
            // 
            // SimulationOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.UseSettingsButton);
            this.Controls.Add(this.SimOptionsTitle);
            this.Controls.Add(this.TableOptionsLayout);
            this.MinimumSize = new System.Drawing.Size(529, 130);
            this.Name = "SimulationOptions";
            this.Size = new System.Drawing.Size(554, 182);
            this.TableOptionsLayout.ResumeLayout(false);
            this.TableOptionsLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableOptionsLayout;
        private System.Windows.Forms.Label MaxTimeLabel;
        private System.Windows.Forms.Label AfterMaxLable;
        private System.Windows.Forms.Label SeedLabel;
        private System.Windows.Forms.TextBox MaxTimeInput;
        private System.Windows.Forms.ListBox MaxTimeUnitListBox;
        private System.Windows.Forms.TextBox SeedInput;
        private System.Windows.Forms.CheckBox AutoSeedCheckBox;
        private System.Windows.Forms.CheckBox AfterMaxTimeCheck;
        private System.Windows.Forms.Label SimOptionsTitle;
        private System.Windows.Forms.Button UseSettingsButton;

        public string SeedInputText { get => SeedInput.Text; set => SeedInput.Text = value; }
        public string MaxTimeInputText { get => MaxTimeInput.Text; set => MaxTimeInput.Text = value; }
        public bool AutoSeedChecked { get => AutoSeedCheckBox.Checked; }
        public bool AfterMaxTimeChecked { get => AfterMaxTimeCheck.Checked; }

        public TimeUnits SelectedTimeUnits 
        { get
            {
                switch(MaxTimeUnitListBox.SelectedIndex)
                {
                    case 0:
                        return TimeUnits.SECONDS;
                    case 1:
                        return TimeUnits.MINUTES;
                    default:
                        return TimeUnits.SECONDS;
                }
            } 
        }
    }
}
