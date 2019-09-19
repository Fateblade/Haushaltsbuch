using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.Contract.Callbacks
{
    public class AddedEntryDataMessage
    {
        public Entry Added { get; }

        public AddedEntryDataMessage(Entry added)
        {
            Added = added;
        }
    }

    public class DeletedEntryDataMessage
    {
        public Entry Deleted { get; }

        public DeletedEntryDataMessage(Entry deleted)
        {
            Deleted = deleted;
        }
    }

    public class UpdatedEntryDataMessage
    {
        public Entry Old { get; }
        public Entry Updated { get; }

        public UpdatedEntryDataMessage(Entry old, Entry updated)
        {
            Old = old;
            Updated = updated;
        }
    }
}
