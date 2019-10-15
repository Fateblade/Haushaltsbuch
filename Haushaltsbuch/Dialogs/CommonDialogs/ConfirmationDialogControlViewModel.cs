using System;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.CommonUserInputDialogs.Contract.DataClasses;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Fateblade.Haushaltsbuch.UI.Haushaltsbuch.Dialogs.CommonDialogs
{
    public class ConfirmationDialogControlViewModel : BindableBase, IDialogAware
    {
        //members
        private string _abortButtonText;
        private string _confirmButtonText;
        private string _displayText;



        //events
        public event Action<IDialogResult> RequestClose;



        //properties
        public string Title { get; set; }
        public string AbortButtonText
        {
            get => _abortButtonText;
            set => SetProperty(ref _abortButtonText, value);
        }
        public string ConfirmButtonText
        {
            get => _confirmButtonText;
            set => SetProperty(ref _confirmButtonText, value);
        }
        public string DisplayText
        {
            get => _displayText;
            set => SetProperty(ref _displayText, value);
        }

        //properties - commands
        public DelegateCommand ConfirmButtonCommand { get; }
        public DelegateCommand AbortButtonCommand { get; }



        //constructors
        public ConfirmationDialogControlViewModel()
        {
            ConfirmButtonCommand = new DelegateCommand(() => { setResultAndCloseDialog(true); });
            AbortButtonCommand = new DelegateCommand(() => { setResultAndCloseDialog(false); });
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
            var request = parameters.GetValue<ConfirmationDialogRequest>("Request");

            DisplayText = request.DisplayText;
            ConfirmButtonText = request.ConfirmButtonText;
            AbortButtonText = request.AbortButtonText;
        }



        //private methods
        private void setResultAndCloseDialog(bool result)
        {
            RequestClose?.Invoke(
                new DialogResult(
                    result ? ButtonResult.Yes
                           : ButtonResult.No,
                    new DialogParameters()
                    )
                );
        }
    }

}
