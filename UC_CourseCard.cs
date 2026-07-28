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
        public event EventHandler DeleteRequested;
        public event EventHandler UpdateRequested;


        private stCourse _course;
        public stCourse Course
        {
            get { return _course; }
            set
            {
                _course = value;

                RefreshCard();

                ChangeForeAndBackColorGrade();
            }
        }
        public UC_CourseCard(stCourse course)
        {
            InitializeComponent();

            _course= course; 

            ChangeForeAndBackColorGrade();

            RefreshCard();
        }

        public void ChangeableDeleteAndEditButtons(bool State)
        {
            btnEdit.Enabled = State;
            btnDelete.Enabled = State;
        }

        private void RefreshCard()
        {
            lblCourseName.Text = _course.CourseName;
            lblCreditHours.Text = _course.CreditHours.ToString();
            lblGrade.Text = GetLetterGrade(_course.LetterGrade);
            
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

        public void ChangeForeAndBackColorGrade()
        {
            if (_course.LetterGrade == enLetterGrades.AP || _course.LetterGrade == enLetterGrades.A ||
                _course.LetterGrade == enLetterGrades.AM
             || _course.LetterGrade == enLetterGrades.BP || _course.LetterGrade == enLetterGrades.B ||
             _course.LetterGrade == enLetterGrades.BM)
            {
                lblGrade.BackColor = Color.FromArgb(232, 247, 236);
                lblGrade.ForeColor = Color.FromArgb(46, 125, 50);
            }
            else if (_course.LetterGrade == enLetterGrades.CP || _course.LetterGrade == enLetterGrades.C ||
                _course.LetterGrade == enLetterGrades.AM
             || _course.LetterGrade == enLetterGrades.CM || _course.LetterGrade == enLetterGrades.DP ||
             _course.LetterGrade == enLetterGrades.D)
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
            DeleteRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateRequested?.Invoke(this, EventArgs.Empty);
        }

    }
}
