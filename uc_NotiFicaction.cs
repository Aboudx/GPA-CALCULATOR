using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPA_CALCULATOR
{
    public partial class uc_NotiFicaction : UserControl
    {
        public event EventHandler NotificationClosed;
        public uc_NotiFicaction(Image Pic, string lbTittle, string LbMessage)
        {
            InitializeComponent();

            picState.Image = Pic;
            this.lbTittle.Text = lbTittle;
            this.lbMessage.Text = LbMessage;

            tmNotification.Interval = 3000;
            tmNotification.Stop();
            tmNotification.Start();
        }

        private void CloseNotification()
        {
            tmNotification.Stop();

            NotificationClosed?.Invoke(this, EventArgs.Empty);


            if (this.Parent != null)
                this.Parent.Controls.Remove(this);

            this.Dispose();

        }

        private void picClose_Click(object sender, EventArgs e)
        {
            CloseNotification();
        }

        private void tmNotification_Tick(object sender, EventArgs e)
        {
            CloseNotification();

        }
    }
}
