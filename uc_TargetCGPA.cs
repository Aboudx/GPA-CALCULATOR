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
using static GPA_CALCULATOR.frmMain;

namespace GPA_CALCULATOR
{
    public partial class uc_TargetCGPA : UserControl
    {
        enStateTargtCGPA State;
        string TargetCGPA;
        string TargetGPA;
        public uc_TargetCGPA(double TargetGPA,double TargetCGPA, enStateTargtCGPA State)
        {
            InitializeComponent();
            this.State = State;
            this.TargetGPA = TargetGPA.ToString("F2");
            this.TargetCGPA = TargetCGPA.ToString("F2");

            ChangePanelState();
        }

        private void ChangeColorAndForeColor(string FillColor,string ForeColor)
        {

            pnlCheckTargetCGPA.FillColor = ColorTranslator.FromHtml(FillColor);
            lbTargetGPA.ForeColor = ColorTranslator.FromHtml(ForeColor);

            lbCheckCGPA1.ForeColor = ColorTranslator.FromHtml(ForeColor);

            lbCheckCGPA3.ForeColor = ColorTranslator.FromHtml(ForeColor);
        }
        private void ChangePanelState()
        {
            if (State == enStateTargtCGPA.Achivable)
            {
                lbCheckCGPA1.Text = "Required Semester CGPA";
                lbTargetGPA.Text = TargetGPA;
                lbCheckCGPA3.Text = $"You need a Semester GPA of " +
                    $"\n\r {TargetGPA} to achieve a CGPA of {TargetCGPA}.";

                ChangeColorAndForeColor("#E8F7EC", "#2E7D32");

            }
            else if (State == enStateTargtCGPA.VerryDifficult)
            {
                lbCheckCGPA1.Text = "Required Semester CGPA";
                lbTargetGPA.Text = TargetGPA;

                lbCheckCGPA3.Text = $"You need a Semester GPA of " +
                    $"\n\r {TargetGPA} to achieve a CGPA of {TargetCGPA}.";

                ChangeColorAndForeColor("#FFF4DD", "#C77800");
                lbCheckCGPA3.Text = "Requires exceptional \n\r performance.";

            }
            else if (State == enStateTargtCGPA.IsAchivabled)
            {
                ChangeColorAndForeColor("#E8F7EC", "#2E7D32");

                lbCheckCGPA3.Text = "Target CGPA Is achievabled. ";
            }
            else if (State == enStateTargtCGPA.Impossible)
            {
                ChangeColorAndForeColor("#FDECEC", "#D32F2F");

                lbCheckCGPA3.Text = "This cannot be achieved \n\r in one semester. ";
            }

        }
    }
}
