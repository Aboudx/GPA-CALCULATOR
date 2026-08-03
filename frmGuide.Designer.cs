namespace GPA_CALCULATOR
{
    partial class frmGuide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGuide));
            this.tbLaungunge = new Guna.UI2.WinForms.Guna2TabControl();
            this.tpArabic = new System.Windows.Forms.TabPage();
            this.tbEnglish = new System.Windows.Forms.TabPage();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.tbLaungunge.SuspendLayout();
            this.tpArabic.SuspendLayout();
            this.tbEnglish.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tbLaungunge
            // 
            this.tbLaungunge.Controls.Add(this.tpArabic);
            this.tbLaungunge.Controls.Add(this.tbEnglish);
            this.tbLaungunge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbLaungunge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLaungunge.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tbLaungunge.ItemSize = new System.Drawing.Size(140, 40);
            this.tbLaungunge.Location = new System.Drawing.Point(0, 0);
            this.tbLaungunge.Name = "tbLaungunge";
            this.tbLaungunge.Padding = new System.Drawing.Point(12, 12);
            this.tbLaungunge.SelectedIndex = 0;
            this.tbLaungunge.Size = new System.Drawing.Size(992, 571);
            this.tbLaungunge.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tbLaungunge.TabButtonHoverState.FillColor = System.Drawing.Color.White;
            this.tbLaungunge.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tbLaungunge.TabButtonHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(76)))), ((int)(((byte)(181)))));
            this.tbLaungunge.TabButtonHoverState.InnerColor = System.Drawing.Color.White;
            this.tbLaungunge.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tbLaungunge.TabButtonIdleState.FillColor = System.Drawing.Color.White;
            this.tbLaungunge.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tbLaungunge.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.tbLaungunge.TabButtonIdleState.InnerColor = System.Drawing.Color.White;
            this.tbLaungunge.TabButtonSelectedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.tbLaungunge.TabButtonSelectedState.FillColor = System.Drawing.Color.White;
            this.tbLaungunge.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tbLaungunge.TabButtonSelectedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(76)))), ((int)(((byte)(181)))));
            this.tbLaungunge.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(76)))), ((int)(((byte)(181)))));
            this.tbLaungunge.TabButtonSize = new System.Drawing.Size(140, 40);
            this.tbLaungunge.TabIndex = 33;
            this.tbLaungunge.TabMenuBackColor = System.Drawing.Color.White;
            this.tbLaungunge.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            this.tbLaungunge.SelectedIndexChanged += new System.EventHandler(this.tbLaungunge_SelectedIndexChanged);
            // 
            // tpArabic
            // 
            this.tpArabic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.tpArabic.Controls.Add(this.guna2PictureBox1);
            this.tpArabic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.tpArabic.Location = new System.Drawing.Point(4, 44);
            this.tpArabic.Name = "tpArabic";
            this.tpArabic.Padding = new System.Windows.Forms.Padding(3);
            this.tpArabic.Size = new System.Drawing.Size(984, 523);
            this.tpArabic.TabIndex = 1;
            this.tpArabic.Text = "Arabic";
            // 
            // tbEnglish
            // 
            this.tbEnglish.Controls.Add(this.guna2PictureBox2);
            this.tbEnglish.Location = new System.Drawing.Point(4, 44);
            this.tbEnglish.Name = "tbEnglish";
            this.tbEnglish.Size = new System.Drawing.Size(984, 523);
            this.tbEnglish.TabIndex = 2;
            this.tbEnglish.Text = "English";
            this.tbEnglish.UseVisualStyleBackColor = true;
            this.tbEnglish.Click += new System.EventHandler(this.tbEnglish_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.guna2PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2PictureBox1.Image = global::GPA_CALCULATOR.Properties.Resources.Ararbic_Guide;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(3, 3);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(978, 517);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.guna2PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2PictureBox2.Image = global::GPA_CALCULATOR.Properties.Resources.English_Guide_Final;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(0, 0);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(984, 523);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 1;
            this.guna2PictureBox2.TabStop = false;
            // 
            // frmGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 571);
            this.Controls.Add(this.tbLaungunge);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmGuide";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quick Guide User";
            this.tbLaungunge.ResumeLayout(false);
            this.tpArabic.ResumeLayout(false);
            this.tbEnglish.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TabControl tbLaungunge;
        private System.Windows.Forms.TabPage tpArabic;
        private System.Windows.Forms.TabPage tbEnglish;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
    }
}