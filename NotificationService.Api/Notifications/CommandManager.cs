using System.Collections.Generic;
using System.Windows.Input;

namespace NotificationService.Api.Notifications
{
    public class CommandExecuter
    {
        private Stack<ICommand> _commands = new Stack<ICommand>();

        public void Invoke<TParam>(ICommand cmd, TParam param)
        {
            _commands.Push(cmd);
            cmd.Execute(param);
        }

        // public void Undo()
        // {
        //     while (_commands.Count > 0)
        //     {
        //         var command = _commands.Pop();
        //         command.Undo();
        //     }
        // }
    }
}