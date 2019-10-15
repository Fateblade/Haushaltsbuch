using System;
using System.Collections.Generic;
using System.Text;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.Contract.Callbacks;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.DomainUserInputDialogs.Contract.DataClasses;

namespace Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.DomainUserInputDialogs.Contract.Callbacks
{
    public class SourceOverviewDialogRequestMessage : BasePayloadableDialogRequestMessage<SourceOverviewDialogRequest, SourceOverviewDialogResult>
    {
        public SourceOverviewDialogRequestMessage(string title, SourceOverviewDialogRequest request, SourceOverviewDialogResult result, object payload) : base(title, request, result, payload)
        {
        }
    }
}
