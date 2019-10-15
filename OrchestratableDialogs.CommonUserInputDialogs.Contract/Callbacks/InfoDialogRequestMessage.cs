using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.CommonUserInputDialogs.Contract.DataClasses;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.Contract.Callbacks;
using System;

namespace Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.CommonUserInputDialogs.Contract.Callbacks
{
    public class InfoDialogRequestMessage : BasePayloadableDialogRequestMessage<InfoDialogRequest, InfoDialogResult>
    {
        //properties
        public Action<InfoDialogResult, object> OnDialogClose { get; }



        //constructors
        public InfoDialogRequestMessage(string title, InfoDialogRequest request, InfoDialogResult result, object payload, Action<InfoDialogResult, object> onDialogClose) 
            : base(title, request, result, payload)
        {
            OnDialogClose = onDialogClose;
        }
    }
}
