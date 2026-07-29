namespace GPA_CALCULATOR
{
    partial class frmAbout
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
            this.btnGitHub = new Guna.UI2.WinForms.Guna2Button();
            this.btnLinkedIn = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnGitHub
            // 
            this.btnGitHub.Animated = true;
            this.btnGitHub.BackColor = System.Drawing.Color.Transparent;
            this.btnGitHub.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.btnGitHub.BorderRadius = 12;
            this.btnGitHub.BorderThickness = 1;
            this.btnGitHub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGitHub.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGitHub.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGitHub.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(199)))), ((int)(((byte)(222)))));
            this.btnGitHub.DisabledState.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGitHub.FillColor = System.Drawing.Color.White;
            this.btnGitHub.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnGitHub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.btnGitHub.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnGitHub.Image = global::GPA_CALCULATOR.Properties.Resources.icons8_github_logo_94;
            this.btnGitHub.Location = new System.Drawing.Point(24, 404);
            this.btnGitHub.Name = "btnGitHub";
            this.btnGitHub.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(62)))), ((int)(((byte)(130)))));
            this.btnGitHub.Size = new System.Drawing.Size(186, 37);
            this.btnGitHub.TabIndex = 25;
            this.btnGitHub.Text = "GitHub";
            this.btnGitHub.Click += new System.EventHandler(this.btnGitHub_Click);
            // 
            // btnLinkedIn
            // 
            this.btnLinkedIn.Animated = true;
            this.btnLinkedIn.BackColor = System.Drawing.Color.Transparent;
            this.btnLinkedIn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(220)))), ((int)(((byte)(229)))));
            this.btnLinkedIn.BorderRadius = 12;
            this.btnLinkedIn.BorderThickness = 1;
            this.btnLinkedIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLinkedIn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLinkedIn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLinkedIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(199)))), ((int)(((byte)(222)))));
            this.btnLinkedIn.DisabledState.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLinkedIn.FillColor = System.Drawing.Color.White;
            this.btnLinkedIn.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnLinkedIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.btnLinkedIn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.btnLinkedIn.Image = global::GPA_CALCULATOR.Properties.Resources.icons8_linkedin_logo_48;
            this.btnLinkedIn.Location = new System.Drawing.Point(216, 404);
            this.btnLinkedIn.Name = "btnLinkedIn";
            this.btnLinkedIn.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(62)))), ((int)(((byte)(130)))));
            this.btnLinkedIn.Size = new System.Drawing.Size(186, 37);
            this.btnLinkedIn.TabIndex = 26;
            this.btnLinkedIn.Text = "LinkedIn";
            this.btnLinkedIn.Click += new System.EventHandler(this.btnLinkedIn_Click);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::GPA_CALCULATOR.Properties.Resources.About;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(440, 503);
            this.Controls.Add(this.btnLinkedIn);
            this.Controls.Add(this.btnGitHub);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Developer";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnGitHub;
        private Guna.UI2.WinForms.Guna2Button btnLinkedIn;
    }
}