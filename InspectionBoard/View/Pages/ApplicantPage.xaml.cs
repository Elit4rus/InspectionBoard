using InspectionBoard.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace InspectionBoard.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ApplicantPage.xaml
    /// </summary>
    public partial class ApplicantPage : Page
    {
        List<Applicant> applicants = App.context.Applicant.ToList();
        List<Department> departments = App.context.Department.ToList();
        public ApplicantPage()
        {
            InitializeComponent();
            ApplicantLv.ItemsSource = applicants;
            departments.Insert(0, new Department() { Title = "Все кафедры" });
            DepartmentCmb.ItemsSource = departments;
        }

        private void DepartmentCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Department selectedDepartment = DepartmentCmb.SelectedItem as Department;
            PassportTbl.Text = string.Empty;
            SchoolTbl.Text = string.Empty;
            GraduationDateTbl.Text = string.Empty;
            if (DepartmentCmb.SelectedIndex == 0)
            {
                ApplicantLv.ItemsSource = applicants;
                MedalCb.IsChecked = false;
            }
            else
            {
                ApplicantLv.ItemsSource = applicants.Where(a => a.DepartmentID == selectedDepartment.ID).ToList();
            }
        }

        private void ApplicantLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ApplicantLv.SelectedItem == null)
            {
                PassportTbl.Text = string.Empty;
                SchoolTbl.Text = string.Empty;
                GraduationDateTbl.Text = string.Empty;
            }
            else
            {
                Applicant selectedApplicant = ApplicantLv.SelectedItem as Applicant;
                PassportTbl.Text = selectedApplicant.Passport;
                SchoolTbl.Text = selectedApplicant.School;
                GraduationDateTbl.Text = selectedApplicant.GraduationDate.ToShortDateString();
            }
        }

        private void MedalCb_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            PassportTbl.Text = string.Empty;
            SchoolTbl.Text = string.Empty;
            GraduationDateTbl.Text = string.Empty;
            if (MedalCb.IsChecked == true)
            {
                ApplicantLv.ItemsSource = applicants.Where(a => a.Medal == true);
            }
        }

        private void MedalCb_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            PassportTbl.Text = string.Empty;
            SchoolTbl.Text = string.Empty;
            GraduationDateTbl.Text = string.Empty;
            if (MedalCb.IsChecked == false)
            {
                ApplicantLv.ItemsSource = applicants;
            }
        }

    }
}
