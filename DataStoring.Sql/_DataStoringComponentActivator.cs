using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Bootstrapping;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Configuration;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.SqLite
{
    public class DataStoringComponentActivator : IComponentActivator
    {
        public void Activating()
        {
            
        }

        public void Activated()
        {
        }

        public void Deactivating()
        {
        }

        public void Deactivated()
        {
        }

        public void RegisterMappings(ICoCoKernel kernel)
        { 
            kernel.Register<IEntryRepository, EntrySqLiteRepository>();
            kernel.Register<ISourceRepository, SourceSqLiteRepository>();
            kernel.Register<IItemRepository, ItemSqLiteRepository>();
            kernel.Register<IBillRepository, BillSqLiteRepository>();
        }

        public void AddMessageSubscriptions(IEventBroker broker)
        {
           
        }

        public void Configure(IConfigurator config)
        {
            // Todo: connection string für sqlíte auf memory nachschauen und als default hinterlegen
            config.Get("DataStoring", "SqLiteConnectionString", string.Empty);
        }
    }
}
