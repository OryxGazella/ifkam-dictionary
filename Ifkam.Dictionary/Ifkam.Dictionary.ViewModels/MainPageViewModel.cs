using System;
using System.ComponentModel;
using System.Windows.Input;
using Ifkam.Services.Contracts;
using Ifkam.Services.Contracts.Implementations;

namespace Ifkam.Dictionary.ViewModels
{
    public sealed class MainPageViewModel : INotifyPropertyChanged
    {
        
       

        public MainPageViewModel()
        {
            Lookup = new DelegateCommand(async ()=> Definition = await Service.Lookup(Word));
        }
        private string _word;
        private string _definition;
        internal ILookupService Service = new RailsLookupService();

        public string Word
        {
            get { return _word; }
            set { _word = value; }
        }

        public string Definition
        {
            get { return _definition; }
            set { _definition = value; 
                OnPropertyChanged("Definition");
            }
        }

        public ICommand Lookup { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
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
