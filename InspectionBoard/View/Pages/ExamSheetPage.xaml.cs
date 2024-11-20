using InspectionBoard.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InspectionBoard.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExamSheetPage.xaml
    /// </summary>
    public partial class ExamSheetPage : Page
    {
        List<Applicant> applicants = App.context.Applicant.ToList();
        List<DisciplineMark> disciplineMarks = App.context.DisciplineMark.ToList();
        public ExamSheetPage()
        {
            InitializeComponent();
            ApplicantCmb.ItemsSource = applicants;
        }

        private void ApplicantCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Applicant selectedApplicant = ApplicantCmb.SelectedItem as Applicant;
            var firstDiscipline = disciplineMarks.Where(dm => dm.ApplicantID == selectedApplicant.ID).Join(App.context.Discipline, dm => dm.FirstDisciplineID, d => d.ID, (dm, d) => d.Title).FirstOrDefault();
            var firstMark = disciplineMarks.Where(dm => dm.ApplicantID == selectedApplicant.ID).Select(dm => dm.FirstMark).FirstOrDefault();
            FirstDisciplineNameTbl.Text = $"({firstDiscipline}) - {firstMark}";
            var secondDiscipline = disciplineMarks.Where(dm => dm.ApplicantID == selectedApplicant.ID).Join(App.context.Discipline, dm => dm.SecondDisplineID, d => d.ID, (dm, d) => d.Title).FirstOrDefault();
            var secondMark = disciplineMarks.Where(dm => dm.ApplicantID == selectedApplicant.ID).Select(dm => dm.SecondMark).FirstOrDefault();
            SecondDisciplineNameTbl.Text = $"({secondDiscipline}) - {secondMark}";
            if (selectedApplicant.Medal == true)
            {
                MedalTbl.Text = "Есть";
            }
            else
            {
                MedalTbl.Text = "Нет";
            }
        }

        private void AcceptBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("Абитуриент принят в университет.");
        }

        private void RejectBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("Абитуриенту отказано в поступлении.");
        }
    }
}
