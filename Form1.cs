using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;

namespace GPA_CALCULATOR
{
    public partial class frmMain : Form
    {
        public enum enLetterGrades : byte
        { 
            AP=1 ,A ,AM ,BP ,B ,BM ,CP ,C ,CM,DP,D ,F
        };

        private struct stStudent
        {
            public double CumuGPA;
            public double SemesterGPA;
            public byte CompletedHours;
            public byte ThisSemesterHours;
            public byte SemesterTotalCourse;
        }
        public struct stCourse
        {
            public Guid GuidID;
            public string CourseName;
            public float Grade;
            public byte CreditHours;
            public enLetterGrades LetterGrade;

            public bool MarkForDelete;
            public bool MarkForUpdate;
        }

        List<stCourse> lstCourses = new List<stCourse>();
        stStudent _Student;
        
        public frmMain()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#F4F7FC");

            _Student = new stStudent();

            _Student.SemesterTotalCourse = 0;
            _Student.ThisSemesterHours = 0;
        }

        private void ResetCourseInputs()
        {
            tbCourseBName.Clear();
            tbGrade.Clear();
            cbCreditHours.SelectedIndex = -1;

            tbCourseBName.Focus();
        }

        private void UpdateStatistics()
        {
            lbTotalCourse.Text = _Student.SemesterTotalCourse.ToString();
            lbTotalCredit.Text = _Student.ThisSemesterHours.ToString();
        }
        private bool IsCourseInfoIncomplete()
        {
            if (string.IsNullOrWhiteSpace(tbCourseBName.Text)
               || string.IsNullOrWhiteSpace(tbGrade.Text)
               || string.IsNullOrWhiteSpace(cbCreditHours.Text)
              ) return true;

            return false;
        }

        private enLetterGrades GetLetterGrade(float Grade)
        {
            if (Grade >= 97)
                return enLetterGrades.AP;

            else if (Grade >= 95)
                return enLetterGrades.A;

            else if (Grade >= 90)
                return enLetterGrades.AM;

            else if (Grade >= 85)
                return enLetterGrades.BP;

            else if (Grade >= 80)
                return enLetterGrades.B;

            else if (Grade >= 75)
                return enLetterGrades.BM;

            else if (Grade >= 70)
                return enLetterGrades.CP;

            else if (Grade >= 65)
                return enLetterGrades.C;

            else if (Grade >= 60)
                return enLetterGrades.CM;

            else if (Grade >= 55)
                return enLetterGrades.DP;

            else if (Grade >= 50)
                return enLetterGrades.D;

            else return enLetterGrades.F;

        }

        private stCourse CreateCourse()
        {
            stCourse course=new stCourse();

            course.Grade = Convert.ToSingle(tbGrade.Text);
            course.CourseName = tbCourseBName.Text;
            course.CreditHours = Convert.ToByte(cbCreditHours.Text);
            course.LetterGrade = GetLetterGrade(course.Grade);

            _Student.ThisSemesterHours += course.CreditHours;
            _Student.SemesterTotalCourse++;

            return course;
        }

        private void AddNewCourse()
        {
            if (IsCourseInfoIncomplete()) return;

            stCourse Course = CreateCourse();

            lstCourses.Add(Course);

            UC_CourseCard Card = new UC_CourseCard(Course);
            flbCourseList.Controls.Add(Card);

            UpdateStatistics();
            ResetCourseInputs();

        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            AddNewCourse();
        }

        private void picGitHub_Click(object sender, EventArgs e)
        {

        }

        private void picLinkedIn_Click(object sender, EventArgs e)
        {

        }
    }
}
