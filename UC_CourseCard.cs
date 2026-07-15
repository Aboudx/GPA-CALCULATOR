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
    public partial class UC_CourseCard : UserControl
    {
        enLetterGrades Grade;
        public UC_CourseCard(stCourse course)
        {
            InitializeComponent();
            Grade = course.LetterGrade;

            ChangeForeAndBackColorGrade();

            lblCourseName.Text = course.CourseName;
            lblCreditHours.Text = course.CreditHours.ToString();
            lblGrade.Text = GetLetterGrade(Grade);
        }

        public static string GetLetterGrade(enLetterGrades grade)
        {
            switch (grade)
            {
                case enLetterGrades.AP:
                    return "A+";

                case enLetterGrades.A:
                    return "A ";

                case enLetterGrades.AM:
                    return "A-";

                case enLetterGrades.BP:
                    return "B+";

                case enLetterGrades.B:
                    return "B ";

                case enLetterGrades.BM:
                    return "B-";

                case enLetterGrades.CP:
                    return "C+";

                case enLetterGrades.C:
                    return "C ";

                case enLetterGrades.CM:
                    return "C-";

                case enLetterGrades.DP:
                    return "D+";

                case enLetterGrades.D:
                    return "D ";

                case enLetterGrades.F:
                    return "F ";

                default:
                    return "";
            }
        }

        private void ChangeForeAndBackColorGrade()
        {
            if (Grade == enLetterGrades.AP || Grade == enLetterGrades.A || Grade == enLetterGrades.AM
             || Grade == enLetterGrades.BP || Grade == enLetterGrades.B || Grade == enLetterGrades.BM)
            {
                lblGrade.BackColor = Color.FromArgb(232, 247, 236);
                lblGrade.ForeColor = Color.FromArgb(46, 125, 50);
            }
            else if (Grade == enLetterGrades.CP || Grade == enLetterGrades.C || Grade == enLetterGrades.AM
             || Grade == enLetterGrades.CM || Grade == enLetterGrades.DP || Grade == enLetterGrades.D)
            {
                lblGrade.BackColor = Color.FromArgb(255, 244, 221);
                lblGrade.ForeColor = Color.FromArgb(199, 120, 0);
            }
            else
            {
                lblGrade.BackColor = Color.FromArgb(253, 236, 236);
                lblGrade.ForeColor = Color.FromArgb(211, 47, 47);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
