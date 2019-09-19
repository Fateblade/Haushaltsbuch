using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Bootstrapping;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Configuration;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract.Callbacks;

namespace ItemHistoryWorkflow
{
    public class ItemHistoryWorkflowComponentActivator : IComponentActivator
    {
        public void Activated()
        {
        }

        public void Activating()
        {
        }

        public void AddMessageSubscriptions(IEventBroker broker)
        {
            broker.Subscribe<ItemChangedHistorisationWorkflow, UpdatedItemDataMessage>((handler, updateInfo) => { handler.HistorizeChange(updateInfo); });
        }

        public void Configure(IConfigurator config)
        {
        }

        public void Deactivated()
        {
        }

        public void Deactivating()
        {
        }

        public void RegisterMappings(ICoCoKernel kernel)
        {
        }
    }
}
