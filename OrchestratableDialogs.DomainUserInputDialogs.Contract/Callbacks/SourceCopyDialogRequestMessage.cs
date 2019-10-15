using System;
using System.Collections.Generic;
using System.Text;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.Contract.Callbacks;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.DomainUserInputDialogs.Contract.DataClasses;

namespace Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.DomainUserInputDialogs.Contract.Callbacks
{
    public class SourceCopyDialogRequestMessage : BasePayloadableDialogRequestMessage<SourceCopyDialogRequest, SourceCopyDialogResult>
    {
        public SourceCopyDialogRequestMessage(string title, SourceCopyDialogRequest request, SourceCopyDialogResult result, object payload) : base(title, request, result, payload)
        {
        }
    }
}
