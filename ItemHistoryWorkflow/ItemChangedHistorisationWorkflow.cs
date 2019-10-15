using System;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract.Callbacks;
using Fateblade.Haushaltsbuch.Logic.Domain.ItemHistoryManagement.Contract;

namespace Fateblade.Haushaltsbuch.Logic.Business.ItemHistoryWorkflow
{
    // ToDo: maybe move message infos out of DataStoring into the different Management Contracts?

    class ItemChangedHistorisationWorkflow
    {
        private readonly IItemHistoryManager _ItemHistoryManager;

        public ItemChangedHistorisationWorkflow(IItemHistoryManager itemHistoryManager)
        {
            _ItemHistoryManager = itemHistoryManager;
        }

        public void HistorizeChange(UpdatedItemDataMessage itemUpdateInfo)
        {
            var historyItem = new ItemHistory();
            historyItem.DateOfChange = DateTime.Now;
            historyItem.ItemId = itemUpdateInfo.Old.Id;
            historyItem.Name = itemUpdateInfo.Old.Name;
            historyItem.Note = itemUpdateInfo.Old.Note;
            historyItem.PricePerUnit = itemUpdateInfo.Old.PricePerUnit;

            _ItemHistoryManager.Add(historyItem);
        }
    }
}
