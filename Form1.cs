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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#F4F7FC");
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            UC_CourseCard card = new UC_CourseCard();

            flbCourseList.Controls.Add(card);
        }

        private void picGitHub_Click(object sender, EventArgs e)
        {

        }

        private void picLinkedIn_Click(object sender, EventArgs e)
        {

        }
    }
}
