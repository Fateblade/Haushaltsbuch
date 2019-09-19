using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.Contract.Callbacks
{
    public class AddedItemHistoryDataMessage
    {
        public ItemHistory Added { get; }

        public AddedItemHistoryDataMessage(ItemHistory added)
        {
            Added = added;
        }
    }

    public class DeletedItemHistoryDataMessage
    {
        public ItemHistory Deleted { get; }

        public DeletedItemHistoryDataMessage(ItemHistory deleted)
        {
            Deleted = deleted;
        }
    }

}
