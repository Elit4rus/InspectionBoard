using InspectionBoard.Model;
using System.Linq;
using System.Windows;

namespace InspectionBoard.AppData
{
    public class AuthHelper
    {
        public static Secretary currentSecretary;
        public static bool CheckData(int idNumber, string password)
        {
            currentSecretary = App.context.Secretary.FirstOrDefault(d => d.IdNumber == idNumber && d.Password == password);
            if (currentSecretary != null)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                return true;
            }
            else
            {
                MessageBox.Show("Пользователь не найден!");
                return false;
            }
        }
    }
}
