using _2._1_MasterDetailViewModelFirstUnityReactiveUI.ViewModels;
using Common;
using Microsoft.Practices.Unity;
using ReactiveUI;
using System;
using System.ComponentModel;

namespace _2._1_MasterDetailViewModelFirstUnityReactiveUI
{
    public class MainWindowViewModel : ViewModel
    {
        // помеченные атрибутом [Dependency] свойства автоматически инжектятся при ресолве из контэйнера
        [Dependency]
        public UserDetailsViewModel UserDetailsViewModel { get; set; }

        [Dependency]
        public UserListViewModel UserListViewModel { get; set; }

        public void Initialize()
        {
            UserListViewModel // используя ReactiveUI
                .ObservableForProperty(vm => vm.SelectedUser) //подписываемся на отслеживание изменения свойства SelectedUser в UserListViewModel
                .Subscribe(change => UserDetailsViewModel.User = change.Value); // при изменении свойства SelectedUser оно присваивается свойству User в UserDetailsViewModel
        }
    }
}