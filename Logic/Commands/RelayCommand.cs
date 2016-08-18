using System;
using System.Windows.Input;

namespace Logic.Commands
{
	public class RelayCommand<T> : ICommand
	{
		#region Variables

		private readonly Action<T> _execute;
		private readonly Predicate<T> _canExecute;

		#endregion

		#region Constructors

		public RelayCommand(Action<T> execute)
			: this(execute, null)
		{
		}

		public RelayCommand(Action<T> execute, Predicate<T> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("execute");

			_execute = execute;
			_canExecute = canExecute;
		}

		#endregion

		#region ICommand Members

		public bool CanExecute(object parameter = null)
		{
			return _canExecute == null || _canExecute((T)parameter);
		}

		public void Execute(object parameter = null)
		{
			_execute((T)parameter);
		}

		public event EventHandler CanExecuteChanged;

		#endregion
	}
}
