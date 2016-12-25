using _2.MasterDetailViewModelFirst.ViewModels;
using Common;
using System.ComponentModel;

namespace _2.MasterDetailViewModelFirst
{
    public class MainWindowViewModel : ViewModel
    {
        public UserDetailsViewModel UserDetailsViewModel { get; private set; }
        public UserListViewModel UserListViewModel { get; private set; }

        // Инициализируем VM
        public void Initialize()
        {
            UserListViewModel = new UserListViewModel();
            UserDetailsViewModel = new UserDetailsViewModel();

            // Подписываемся на отслеживание события изменения свойства в VM
            UserListViewModel.PropertyChanged += UserListViewModelOnPropertyChanged;
        }

        private void UserListViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == nameof(UserListViewModel.SelectedUser))
            {
                // При изменении свойства SelectedUser происходит переназначение User в UserDetailsViewModel
                UserDetailsViewModel.User = UserListViewModel.SelectedUser;
            }
        }
    }
}