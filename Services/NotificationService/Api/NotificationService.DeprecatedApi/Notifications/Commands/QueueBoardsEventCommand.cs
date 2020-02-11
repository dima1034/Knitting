using System;
using System.Windows.Input;

namespace NotificationService.DeprecatedApi.Notifications.Commands
{
    public class QueueBoardsEventCommand : ICommand
    {
        public bool CanExecute(object parameter) => throw new NotImplementedException();

        public void Execute(object parameter) => throw new NotImplementedException();

        public event EventHandler CanExecuteChanged;
    }
}