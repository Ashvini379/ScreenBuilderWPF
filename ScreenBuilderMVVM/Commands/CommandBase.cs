using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScreenBuilderMVVM.Commands
{
    public abstract class CommandBase : ICommand
    {

        void ICommand.Execute(object parameter)
        {
            Execute(parameter);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute(parameter);
        }

        /// <summary>
        /// Handle the internal invocation of <see cref="ICommand.Execute(object)"/>
        /// </summary>
        /// <param name="parameter">Command Parameter</param>
        protected abstract void Execute(object parameter);

        /// <summary>
        /// Handle the internal invocation of <see cref="ICommand.CanExecute(object)"/>
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns><see langword="true"/> if the Command Can Execute, otherwise <see langword="false" /></returns>
        protected abstract bool CanExecute(object parameter);

        /// <summary>
        /// The can execute changed.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Raise can execute changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
