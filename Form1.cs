using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;
using static GPA_CALCULATOR.frmMain;

namespace GPA_CALCULATOR
{
    public partial class frmMain : Form
    {
        public enum enLetterGrades : byte
        {
            AP = 1, A, AM, BP, B, BM, CP, C, CM, DP, D, F
        };

        public enum enStateTargtCGPA : byte
        {
            Achivable = 1,
            IsAchivabled = 2,
            VerryDifficult = 3,
            Impossible = 4
        }

        private enum enMode
        {
            Normal,
            Update
        }


        private struct stGPA
        {
            public double SemesterGPA;
            public double PrevCumuGPA;
            public double NewCumuGPA;
            public double ReqCumuGPA;
            public double ReqGPA;
            public double ReqCumuGPAPoints;
            public double ReqGPAPoints;
            public double SemesterGradePoints;
            public double TotalGradePoints;
        }

        private struct stStudent
        {
            public stGPA _GPA;
            public int CompletedHours;
            public byte ThisSemesterHours;
            public byte PassedSemesterHours;
            public byte SemesterTotalCourse;
            public byte TargetSemsterHours;
        }

        public struct stCourse
        {
            public Guid GuidID;
            public string CourseName;
            public float Grade;
            public double GradePoints;
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
            _Student._GPA = new stGPA();

            _CurrentMode = enMode.Normal;

            _Student._GPA.SemesterGradePoints = 0;
            _Student._GPA.TotalGradePoints = 0;

            _Student.SemesterTotalCourse = 0;
            _Student.ThisSemesterHours = 0;

            _Student.PassedSemesterHours = 0;

            pnlCheckTargetCGPA.Controls.Clear();
            pnlNotification.Controls.Clear();

        }

        private void ResetCourseInputs()
        {
            tbCourseBName.Clear();
            tbGrade.Clear();
            cbCreditHours.SelectedIndex = -1;

            tbCourseBName.Focus();
        }

        private void ShowNotiFication(Image Pic, string lbTittle, string LbMessage)
        {
            uc_NotiFicaction Notif = new uc_NotiFicaction(Pic, lbTittle, LbMessage);

            if (pnlNotification.Controls.Count > 0)
            {
                pnlNotification.Controls[0].Dispose();
                pnlNotification.Controls.Clear();
            }

            pnlNotification.Controls.Add(Notif);

            Notif.NotificationClosed += Notif_NotificationClosed;


            pnlNotification.Visible = true;

        }


        private void UpdateStatistics()
        {

            lbTotalCourse.Text = _Student.SemesterTotalCourse.ToString();
            lbTotalCredit.Text = _Student.ThisSemesterHours.ToString();

            lbSemesterGPA.Text = _Student._GPA.SemesterGPA.ToString("F2");
            lbCumuGPA.Text = _Student._GPA.NewCumuGPA.ToString("F2");

            lbTotalHours.Text =
              (_Student.CompletedHours + _Student.PassedSemesterHours).ToString();

            if (flbCourseList.Controls.Count <= 1)//1 => Because Position (1) Have Constant Value.
            {
                lbSemesterGPA.Text = "0.00";
                lbCumuGPA.Text = "0.00";
            }
        }

        private void UpdateTargetCGPAStatistics()
        {
            enStateTargtCGPA State = SetTargetCGPAState();

            uc_TargetCGPA CGPA_Card = new uc_TargetCGPA(_Student._GPA.ReqGPA
                , _Student._GPA.ReqCumuGPA, State);

            pnlCheckTargetCGPA.Controls.Clear();
            pnlCheckTargetCGPA.Controls.Add(CGPA_Card);

            ShowNotiFication(Properties.Resources.icons8_error_50, "Note", "RCGPA may vary by ±0.02.");

        }

        private bool FocusInEmptyItem(Control control)
        {
            control.Focus();
            return true;
        }

        private bool IsCourseInfoIncomplete()
        {
            if (string.IsNullOrWhiteSpace(tbCourseBName.Text))
            {
                return FocusInEmptyItem(tbCourseBName);
            }

            if (string.IsNullOrWhiteSpace(tbGrade.Text))
            {
                return FocusInEmptyItem(tbGrade);

            }

            if (string.IsNullOrWhiteSpace(cbCreditHours.Text))
            {
                return FocusInEmptyItem(cbCreditHours);
            }

            return false;

        }

