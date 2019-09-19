using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Microsoft.EntityFrameworkCore;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.SqLite
{
    public abstract class SqLiteBaseRepository : DbContext
    {
        //properties
        protected ISqlLiteConnectionProvider ConnectionProvider { get; }
        protected IEventBroker EventBroker { get; }
        protected bool IsEventBrokerAttached => EventBroker != null;



        //constructors
        protected SqLiteBaseRepository(ISqlLiteConnectionProvider connectionProvider, IEventBroker eventBroker) : this(connectionProvider)
        {
            EventBroker = eventBroker;
        }
        protected SqLiteBaseRepository(ISqlLiteConnectionProvider connectionProvider)
        {
            ConnectionProvider = connectionProvider;
        }
        protected SqLiteBaseRepository()
        {
            ConnectionProvider = new InMemoryConnectionProvider();
        }



        //protected methods
        protected void RaiseMessageIfEventBrokerIsAttached(object message)
        {
            if (IsEventBrokerAttached)
            {
                EventBroker.Raise(message);
            }
        }
    }
}
