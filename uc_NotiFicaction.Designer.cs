namespace GPA_CALCULATOR
{
    partial class uc_NotiFicaction
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
            this.components = new System.ComponentModel.Container();
            this.pnlNotificat = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lbMessage = new System.Windows.Forms.Label();
            this.lbTittle = new System.Windows.Forms.Label();
            this.tmNotification = new System.Windows.Forms.Timer(this.components);
            this.picClose = new Guna.UI2.WinForms.Guna2PictureBox();
            this.picState = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlNotificat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picState)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNotificat
            // 
            this.pnlNotificat.BackColor = System.Drawing.Color.Transparent;
            this.pnlNotificat.Controls.Add(this.picClose);
            this.pnlNotificat.Controls.Add(this.lbMessage);
            this.pnlNotificat.Controls.Add(this.lbTittle);
            this.pnlNotificat.Controls.Add(this.picState);
            this.pnlNotificat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNotificat.FillColor = System.Drawing.Color.White;
            this.pnlNotificat.ForeColor = System.Drawing.Color.White;
            this.pnlNotificat.Location = new System.Drawing.Point(0, 0);
            this.pnlNotificat.Name = "pnlNotificat";
            this.pnlNotificat.Padding = new System.Windows.Forms.Padding(20);
            this.pnlNotificat.Radius = 8;
            this.pnlNotificat.ShadowColor = System.Drawing.Color.DarkGray;
            this.pnlNotificat.ShadowDepth = 35;
            this.pnlNotificat.ShadowShift = 2;
            this.pnlNotificat.Size = new System.Drawing.Size(319, 74);
            this.pnlNotificat.TabIndex = 47;
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessage.ForeColor = System.Drawing.Color.Black;
            this.lbMessage.Location = new System.Drawing.Point(63, 32);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(221, 17);
            this.lbMessage.TabIndex = 2;
            this.lbMessage.Text = "Operation Completed Succefully.";
            // 
            // lbTittle
            // 
            this.lbTittle.AutoSize = true;
            this.lbTittle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTittle.ForeColor = System.Drawing.Color.Black;
            this.lbTittle.Location = new System.Drawing.Point(63, 12);
            this.lbTittle.Name = "lbTittle";
            this.lbTittle.Size = new System.Drawing.Size(68, 18);
            this.lbTittle.TabIndex = 1;
            this.lbTittle.Text = "Success";
            // 
            // tmNotification
            // 
            this.tmNotification.Enabled = true;
            this.tmNotification.Interval = 3000;
            this.tmNotification.Tick += new System.EventHandler(this.tmNotification_Tick);
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::GPA_CALCULATOR.Properties.Resources.icons8_close_25;
            this.picClose.ImageRotate = 0F;
            this.picClose.Location = new System.Drawing.Point(288, 5);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(24, 22);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 33;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picState
            // 
            this.picState.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picState.Image = global::GPA_CALCULATOR.Properties.Resources.icons8_correct_64;
            this.picState.ImageRotate = 0F;
            this.picState.Location = new System.Drawing.Point(10, 11);
            this.picState.Name = "picState";
            this.picState.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picState.Size = new System.Drawing.Size(47, 41);
            this.picState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picState.TabIndex = 0;
            this.picState.TabStop = false;
            // 
            // uc_NotiFicaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlNotificat);
            this.Name = "uc_NotiFicaction";
            this.Size = new System.Drawing.Size(319, 74);
            this.pnlNotificat.ResumeLayout(false);
            this.pnlNotificat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel pnlNotificat;
        private System.Windows.Forms.Label lbTittle;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picState;
        private System.Windows.Forms.Label lbMessage;
        private Guna.UI2.WinForms.Guna2PictureBox picClose;
        private System.Windows.Forms.Timer tmNotification;
    }
}
