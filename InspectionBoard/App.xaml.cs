using InspectionBoard.Model;
using System.Windows;

namespace InspectionBoard
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static InspectionBoardEntities context = new InspectionBoardEntities();
    }
}
