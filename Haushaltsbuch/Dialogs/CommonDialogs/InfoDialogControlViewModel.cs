using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.CommonUserInputDialogs.Contract.DataClasses;
using Prism.Commands;

namespace Fateblade.Haushaltsbuch.UI.Haushaltsbuch.Dialogs.CommonDialogs
{
    public class InfoDialogControlViewModel : BindableBase, IDialogAware
    {
        //members
        private string _infoText;



        //events
        public event Action<IDialogResult> RequestClose;



        //properties
        public string Title { get; set; }
        public string InfoText
        {
            get => _infoText;
            set => SetProperty(ref _infoText, value);
        }

        //properties - commands
        public DelegateCommand CloseButtonCommand { get; }



        //constructors
        public InfoDialogControlViewModel()
        {
            CloseButtonCommand = new DelegateCommand(closeDialog);
        }



        //public methods
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (!parameters.ContainsKey("Title"))
            {
                throw new ArgumentException(
                    "Parameter 'Title' is missing in given parameters. Cannot create useful confirmation dialog without it");
            }

            if (!parameters.ContainsKey("Request"))
            {
                throw new ArgumentException(
                    "Parameter 'Request' is missing in given parameters. Cannot create useful confirmation dialog without it");
            }

            Title = parameters.GetValue<string>("Title");
            var request = parameters.GetValue<InfoDialogRequest>("Request");

            InfoText = request.Info;
        }



        //private methods
        private void closeDialog()
        {
            RequestClose?.Invoke(
                new DialogResult(
                    ButtonResult.OK,
                    new DialogParameters()
                    )
                );
        }
    }
}
