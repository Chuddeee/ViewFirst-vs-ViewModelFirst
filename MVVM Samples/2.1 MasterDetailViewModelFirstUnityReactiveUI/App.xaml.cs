using Common;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _2._1_MasterDetailViewModelFirstUnityReactiveUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private UnityContainer _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _container = new UnityContainer();

            _container.RegisterType<UserProvider>(new ContainerControlledLifetimeManager()); // Регистрируем UserProvider как синглтон
            var mainVM = _container.Resolve<MainWindowViewModel>(); // инстанцируем MainWindowVM через контэйнер c помощью конструктора по умолчанию
            mainVM.Initialize();// инициализиуем ее

            var mainWindow = _container.Resolve<MainWindow>(); // инстанцируем через контэйнер MainWindow
            mainWindow.DataContext = mainVM;// присваиваем ему DataContext
            mainWindow.Show(); // отображаем
        }
    }
}