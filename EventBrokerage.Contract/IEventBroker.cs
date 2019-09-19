using System;

namespace CrossCutting.EventBrokerage.Contract
{
    public interface IEventBroker
    {
        void Subscribe<TMessage>(Action<TMessage> handler);
    }
}
