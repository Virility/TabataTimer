namespace TabataTimerApplication.UI.Forms
{
    partial class MainForm
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
                _tabataTimer.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bStart = new System.Windows.Forms.Button();
            this.tbTimeOff = new System.Windows.Forms.TrackBar();
            this.tbTimeOn = new System.Windows.Forms.TrackBar();
            this.tbPreparation = new System.Windows.Forms.TrackBar();
            this.lPreparation = new System.Windows.Forms.Label();
            this.lTimeOn = new System.Windows.Forms.Label();
            this.lTimeOff = new System.Windows.Forms.Label();
            this.rtbMain = new System.Windows.Forms.RichTextBox();
            this.lRounds = new System.Windows.Forms.Label();
            this.tbRounds = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPreparation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRounds)).BeginInit();
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(12, 271);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(307, 40);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // tbTimeOff
            // 
            this.tbTimeOff.Location = new System.Drawing.Point(12, 220);
            this.tbTimeOff.Maximum = 60;
            this.tbTimeOff.Minimum = 3;
            this.tbTimeOff.Name = "tbTimeOff";
            this.tbTimeOff.Size = new System.Drawing.Size(307, 45);
            this.tbTimeOff.TabIndex = 1;
            this.tbTimeOff.Value = 3;
            this.tbTimeOff.ValueChanged += new System.EventHandler(this.TrackBarValuesChanged);
            // 
            // tbTimeOn
            // 
            this.tbTimeOn.Location = new System.Drawing.Point(12, 156);
            this.tbTimeOn.Maximum = 60;
            this.tbTimeOn.Minimum = 3;
            this.tbTimeOn.Name = "tbTimeOn";
            this.tbTimeOn.Size = new System.Drawing.Size(307, 45);
            this.tbTimeOn.TabIndex = 1;
            this.tbTimeOn.Value = 3;
            this.tbTimeOn.ValueChanged += new System.EventHandler(this.TrackBarValuesChanged);
            // 
            // tbPreparation
            // 
            this.tbPreparation.Location = new System.Drawing.Point(12, 92);
            this.tbPreparation.Maximum = 60;
            this.tbPreparation.Name = "tbPreparation";
            this.tbPreparation.Size = new System.Drawing.Size(307, 45);
            this.tbPreparation.TabIndex = 1;
            this.tbPreparation.Value = 3;
            this.tbPreparation.ValueChanged += new System.EventHandler(this.TrackBarValuesChanged);
            // 
            // lPreparation
            // 
            this.lPreparation.AutoSize = true;
            this.lPreparation.Location = new System.Drawing.Point(12, 76);
            this.lPreparation.Name = "lPreparation";
            this.lPreparation.Size = new System.Drawing.Size(158, 13);
            this.lPreparation.TabIndex = 2;
            this.lPreparation.Text = "Preparation ({0} seconds)";
            // 
            // lTimeOn
            // 
            this.lTimeOn.AutoSize = true;
            this.lTimeOn.Location = new System.Drawing.Point(12, 140);
            this.lTimeOn.Name = "lTimeOn";
            this.lTimeOn.Size = new System.Drawing.Size(140, 13);
            this.lTimeOn.TabIndex = 3;
            this.lTimeOn.Text = "Time On ({0} seconds)";
            // 
            // lTimeOff
            // 
            this.lTimeOff.AutoSize = true;
            this.lTimeOff.Location = new System.Drawing.Point(12, 204);
            this.lTimeOff.Name = "lTimeOff";
            this.lTimeOff.Size = new System.Drawing.Size(141, 13);
            this.lTimeOff.TabIndex = 3;
            this.lTimeOff.Text = "Time Off ({0} seconds)";
            // 
            // rtbMain
            // 
            this.rtbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMain.Location = new System.Drawing.Point(325, 11);
            this.rtbMain.Name = "rtbMain";
            this.rtbMain.ReadOnly = true;
            this.rtbMain.Size = new System.Drawing.Size(370, 300);
            this.rtbMain.TabIndex = 4;
            this.rtbMain.Text = "";
            // 
            // lRounds
            // 
            this.lRounds.AutoSize = true;
            this.lRounds.Location = new System.Drawing.Point(12, 12);
            this.lRounds.Name = "lRounds";
            this.lRounds.Size = new System.Drawing.Size(84, 13);
            this.lRounds.TabIndex = 6;
            this.lRounds.Text = "Rounds ({0})";
            // 
            // tbRounds
            // 
            this.tbRounds.Location = new System.Drawing.Point(12, 28);
            this.tbRounds.Maximum = 20;
            this.tbRounds.Minimum = 2;
            this.tbRounds.Name = "tbRounds";
            this.tbRounds.Size = new System.Drawing.Size(307, 45);
            this.tbRounds.TabIndex = 5;
            this.tbRounds.Value = 10;
            this.tbRounds.ValueChanged += new System.EventHandler(this.TrackBarValuesChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 323);
            this.Controls.Add(this.lRounds);
            this.Controls.Add(this.tbRounds);
            this.Controls.Add(this.rtbMain);
            this.Controls.Add(this.lTimeOff);
            this.Controls.Add(this.lTimeOn);
            this.Controls.Add(this.lPreparation);
            this.Controls.Add(this.tbPreparation);
            this.Controls.Add(this.tbTimeOn);
            this.Controls.Add(this.tbTimeOff);
            this.Controls.Add(this.bStart);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPreparation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRounds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.TrackBar tbTimeOff;
        private System.Windows.Forms.TrackBar tbTimeOn;
        private System.Windows.Forms.TrackBar tbPreparation;
        private System.Windows.Forms.Label lPreparation;
        private System.Windows.Forms.Label lTimeOn;
        private System.Windows.Forms.Label lTimeOff;
        private System.Windows.Forms.RichTextBox rtbMain;
        private System.Windows.Forms.Label lRounds;
        private System.Windows.Forms.TrackBar tbRounds;
    }
}