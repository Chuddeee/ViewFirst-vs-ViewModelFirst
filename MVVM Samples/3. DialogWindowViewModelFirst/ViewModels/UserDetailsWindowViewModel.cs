using Common;
using System;
using System.Windows.Input;

namespace _3.DialogWindowViewModelFirst.ViewModels
{
    public class UserDetailsWindowViewModel : ViewModel
    {
        private User _user;
        private ICommand _closeCommand;

        public event EventHandler Closed;

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public bool IsClosed { get; private set; }

        public ICommand CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new SimpleCommand(OnClose)); }
        }

        // Делегат хранящий вызов метод Close для окна с которым ассоциирована эта ViewModel

        protected virtual void RaiseClosed()
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }

        private void OnClose(object obj)
        {
            //здесь может быть долгая асинхронная задача: валидация, сохранение итд

            IsClosed = true;
            RaiseClosed();
        }
    }
}