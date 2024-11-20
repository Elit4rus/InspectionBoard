using InspectionBoard.AppData;
using InspectionBoard.View.Windows;
using System.Windows;

namespace InspectionBoard
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameHelper.mainFrame = MainFrame;
            FullNameTbl.Text = AuthHelper.currentSecretary.FullName;
        }

        private void ApplicantBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new View.Pages.ApplicantPage());
        }

        private void ExaminationSheet_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new View.Pages.ExamSheetPage());
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Close();
        }
    }
}
