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
            AP = 1, A, AM, BP, B, BM, CP, C, CM, DP, D, F
        };

        private enum enMode
        {
            Normal,
            Update
        }

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
        }

        List<stCourse> lstCourses = new List<stCourse>();
        stStudent _Student;
        enMode _CurrentMode;
        private UC_CourseCard _SelectedCardForUpdate;

        public frmMain()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#F4F7FC");

            _Student = new stStudent();

            _CurrentMode = enMode.Normal;

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
            stCourse course = new stCourse();

            course.Grade = Convert.ToSingle(tbGrade.Text);
            course.CourseName = tbCourseBName.Text;
            course.CreditHours = Convert.ToByte(cbCreditHours.Text);
            course.LetterGrade = GetLetterGrade(course.Grade);
            course.GuidID = Guid.NewGuid();

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
            Card.DeleteRequested += Card_DeleteRequested;
            Card.UpdateRequested += Card_UpdateRequested;

            flbCourseList.Controls.Add(Card);

            UpdateStatistics();
            ResetCourseInputs();

        }

        private void ResetMode()
        {
            _CurrentMode = enMode.Normal;

            _SelectedCardForUpdate.ChangeableDeleteAndEditButtons(true);

            _SelectedCardForUpdate = null;

            ChangeButtonAndTittleForAddNewMode();
            ResetCourseInputs();
        }

        public void btnAddNewAndEditCourse_Click(object sender, EventArgs e)
        {
            if (_CurrentMode == enMode.Update)
            {
                UpdateCourse(_SelectedCardForUpdate);
                ResetMode();
                return;
            }

            if (_CurrentMode == enMode.Normal)
                AddNewCourse();
        }

        private void UpdateCourse(UC_CourseCard card)
        {

            byte OldHours = card.Course.CreditHours;

            int CardIndex = flbCourseList.Controls.IndexOf(card);

            UC_CourseCard UptCard = (UC_CourseCard)flbCourseList.Controls[CardIndex];
            UptCard.Course = UpdateCourseInfo(card.Course);

            _Student.ThisSemesterHours -= OldHours;
            _Student.ThisSemesterHours += UptCard.Course.CreditHours;

            UptCard.Refresh();

            int CourseIndex = lstCourses.FindIndex(c => c.GuidID == card.Course.GuidID);

            lstCourses[CourseIndex] = UptCard.Course;

            UpdateStatistics();
        }

        private void DeleteCourse(UC_CourseCard card)
        {
            lstCourses.Remove(card.Course);
            flbCourseList.Controls.Remove(card);

            _Student.ThisSemesterHours -= card.Course.CreditHours;
            _Student.SemesterTotalCourse--;

            UpdateStatistics();

        }

        private void Card_DeleteRequested(object sender, EventArgs e)
        {
            DeleteCourse((UC_CourseCard)sender);
        }

        private void SetCardInfoInLeftSection(stCourse course)
        {
            tbCourseBName.Text = course.CourseName;
            tbGrade.Text = course.Grade.ToString();
            cbCreditHours.Text = course.CreditHours.ToString();
        }

        private void ChangeButtonAndTittleForUpdateMode()
        {

            TittleAddOrUpdate.Image = Properties.Resources.UpdateCourseImage;
            TittleAddOrUpdate.SizeMode = PictureBoxSizeMode.StretchImage;

            btnAddCourse.Image = Properties.Resources.icons8_pen_48;
            btnAddCourse.Text = "Update Course";
        }

        private stCourse UpdateCourseInfo(stCourse course)
        {
            course.CourseName = tbCourseBName.Text;
            course.CreditHours = Convert.ToByte(cbCreditHours.Text);
            course.Grade = Convert.ToSingle(tbGrade.Text);
            course.LetterGrade = GetLetterGrade(course.Grade);

            return course;
        }
        private void ChangeToUpdateMode(UC_CourseCard Card)
        {
            _CurrentMode = enMode.Update;

            _SelectedCardForUpdate.ChangeableDeleteAndEditButtons(false);

            ChangeButtonAndTittleForUpdateMode();


            stCourse course = Card.Course;
            SetCardInfoInLeftSection(course);

        }

        private void ChangeButtonAndTittleForAddNewMode()
        {

            TittleAddOrUpdate.Image = Properties.Resources.AddNewCourseImage;
            TittleAddOrUpdate.SizeMode = PictureBoxSizeMode.Normal;

            btnAddCourse.Image = Properties.Resources.icons8_plus_24;
            btnAddCourse.Text = "Add Course";
        }

        private void ApplyCurrentUpdate()
        {
            UpdateCourse(_SelectedCardForUpdate);
            _SelectedCardForUpdate.ChangeableDeleteAndEditButtons(true);
        }

        private void Card_UpdateRequested(object sender, EventArgs e)
        {
            if (_CurrentMode == enMode.Update) ApplyCurrentUpdate();

            _SelectedCardForUpdate = (UC_CourseCard)sender;
            ChangeToUpdateMode(_SelectedCardForUpdate);
        }
    }
}