        private bool IsStudentInfoInComplete()
        {
            if (string.IsNullOrWhiteSpace(tbCumuGPA.Text))
                return FocusInEmptyItem(tbCumuGPA);

            if (string.IsNullOrWhiteSpace(nudCompletedHours.Value.ToString()))
                return FocusInEmptyItem(nudCompletedHours);


            return false;
        }

        private bool IsStudentInfoInCompleteToCalcReqGPA()
        {
            if (string.IsNullOrWhiteSpace(tbCumuGPA.Text))
                return FocusInEmptyItem(tbCumuGPA);

            if (string.IsNullOrWhiteSpace(nudCompletedHours.Value.ToString()))
                return FocusInEmptyItem(nudCompletedHours);


            if (string.IsNullOrWhiteSpace(tbTargetCGPA.Text))
                return FocusInEmptyItem(tbTargetCGPA);

            if (string.IsNullOrWhiteSpace(nudSemsHoursTCGPA.Value.ToString()))
                return FocusInEmptyItem(nudSemsHoursTCGPA);

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

        private double GetGradePoints(enLetterGrades grades)
        {
            switch (grades)
            {
                case enLetterGrades.AP:
                    return 4.00;
                case enLetterGrades.A:
                    return 3.75;
                case enLetterGrades.AM:
                    return 3.50;
                case enLetterGrades.BP:
                    return 3.25;
                case enLetterGrades.B:
                    return 3.00;
                case enLetterGrades.BM:
                    return 2.75;
                case enLetterGrades.CP:
                    return 2.50;
                case enLetterGrades.C:
                    return 2.25;
                case enLetterGrades.CM:
                    return 2.00;
                case enLetterGrades.DP:
                    return 1.75;
                case enLetterGrades.D:
                    return 1.00;
                case enLetterGrades.F:
                    return 0.00;
                default:
                    return 0.00;
            }
        }

        private double CalculateGradePoints()
        {
            double Points = 0;

            foreach (stCourse C in lstCourses)
            {
                Points += (C.GradePoints * C.CreditHours);
            }

            return Points;
        }

        private double CalculateSemesterGPA()
        {
            return (double)(_Student._GPA.SemesterGradePoints / _Student.ThisSemesterHours);
        }

        private double CalculateTotalGradePoints()
        {
            return (double)(_Student.CompletedHours * _Student._GPA.PrevCumuGPA);
        }

        private double CalculateCGPA()
        {
            return ((_Student._GPA.TotalGradePoints + _Student._GPA.SemesterGradePoints)
                / (_Student.ThisSemesterHours + _Student.CompletedHours));
        }

        private double CalculateReqCumuGPAPoints()
        {
            return (double)(_Student._GPA.ReqCumuGPA * (_Student.CompletedHours + _Student.TargetSemsterHours));
        }

        private double CalculateReqGPAPoints()
        {
            return (double)(_Student._GPA.ReqCumuGPAPoints - _Student._GPA.TotalGradePoints);
        }

        private double CalculateReqGPA()
        {
            return (double)(_Student._GPA.ReqGPAPoints / _Student.TargetSemsterHours);
        }

        private stCourse CreateCourse()
        {
            stCourse course = new stCourse();

            course.Grade = Convert.ToSingle(tbGrade.Text);
            course.CourseName = tbCourseBName.Text;
            course.CreditHours = Convert.ToByte(cbCreditHours.Text);
            course.LetterGrade = GetLetterGrade(course.Grade);
            course.GradePoints = GetGradePoints(course.LetterGrade);
            course.GuidID = Guid.NewGuid();

            _Student.ThisSemesterHours += course.CreditHours;
            _Student.SemesterTotalCourse++;

            return course;
        }

        private bool CoursesIsFull()
        {
            return flbCourseList.Controls.Count > 10;
        }

        private void AddNewCourse()
        {
            if (IsCourseInfoIncomplete())
            {
                ShowNotiFication(Properties.Resources.icons8_error_48__1_, "Warning", "Enter the Add Course Info first..");
                return;
            }

            if (CoursesIsFull())
            {
                ShowNotiFication(Properties.Resources.icons8_error_48__1_, "Warning", "They cannot be more than 10");
                return;
            }

            stCourse Course = CreateCourse();


            lstCourses.Add(Course);

            UC_CourseCard Card = new UC_CourseCard(Course);
            Card.DeleteRequested += Card_DeleteRequested;
            Card.UpdateRequested += Card_UpdateRequested;

            flbCourseList.Controls.Add(Card);

            UpdateStatistics();
            ResetCourseInputs();

            ShowNotiFication(Properties.Resources.icons8_correct_64, "Success", "Course Added Successfully.");
        }

        private void ResetMode()
        {
            _CurrentMode = enMode.Normal;

            _SelectedCardForUpdate.ChangeableDeleteAndEditButtons(true);

            _SelectedCardForUpdate = null;

            ChangeButtonAndTittle();
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

            CalculateGPA();
            ShowNotiFication(Properties.Resources.icons8_correct_64, "Success", "Updated Successfully.");

        }

        private void DeleteCourse(UC_CourseCard card)
        {
            if (_CurrentMode == enMode.Update)
            {
                ApplyCurrentUpdate();
                ResetMode();
            }

            lstCourses.Remove(card.Course);
            flbCourseList.Controls.Remove(card);

            _Student.ThisSemesterHours -= card.Course.CreditHours;
            _Student.SemesterTotalCourse--;


            CalculateGPA();
            ShowNotiFication(Properties.Resources.icons8_error_50, "Completed", "Deleted Successfully.");

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

        private stCourse UpdateCourseInfo(stCourse course)
        {
            course.CourseName = tbCourseBName.Text;
            course.CreditHours = Convert.ToByte(cbCreditHours.Text);
            course.Grade = Convert.ToSingle(tbGrade.Text);
            course.LetterGrade = GetLetterGrade(course.Grade);
            course.GradePoints = GetGradePoints(course.LetterGrade);

            return course;
        }
        private void ChangeToUpdateMode(UC_CourseCard Card)
        {
            _CurrentMode = enMode.Update;

            _SelectedCardForUpdate.ChangeableDeleteAndEditButtons(false);

            ChangeButtonAndTittle();


            stCourse course = Card.Course;
            SetCardInfoInLeftSection(course);

        }

        private void ChangeButtonAndTittle()
        {
            switch (_CurrentMode)
            {
                case enMode.Normal:
                    TittleAddOrUpdate.Image = Properties.Resources.AddNewCourseImage;
                    TittleAddOrUpdate.SizeMode = PictureBoxSizeMode.Normal;

                    btnAddCourse.Image = Properties.Resources.icons8_plus_24;
                    btnAddCourse.Text = "Add Course";
                    break;

                case enMode.Update:
                    TittleAddOrUpdate.Image = Properties.Resources.UpdateCourseImage;
                    TittleAddOrUpdate.SizeMode = PictureBoxSizeMode.StretchImage;

                    btnAddCourse.Image = Properties.Resources.icons8_pen_48;
                    btnAddCourse.Text = "Update Course";
                    break;

                default:
                    break;
            }
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

        private void SetGPAData()
        {
            _Student._GPA.SemesterGradePoints = CalculateGradePoints();
            _Student._GPA.SemesterGPA = CalculateSemesterGPA();
            _Student._GPA.TotalGradePoints = CalculateTotalGradePoints();
            _Student._GPA.NewCumuGPA = CalculateCGPA();
        }

        private void SetIssentialInfo()
        {
            _Student._GPA.PrevCumuGPA = Convert.ToDouble(tbCumuGPA.Text);
            _Student.CompletedHours = Convert.ToByte(nudCompletedHours.Value);
        }

        private byte CalculatePassedSemesterHours()
        {
            _Student.PassedSemesterHours = 0;

            foreach (stCourse C in lstCourses)
            {
                if (C.Grade >= 50)
                {
                    _Student.PassedSemesterHours += C.CreditHours;
                }
            }

            return _Student.PassedSemesterHours;
        }

        private void CalculateGPA()
        {
            if (IsStudentInfoInComplete())
            {
                ShowNotiFication(Properties.Resources.icons8_error_48__1_, "Warning", "Enter the Acadimic Info first..");
                return;
            }

            SetIssentialInfo();

            SetGPAData();

            CalculatePassedSemesterHours();

            UpdateStatistics();

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateGPA();
        }

        private void SetTargetGPAData()
        {
            _Student._GPA.TotalGradePoints = CalculateTotalGradePoints();
            _Student._GPA.ReqCumuGPAPoints = CalculateReqCumuGPAPoints();
            _Student._GPA.ReqGPAPoints = CalculateReqGPAPoints();
            _Student._GPA.ReqGPA = CalculateReqGPA();
        }

        private void CalculateReqSemesterGPA()
        {
            if (IsStudentInfoInCompleteToCalcReqGPA())
            {
                ShowNotiFication(Properties.Resources.icons8_error_48__1_, "Warning", "Enter the Acadimic \n\t" +
                    "And target CGPA Info first..");
                return;
            }

            SetIssentialInfo();

            _Student.TargetSemsterHours = Convert.ToByte(nudSemsHoursTCGPA.Value);
            _Student._GPA.ReqCumuGPA = Convert.ToDouble(tbTargetCGPA.Text);

            SetTargetGPAData();

            UpdateTargetCGPAStatistics();
        }

        private enStateTargtCGPA SetTargetCGPAState()
        {
            if (_Student._GPA.ReqGPA >= 4)
            {
                return enStateTargtCGPA.Impossible;
            }
            else if (_Student._GPA.ReqGPA >= 3.5)
            {
                return enStateTargtCGPA.VerryDifficult;
            }
            else if (_Student._GPA.PrevCumuGPA >= _Student._GPA.ReqCumuGPA || _Student._GPA.ReqGPA <= 0)
            {
                return enStateTargtCGPA.IsAchivabled;
            }
            else return enStateTargtCGPA.Achivable;

        }

        private void btnCalcReqCGPA_Click(object sender, EventArgs e)
        {
            CalculateReqSemesterGPA();
        }

        private void ResetInfo()
        {

            ResetCourseInputs();

            // Course List
            while (flbCourseList.Controls.Count > 1)
            {
                flbCourseList.Controls.RemoveAt(1);
            }

            lstCourses.Clear();

            // Student Data
            _Student = new stStudent();

            // Statistics
            UpdateStatistics();
            ShowNotiFication(Properties.Resources.icons8_error_50, "Success", "Reset Successfully.");

            // Mode
            _CurrentMode = enMode.Normal;
            ChangeButtonAndTittle();

            tbCourseBName.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInfo();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        private void Notif_NotificationClosed(object sender, EventArgs e)
        {
            pnlNotification.Controls.Clear();
            pnlNotification.Visible = false;

        }
        private void tbCumuGPA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == (char)Keys.Back)
                return;

            if (e.KeyChar == '.' && !((Guna2TextBox)(sender)).Text.Contains('.'))
                return;

            e.Handled = true;
        }

        private void tbCumuGPA_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox tb = (Guna2TextBox)sender;

            if (double.TryParse(tb.Text, out double GPA))
            {

                if (GPA > 4)
                {
                    tb.Text = "4.00";
                    tb.SelectionStart = tb.Text.Length;
                    ShowNotiFication(Properties.Resources.icons8_error_50, "Note", "it should be Keyboard (EN)\n\t" +
                        "and between 0.00 and 4.00");
                }
            }
        }
        private void tbGrade_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == (char)Keys.Back)
                return;

