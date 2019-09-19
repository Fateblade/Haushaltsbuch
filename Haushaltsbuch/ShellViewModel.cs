using Prism.Mvvm;

namespace UI.Haushaltsbuch
{
    public class ShellViewModel  : BindableBase
    {

        private string _HelloWorldString;
        public string HelloWorldString
        {
            get => _HelloWorldString;
            set => SetProperty(ref _HelloWorldString, value);
        }

        public ShellViewModel()
        {
            HelloWorldString = "Hello dotNet Core 3.0 World in Prism";
        }
    }
}

