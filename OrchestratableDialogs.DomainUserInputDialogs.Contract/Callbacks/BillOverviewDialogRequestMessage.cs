using System;
using System.Collections.Generic;
using System.Text;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.Contract.Callbacks;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.DomainUserInputDialogs.Contract.DataClasses;

namespace Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.DomainUserInputDialogs.Contract.Callbacks
{
    public class BillOverviewDialogRequestMessage : BasePayloadableDialogRequestMessage<BillOverviewDialogRequest, BillOverviewDialogResult>
    {
        public BillOverviewDialogRequestMessage(string title, BillOverviewDialogRequest request, BillOverviewDialogResult result, object payload) : base(title, request, result, payload)
        {
        }
    }
}
