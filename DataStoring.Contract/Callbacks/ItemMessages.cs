using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.Contract.Callbacks
{
    public class AddedItemDataMessage
    {
        public Item Added { get; }

        public AddedItemDataMessage(Item added)
        {
            Added = added;
        }
    }

    public class DeletedItemDataMessage
    {
        public Item Deleted { get; }

        public DeletedItemDataMessage(Item deleted)
        {
            Deleted = deleted;
        }
    }

    public class UpdatedItemDataMessage
    {
        public Item Old { get; }
        public Item Updated { get; }

        public UpdatedItemDataMessage(Item old, Item updated)
        {
            Old = old;
            Updated = updated;
        }
    }
}
