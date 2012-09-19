using System;
using System.Windows.Input;

namespace Ifkam.Viewmodels.Tests
{
    class MainPageViewModel
    {
        public MainPageViewModel()
        {
            Lookup = new DelegateCommand(()=> Definition = "You've casued a lookup!");
        }
        private string _word;
        private string _definition;

        public string Word
        {
            get { return _word; }
            set { _word = value; }
        }

        public string Definition
        {
            get { return _definition; }
            set { _definition = value; }
        }

        public ICommand Lookup { get; private set; }
    }


    public class DelegateCommand : ICommand
    {
        private readonly Action _action;

        public DelegateCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged;
    }

    
}
