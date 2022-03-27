using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScreenBuilderMVVM.Commands
{

	public class Command<T> : CommandBase
	{
        private readonly Action<T> _executeMethod;
        private readonly Func<T, bool> _canExecuteMethod;

        /// <summary>
        /// Initializes a new instance of <see cref="Command{T}"/>.
        /// </summary>
        /// <param name="executeMethod">Delegate to execute when Execute is called on the command.</param>
        /// <remarks><see cref="CanExecute(T)"/> will always return true.</remarks>
        ///         /// <exception cref="ArgumentNullException">When <paramref name="executeMethod"/> is <see langword="null" />.</exception>

        public Command(Action<T> executeMethod)
            : this(executeMethod, (o) => true)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Command{T}"/>.
        /// </summary>
        /// <param name="executeMethod">Delegate to execute when Execute is called on the command.</param>
        /// <param name="canExecuteMethod">Delegate to execute when CanExecute is called on the command. </param>
        /// <exception cref="ArgumentNullException">When <paramref name="executeMethod"/> or <paramref name="canExecuteMethod"/> is <see langword="null" />.</exception>
        public Command(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            if (executeMethod == null || canExecuteMethod == null)
                throw new ArgumentException("Command delegates cannot be null");

            var genericTypeInfo = typeof(T).GetTypeInfo();

            // Command allows object or Nullable<>.  
            // note: Nullable<> is a struct so we cannot use a class constraint.
            if (genericTypeInfo.IsValueType)
            {
                if ((!genericTypeInfo.IsGenericType) || (!typeof(Nullable<>).GetTypeInfo().IsAssignableFrom(genericTypeInfo.GetGenericTypeDefinition().GetTypeInfo())))
                {
                    throw new InvalidCastException("Invalid generic type parameter");
                }
            }

            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        ///<summary>
        ///Executes the command and invokes the <see cref="Action{T}"/> provided during construction.
        ///</summary>
        ///<param name="parameter">Data used by the command.</param>
        public void Execute(T parameter)
        {
            _executeMethod(parameter);
        }

        ///<summary>
        ///Determines if the command can execute by invoked the <see cref="Func{T,Bool}"/> provided during construction.
        ///</summary>
        ///<param name="parameter">Data used by the command to determine if it can execute.</param>
        ///<returns>
        ///<see langword="true" /> if this command can be executed; otherwise, <see langword="false" />.
        ///</returns>
        public bool CanExecute(T parameter)
        {
            var canExecute = _canExecuteMethod(parameter);

            return canExecute;
        }

        /// <summary>
        /// Handle the internal invocation of <see cref="ICommand.Execute(object)"/>
        /// </summary>
        /// <param name="parameter">Command Parameter</param>
        protected override void Execute(object parameter)
        {
            Execute((T)parameter);
        }

        /// <summary>
        /// Handle the internal invocation of <see cref="ICommand.CanExecute(object)"/>
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns><see langword="true"/> if the Command Can Execute, otherwise <see langword="false" /></returns>
        protected override bool CanExecute(object parameter)
        {
            return CanExecute((T)parameter);
        }
    }
}
