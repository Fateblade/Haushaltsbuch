using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.Contract;

namespace Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.DomainUserInputDialogs.Contract.DataClasses
{
    public class BillEditDialogRequest : IDialogRequest
    {
        public Bill BillToEdit { get; set; }
    }

    public class BillEditDialogResult : IDialogResult
    {
        public Bill SavedBill { get; set; }
    }
}
