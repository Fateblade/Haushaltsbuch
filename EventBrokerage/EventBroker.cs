using CrossCutting.EventBrokerage.Contract;
using CrossCutting.EventBrokerage.Contract.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossCutting.EventBrokerage
{
    public class EventBroker : IEventBroker
    {
        //members
        private readonly Dictionary<Type, List<Delegate>> _subscriptions;

        

        //properties
        public int SubscriptionsAmount => _subscriptions.SelectMany(s => s.Value).Count();



        //constructors
        public EventBroker()
        {
            _subscriptions = new Dictionary<Type, List<Delegate>>();
        }



        //public methods
        public void Subscribe<TMessage>(Action<TMessage> handler)
        {
            if (handler == null) { throw new ArgumentNullException(nameof(handler)); }

            var messageType = typeof(TMessage);

            var messageAlreadyHasSubscribers = _subscriptions.ContainsKey(messageType);
            if (!messageAlreadyHasSubscribers)
            {
                _subscriptions.Add(messageType, new List<Delegate>());
            }

            var handlerIsAlreadyRegistered = _subscriptions[messageType].Contains(handler);
            if (handlerIsAlreadyRegistered)
            {
                throw new DuplicatedHandlerException("Handler is already registered");
            }

            _subscriptions[messageType].Add(handler);
        }

        public void Raise(object message)
        {
            if(message == null)
            {
                throw new ArgumentNullException();
            }

            var messageType = message.GetType();
            var hasHandler = _subscriptions.ContainsKey(messageType);
            if (!hasHandler)
            {
                return;
            }

            var handlers = _subscriptions[messageType];
            foreach(var handler in handlers)
            {
                try
                {
                    handler.DynamicInvoke(message);
                }
                catch(Exception e)
                {
                    // Todo: Logging on exception
                }
            }
        }
    }
}