            e.Handled = true;
        }

        private void tbGrade_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tbGrade.Text, out int Grade))
            {
                if (Grade > 100)
                {
                    tbGrade.Text = "100";
                    tbGrade.SelectionStart = tbGrade.Text.Length;
                    ShowNotiFication(Properties.Resources.icons8_error_50, "Note", "it should be Keyboard (EN)\n\t" +
                        "and between 0 and 100");
                }
            }
        }

        private void nudCompletedHours_ValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tbGrade.Text, out int Hours))
            {
                if (Hours > 350)
                {
                    tbGrade.Text = "350";
                    tbGrade.SelectionStart = tbGrade.Text.Length;
                    ShowNotiFication(Properties.Resources.icons8_error_50, "Note", "it should be Keyboard (EN)\n\t" +
                    "and between 0 and 350");
                }
            }
        }

        private void nudSemsHoursTCGPA_ValueChanged(object sender, EventArgs e)
        {
            if (Byte.TryParse(tbGrade.Text, out byte Credits))
            {
                if (Credits > 100)
                {
                    tbGrade.Text = "100";
                    tbGrade.SelectionStart = tbGrade.Text.Length;
                    ShowNotiFication(Properties.Resources.icons8_error_50, "Note", "it should be Keyboard (EN)\n\t" +
                                       "and between 0 and 24");
                }
            }
        }

        private void btnGuide_Click(object sender, EventArgs e)
        {
            frmGuide Guide = new frmGuide();
            Guide.ShowDialog();
        }
    }
}

