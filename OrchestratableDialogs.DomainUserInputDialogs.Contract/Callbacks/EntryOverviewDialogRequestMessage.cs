using System;
using System.Collections.Generic;
using System.Text;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.Contract.Callbacks;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.DomainUserInputDialogs.Contract.DataClasses;

namespace Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.DomainUserInputDialogs.Contract.Callbacks
{
    public class EntryOverviewDialogRequestMessage : BasePayloadableDialogRequestMessage<EntryOverviewDialogRequest, EntryOverviewDialogResult>
    {
        public EntryOverviewDialogRequestMessage(string title, EntryOverviewDialogRequest request, EntryOverviewDialogResult result, object payload) : base(title, request, result, payload)
        {
        }
    }
}
