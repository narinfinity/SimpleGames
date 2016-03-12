namespace DiamondDash
{
    partial class MyForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TimePanel = new System.Windows.Forms.Panel();
            this.ScorePanel = new System.Windows.Forms.Panel();
            this.PauseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TimePanel
            // 
            this.TimePanel.BackColor = System.Drawing.Color.White;
            this.TimePanel.Location = new System.Drawing.Point(447, 67);
            this.TimePanel.Name = "TimePanel";
            this.TimePanel.Size = new System.Drawing.Size(39, 30);
            this.TimePanel.TabIndex = 0;
            this.TimePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TimePanel_Paint);
            // 
            // ScorePanel
            // 
            this.ScorePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ScorePanel.Location = new System.Drawing.Point(500, 68);
            this.ScorePanel.Name = "ScorePanel";
            this.ScorePanel.Size = new System.Drawing.Size(73, 24);
            this.ScorePanel.TabIndex = 1;
            this.ScorePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ScorePanel_Paint);
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.PauseButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.PauseButton.FlatAppearance.BorderSize = 0;
            this.PauseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.PauseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.PauseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.PauseButton.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseButton.ForeColor = System.Drawing.Color.White;
            this.PauseButton.Location = new System.Drawing.Point(487, 9);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(94, 40);
            this.PauseButton.TabIndex = 2;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = false;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 370);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.ScorePanel);
            this.Controls.Add(this.TimePanel);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.Name = "MyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diamond Dash";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TimePanel;
        private System.Windows.Forms.Panel ScorePanel;
        private System.Windows.Forms.Button PauseButton;

    }
}

