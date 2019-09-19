using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.Contract.Callbacks
{
    public class AddedSourceDataMessage
    {
        public Source Added { get; }

        public AddedSourceDataMessage(Source added)
        {
            Added = added;
        }
    }

    public class DeletedSourceDataMessage
    {
        public Source Deleted { get; }

        public DeletedSourceDataMessage(Source deleted)
        {
            Deleted = deleted;
        }
    }

    public class UpdatedSourceDataMessage
    {
        public Source Old { get; }
        public Source Updated { get; }

        public UpdatedSourceDataMessage(Source old, Source updated)
        {
            Old = old;
            Updated = updated;
        }
    }


}
