namespace leonardo.Resources
{
    #region Usings
    using System;
    using System.Windows.Input; 
    #endregion

    /// <summary>
    /// The simple non-generic RelayCommand.
    /// </summary>
    public class RelayCommand : RelayCommand<object>
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class. 
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">
        /// The execution logic.
        /// </param>
        public RelayCommand(Action<object> execute) : base(execute) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class. 
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">
        /// The execution logic.
        /// </param>
        public RelayCommand(Action execute) : base((o) => { execute(); }) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class. 
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">
        /// The execution logic.
        /// </param>
        /// <param name="canExecute">
        /// The execution status logic.
        /// </param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute) : base(execute, canExecute) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class. 
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">
        /// The execution logic.
        /// </param>
        /// <param name="canExecute">
        /// The execution status logic.
        /// </param>
        public RelayCommand(Action execute, Func<bool> canExecute) : base((o) => { execute(); }, (o) => { return canExecute(); }) { }
        #endregion
    }

    /// <summary>
    /// A generic version of the RelayCommand class used in Microsoft
    /// examples such as MyActivityLibrary.
    /// 
    /// Relays Execute and CanExecute to other objects using delegates.
    /// The default return value of CanExecute is 'true'.
    /// </summary>
    /// <typeparam name="T">The type of the parameter of Execute and CanExecute</typeparam>
    public class RelayCommand<T> : ICommand
    {
        #region Functions for execution and evaluation
        /// <summary>
        /// Predicate that determines if an object can execute
        /// </summary>
        private readonly Predicate<T> canExecute;

        /// <summary>
        /// The action to execute when the command is invoked
        /// </summary>
        private readonly Action<T> execute;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class. 
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">
        /// The execution logic.
        /// </param>
        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class. 
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">
        /// The execution logic.
        /// </param>
        /// <param name="canExecute">
        /// The execution status logic.
        /// </param>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }
        #endregion

        #region ICommand interface
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            this.execute((T)parameter);
        }

        public void Execute(T parameter)
        {
            this.execute(parameter);
        }
        #endregion
    }
}
