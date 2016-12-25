using _2._2_MasterDetailViewModelFirstViewModelPresenter.ViewModelPresenter;
using _2._2_MasterDetailViewModelFirstViewModelPresenter.ViewModels;
using _2._2_MasterDetailViewModelFirstViewModelPresenter.Views;
using Common;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System.Windows;

namespace _2._2_MasterDetailViewModelFirstViewModelPresenter
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
            var locator = new UnityServiceLocator(_container); // создаем сервис локатор из Unity контэйнера
            ServiceLocator.SetLocatorProvider(() => locator); // присваиваем Unity локатор существующему статическому сервис локатору из сборки Microsoft.Practices.ServiceLocation

            _container.RegisterType<UserProvider>(new ContainerControlledLifetimeManager());
            //_container.RegisterType<IViewTypeResolver, NamingConventionViewTypeResolver>(new ContainerControlledLifetimeManager());

            _container.RegisterType<UserDetailsViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<UserListViewModel>(new ContainerControlledLifetimeManager());

            var mappingResolver = new MappingViewTypeResolver(); // создаем мапинг сервис и производим мапинг между View и VM
            mappingResolver.Register<UserDetailsView, UserDetailsViewModel>();
            mappingResolver.Register<UserListView, UserListViewModel>();
            _container.RegisterInstance<IViewTypeResolver>(mappingResolver); // добавляем сервис в контэйнер

            var mainVM = _container.Resolve<MainWindowViewModel>();
            mainVM.Initialize();

            var mainWindow = new MainWindow();
            mainWindow.DataContext = mainVM;
            mainWindow.Show();
        }
    }
}