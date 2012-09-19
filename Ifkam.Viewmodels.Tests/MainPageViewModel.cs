using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Ifkam.Viewmodels.Tests
{
    class MainPageViewModel
    {
        internal interface ILookupService
        {
            string Lookup(string word);
        }

        private class LocalLookupService : ILookupService
        {
            private Dictionary<string, string> _dictionary = new Dictionary<string, string>
                                                                 {
                                                                    {"word1", "nice word"},
                                                                    {"word2", "another word"}
                                                                 };
            public string Lookup(string word)
            {
                if(_dictionary.ContainsKey(word))
                {
                    return _dictionary[word];
                }
                return "this word you speak of I have not found";
            }
        }

        public MainPageViewModel()
        {
            Lookup = new DelegateCommand(()=> Definition = _service.Lookup(Word));
        }
        private string _word;
        private string _definition;
        private readonly ILookupService _service = new LocalLookupService();

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
