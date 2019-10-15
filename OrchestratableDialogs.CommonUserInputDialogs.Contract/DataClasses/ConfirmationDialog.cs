using System;
using System.Collections.Generic;
using System.Text;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.Contract;

namespace Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.CommonUserInputDialogs.Contract.DataClasses
{
    public class ConfirmationDialogRequest : IDialogRequest
    {
        public string DisplayText { get; set; }
        public string ConfirmButtonText { get; set; } = "Confirm";
        public string AbortButtonText { get; set; } = "Abort";
    }

    public class ConfirmationDialogResult : IDialogResult
    {
        public bool UserConfirmed { get; set; }
    }
}
