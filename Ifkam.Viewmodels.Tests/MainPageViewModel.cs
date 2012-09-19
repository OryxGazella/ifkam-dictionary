using System.Windows.Input;

namespace Ifkam.Viewmodels.Tests
{
    class MainPageViewModel
    {
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

        public ICommand Lookup
        {
            get { return null; }
        }
    }
}
