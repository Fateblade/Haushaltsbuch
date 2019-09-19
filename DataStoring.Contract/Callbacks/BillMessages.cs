using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.Contract.Callbacks
{
    public class AddedBillDataMessage
    {
        public Bill Added { get; }

        public AddedBillDataMessage(Bill added)
        {
            Added = added;
        }
    }

    public class DeletedBillDataMessage
    {
        public Bill Deleted { get; }

        public DeletedBillDataMessage(Bill deleted)
        {
            Deleted = deleted;
        }
    }

    public class UpdatedBillDataMessage
    {
        public Bill Old { get; }
        public Bill Updated { get; }

        public UpdatedBillDataMessage(Bill old, Bill updated)
        {
            Old = old;
            Updated = updated;
        }
    }
}
