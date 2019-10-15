using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.CommonUserInputDialogs.Contract.DataClasses;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.Contract.Callbacks;
using System;

namespace Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.CommonUserInputDialogs.Contract.Callbacks
{
    public class ConfirmationDialogRequestMessage : BasePayloadableDialogRequestMessage<ConfirmationDialogRequest, ConfirmationDialogResult>
    {
        //properties
        public Action<ConfirmationDialogResult, object> OnUserConfirmed { get; }
        public Action<object> OnUserAbort { get; }



        //constructors
        public ConfirmationDialogRequestMessage(string title, ConfirmationDialogRequest request, ConfirmationDialogResult result, object payload, Action<ConfirmationDialogResult, object> onUserConfirmed, Action<object> onUserAbort) 
            : base(title, request, result, payload)
        {
            OnUserConfirmed = onUserConfirmed;
            OnUserAbort = onUserAbort;
        }
    }
}
