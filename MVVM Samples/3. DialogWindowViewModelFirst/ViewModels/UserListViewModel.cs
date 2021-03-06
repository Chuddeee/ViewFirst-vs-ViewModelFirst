﻿using _3.DialogWindowViewModelFirst.Views;
using Common;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Windows.Input;

namespace _3.DialogWindowViewModelFirst.ViewModels
{
    public class UserListViewModel : ViewModel
    {
        private IEnumerable<User> _users;
        private User _selectedUser;
        private ICommand _showDetailsCommand;

        [Dependency]
        public UserProvider UserProvider { private get; set; }

        public IEnumerable<User> Users
        {
            get { return _users ?? (_users = UserProvider.GetUsers()); }
        }

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowDetailsCommand
        {
            get { return _showDetailsCommand ?? (_showDetailsCommand = new SimpleCommand(OnShowDetails)); }
        }

        private void OnShowDetails(object obj)
        {
            var editWindow = new UserDetailsWindow();

            var editViewModel = new UserDetailsWindowViewModel();
            editViewModel.User = (User)obj;
            editViewModel.Closed += (sender, args) => editWindow.Close(); // В модель представления дочернего окна передается лямбда выражение описывающее закрытие этого же дочернего окна

            editWindow.DataContext = editViewModel;
            editWindow.Show();
        }
    }
}