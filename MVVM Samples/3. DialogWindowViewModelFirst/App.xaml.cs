﻿using _3.Common.ViewTypeResolver;
using _3.DialogWindowViewModelFirst.ViewModels;
using _3.DialogWindowViewModelFirst.Views;
using Common;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _3.DialogWindowViewModelFirst
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private UnityContainer _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            /*
             * В этом примере все идентично прошлым, ключевое на что необходимо обратить внимание:
             *      * метод OnShowDetails расположенном в UserListViewModel - порождение дочернего окна
             *      * UserDetailsWindow CodeBehind и UserDetailsWindowViewModel - обработка закрытия окна
             */
            base.OnStartup(e);

            _container = new UnityContainer();
            var locator = new UnityServiceLocator(_container);
            ServiceLocator.SetLocatorProvider(() => locator);

            _container.RegisterType<UserProvider>(new ContainerControlledLifetimeManager());
            //_container.RegisterType<IViewTypeResolver, NamingConventionViewTypeResolver>(new ContainerControlledLifetimeManager());

            _container.RegisterType<UserDetailsViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<UserListViewModel>(new ContainerControlledLifetimeManager());

            var mappingResolver = new MappingViewTypeResolver();
            mappingResolver.RegisterTypeMapping<UserDetailsView, UserDetailsViewModel>();
            mappingResolver.RegisterTypeMapping<UserListView, UserListViewModel>();
            _container.RegisterInstance<IViewTypeResolver>(mappingResolver);
            var mainVM = _container.Resolve<MainWindowViewModel>();
            mainVM.Initialize();

            var mainWindow = new MainWindow();
            mainWindow.DataContext = mainVM;
            mainWindow.Show();
        }
    }
}