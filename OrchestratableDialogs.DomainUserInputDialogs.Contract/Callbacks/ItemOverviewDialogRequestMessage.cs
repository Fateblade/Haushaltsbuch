using System;
using System.Collections.Generic;
using System.Text;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.Contract.Callbacks;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.DomainUserInputDialogs.Contract.DataClasses;

namespace Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.DomainUserInputDialogs.Contract.Callbacks
{
    public class ItemOverviewDialogRequestMessage : BasePayloadableDialogRequestMessage<ItemOverviewDialogRequest, ItemOverviewDialogResult>
    {
        public ItemOverviewDialogRequestMessage(string title, ItemOverviewDialogRequest request, ItemOverviewDialogResult result, object payload) : base(title, request, result, payload)
        {
        }
    }
}
