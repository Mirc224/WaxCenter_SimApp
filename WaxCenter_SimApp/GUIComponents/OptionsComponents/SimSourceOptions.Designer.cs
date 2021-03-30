
namespace WaxCenter_SimApp.GUIComponents.OptionsComponents
{
    partial class SimSourceOptions
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
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SourceRateLabel = new System.Windows.Forms.Label();
            this.SourceRateInput = new System.Windows.Forms.TextBox();
            this.AgentsInput = new System.Windows.Forms.MaskedTextBox();
            this.AgentsGeneratedLabel = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.TableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.TitleLabel.Location = new System.Drawing.Point(62, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(162, 25);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Source Options";
            // 
            // TableLayout
            // 
            this.TableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayout.ColumnCount = 2;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayout.Controls.Add(this.SourceRateLabel, 0, 0);
            this.TableLayout.Controls.Add(this.SourceRateInput, 1, 0);
            this.TableLayout.Controls.Add(this.AgentsInput, 1, 1);
            this.TableLayout.Controls.Add(this.AgentsGeneratedLabel, 0, 1);
            this.TableLayout.Location = new System.Drawing.Point(2, 39);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 2;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.Size = new System.Drawing.Size(273, 61);
            this.TableLayout.TabIndex = 1;
            // 
            // SourceRateLabel
            // 
            this.SourceRateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceRateLabel.AutoSize = true;
            this.SourceRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.SourceRateLabel.Location = new System.Drawing.Point(3, 0);
            this.SourceRateLabel.Name = "SourceRateLabel";
            this.SourceRateLabel.Size = new System.Drawing.Size(145, 20);
            this.SourceRateLabel.TabIndex = 0;
            this.SourceRateLabel.Text = "Source rate: ";
            this.SourceRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SourceRateInput
            // 
            this.SourceRateInput.Location = new System.Drawing.Point(154, 3);
            this.SourceRateInput.Name = "SourceRateInput";
            this.SourceRateInput.Size = new System.Drawing.Size(119, 22);
            this.SourceRateInput.TabIndex = 1;
            // 
            // AgentsInput
            // 
            this.AgentsInput.Location = new System.Drawing.Point(154, 37);
            this.AgentsInput.Name = "AgentsInput";
            this.AgentsInput.Size = new System.Drawing.Size(119, 22);
            this.AgentsInput.TabIndex = 2;
            // 
            // AgentsGeneratedLabel
            // 
            this.AgentsGeneratedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AgentsGeneratedLabel.AutoSize = true;
            this.AgentsGeneratedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.AgentsGeneratedLabel.Location = new System.Drawing.Point(3, 34);
            this.AgentsGeneratedLabel.Name = "AgentsGeneratedLabel";
            this.AgentsGeneratedLabel.Size = new System.Drawing.Size(145, 20);
            this.AgentsGeneratedLabel.TabIndex = 3;
            this.AgentsGeneratedLabel.Text = "Agents generated:";
            this.AgentsGeneratedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(79, 106);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(131, 33);
            this.ConfirmButton.TabIndex = 2;
            this.ConfirmButton.Text = "Apply";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // SimSourceOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.TableLayout);
            this.Controls.Add(this.TitleLabel);
            this.MinimumSize = new System.Drawing.Size(292, 142);
            this.Name = "SimSourceOptions";
            this.Size = new System.Drawing.Size(292, 142);
            this.TableLayout.ResumeLayout(false);
            this.TableLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TableLayoutPanel TableLayout;
        private System.Windows.Forms.Label SourceRateLabel;
        private System.Windows.Forms.TextBox SourceRateInput;
        private System.Windows.Forms.MaskedTextBox AgentsInput;
        private System.Windows.Forms.Label AgentsGeneratedLabel;
        private System.Windows.Forms.Button ConfirmButton;

        public string IntervalInputText { get => SourceRateInput.Text; set => SourceRateInput.Text = value; }
        public string AgentsInputText { get => AgentsInput.Text; set => AgentsInput.Text = value; }
    }
}
