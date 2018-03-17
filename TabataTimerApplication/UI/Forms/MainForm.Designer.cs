namespace KegelTimerApplication.UI.Forms
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
                _kegelTimer.Dispose();
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
            this.tbOffTime = new System.Windows.Forms.TrackBar();
            this.tbOnTime = new System.Windows.Forms.TrackBar();
            this.tbPreparationTime = new System.Windows.Forms.TrackBar();
            this.lPreparationTime = new System.Windows.Forms.Label();
            this.lOnTime = new System.Windows.Forms.Label();
            this.lOffTime = new System.Windows.Forms.Label();
            this.rtbMain = new System.Windows.Forms.RichTextBox();
            this.lRounds = new System.Windows.Forms.Label();
            this.tbRounds = new System.Windows.Forms.TrackBar();
            this.lLongerLastRoundTime = new System.Windows.Forms.Label();
            this.tbLongerLastRoundTime = new System.Windows.Forms.TrackBar();
            this.lLongerLastRoundTimeToggle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbOffTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOnTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPreparationTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRounds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLongerLastRoundTime)).BeginInit();
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(12, 207);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(624, 40);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // tbOffTime
            // 
            this.tbOffTime.Location = new System.Drawing.Point(329, 92);
            this.tbOffTime.Maximum = 60;
            this.tbOffTime.Minimum = 3;
            this.tbOffTime.Name = "tbOffTime";
            this.tbOffTime.Size = new System.Drawing.Size(307, 45);
            this.tbOffTime.TabIndex = 1;
            this.tbOffTime.Value = 3;
            this.tbOffTime.ValueChanged += new System.EventHandler(this.TrackBarValuesChanged);
            // 
            // tbOnTime
            // 
            this.tbOnTime.Location = new System.Drawing.Point(329, 25);
            this.tbOnTime.Maximum = 60;
            this.tbOnTime.Minimum = 3;
            this.tbOnTime.Name = "tbOnTime";
            this.tbOnTime.Size = new System.Drawing.Size(307, 45);
            this.tbOnTime.TabIndex = 1;
            this.tbOnTime.Value = 3;
            this.tbOnTime.ValueChanged += new System.EventHandler(this.TrackBarValuesChanged);
            // 
            // tbPreparationTime
            // 
            this.tbPreparationTime.Location = new System.Drawing.Point(12, 92);
            this.tbPreparationTime.Maximum = 60;
            this.tbPreparationTime.Name = "tbPreparationTime";
            this.tbPreparationTime.Size = new System.Drawing.Size(307, 45);
            this.tbPreparationTime.TabIndex = 1;
            this.tbPreparationTime.Value = 3;
            this.tbPreparationTime.ValueChanged += new System.EventHandler(this.TrackBarValuesChanged);
            // 
            // lPreparationTime
            // 
            this.lPreparationTime.AutoSize = true;
            this.lPreparationTime.Location = new System.Drawing.Point(12, 76);
            this.lPreparationTime.Name = "lPreparationTime";
            this.lPreparationTime.Size = new System.Drawing.Size(190, 13);
            this.lPreparationTime.TabIndex = 2;
            this.lPreparationTime.Text = "Preparation Time ({0} seconds)";
            // 
            // lOnTime
            // 
            this.lOnTime.AutoSize = true;
            this.lOnTime.Location = new System.Drawing.Point(326, 9);
            this.lOnTime.Name = "lOnTime";
            this.lOnTime.Size = new System.Drawing.Size(140, 13);
            this.lOnTime.TabIndex = 3;
            this.lOnTime.Text = "On Time ({0} seconds)";
            // 
            // lOffTime
            // 
            this.lOffTime.AutoSize = true;
            this.lOffTime.Location = new System.Drawing.Point(328, 76);
            this.lOffTime.Name = "lOffTime";
            this.lOffTime.Size = new System.Drawing.Size(141, 13);
            this.lOffTime.TabIndex = 3;
            this.lOffTime.Text = "Off Time ({0} seconds)";
            // 
            // rtbMain
            // 
            this.rtbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMain.Location = new System.Drawing.Point(12, 253);
            this.rtbMain.Name = "rtbMain";
            this.rtbMain.ReadOnly = true;
            this.rtbMain.Size = new System.Drawing.Size(624, 145);
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
            // lLongerLastRoundTime
            // 
            this.lLongerLastRoundTime.AutoSize = true;
            this.lLongerLastRoundTime.Enabled = false;
            this.lLongerLastRoundTime.Location = new System.Drawing.Point(12, 140);
            this.lLongerLastRoundTime.Name = "lLongerLastRoundTime";
            this.lLongerLastRoundTime.Size = new System.Drawing.Size(230, 13);
            this.lLongerLastRoundTime.TabIndex = 8;
            this.lLongerLastRoundTime.Text = "Longer Last Round Time ({0} seconds)";
            // 
            // tbLongerLastRoundTime
            // 
            this.tbLongerLastRoundTime.Enabled = false;
            this.tbLongerLastRoundTime.Location = new System.Drawing.Point(12, 156);
            this.tbLongerLastRoundTime.Maximum = 60;
            this.tbLongerLastRoundTime.Name = "tbLongerLastRoundTime";
            this.tbLongerLastRoundTime.Size = new System.Drawing.Size(307, 45);
            this.tbLongerLastRoundTime.TabIndex = 7;
            this.tbLongerLastRoundTime.Value = 3;
            this.tbLongerLastRoundTime.ValueChanged += new System.EventHandler(this.TrackBarValuesChanged);
            // 
            // lLongerLastRoundTimeToggle
            // 
            this.lLongerLastRoundTimeToggle.AutoSize = true;
            this.lLongerLastRoundTimeToggle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lLongerLastRoundTimeToggle.Location = new System.Drawing.Point(262, 138);
            this.lLongerLastRoundTimeToggle.Name = "lLongerLastRoundTimeToggle";
            this.lLongerLastRoundTimeToggle.Size = new System.Drawing.Size(47, 15);
            this.lLongerLastRoundTimeToggle.TabIndex = 9;
            this.lLongerLastRoundTimeToggle.Text = "Enable";
            this.lLongerLastRoundTimeToggle.Click += new System.EventHandler(this.lLongerLastRoundTimeToggle_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 410);
            this.Controls.Add(this.lLongerLastRoundTimeToggle);
            this.Controls.Add(this.lLongerLastRoundTime);
            this.Controls.Add(this.tbLongerLastRoundTime);
            this.Controls.Add(this.lRounds);
            this.Controls.Add(this.tbRounds);
            this.Controls.Add(this.rtbMain);
            this.Controls.Add(this.lOffTime);
            this.Controls.Add(this.lOnTime);
            this.Controls.Add(this.lPreparationTime);
            this.Controls.Add(this.tbPreparationTime);
            this.Controls.Add(this.tbOnTime);
            this.Controls.Add(this.tbOffTime);
            this.Controls.Add(this.bStart);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "Kegel Excerise Timer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tbOffTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOnTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPreparationTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRounds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLongerLastRoundTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.TrackBar tbOffTime;
        private System.Windows.Forms.TrackBar tbOnTime;
        private System.Windows.Forms.TrackBar tbPreparationTime;
        private System.Windows.Forms.Label lPreparationTime;
        private System.Windows.Forms.Label lOnTime;
        private System.Windows.Forms.Label lOffTime;
        private System.Windows.Forms.RichTextBox rtbMain;
        private System.Windows.Forms.Label lRounds;
        private System.Windows.Forms.TrackBar tbRounds;
        private System.Windows.Forms.Label lLongerLastRoundTime;
        private System.Windows.Forms.TrackBar tbLongerLastRoundTime;
        private System.Windows.Forms.Label lLongerLastRoundTimeToggle;
    }
}