using InspectionBoard.AppData;
using System;
using System.Windows;

namespace InspectionBoard.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AuthHelper.CheckData(Convert.ToInt32(LoginTb.Text), PasswordTb.Text) == true)
            {
                Close();
            }
        }
    }
}
