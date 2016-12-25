using _2.MasterDetailViewModelFirst.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _2.MasterDetailViewModelFirst
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainVM = new MainWindowViewModel(); // 1. Создаем ViewModel
            mainVM.Initialize(); // 2. Инициализируем ViewModel

            var mainWindow = new MainWindow(); // 3. Создаем View
            mainWindow.DataContext = mainVM; // 4. Назначаем ViewModel в качества DataContext'a для View
            mainWindow.Show(); // 5. Отображаем View
        }
    }
}