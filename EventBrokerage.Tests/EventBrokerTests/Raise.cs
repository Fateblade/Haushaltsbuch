using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CrossCutting.EventBrokerage.Tests.EventBrokerTests
{
    public partial class EventBrokerTests
    {
        [TestMethod]
        public void Raise_MessageIsNull_ArgumentNullException()
        {
            _broker
                .Invoking(t => t.Raise(null))
                .Should()
                .Throw<ArgumentNullException>("null as a message is not allowed");
        }

        [TestMethod]
        public void Raise_MessageHasSubscriber_SubscriberWasNotified()
        {
            var wasCalled = false;
            Action<TestMessage> handler = msg => wasCalled = true;
            _broker.Subscribe(handler);

            _broker.Raise(new TestMessage());

            wasCalled
                .Should()
                .BeTrue("handler was called");
           
        }

        [TestMethod]
        public void Raise_MessageHasTwoSubscriber_SubscriberWasNotified()
        {
            var wasCalled1 = false;
            var wasCalled2 = false;
            Action<TestMessage> handler1 = msg => wasCalled1 = true;
            Action<TestMessage> handler2 = msg => wasCalled2 = true;
            _broker.Subscribe(handler1);
            _broker.Subscribe(handler2);

            _broker.Raise(new TestMessage());

            wasCalled1
                .Should()
                .BeTrue("handler was subscribed for TestMessage");

            wasCalled2
                .Should()
                .BeTrue("handler was subscribed for TestMessage");

        }

        // Todo: TC Logging bei Exception

        [TestMethod]
        public void Raise_SubscriberRaisesException_SubscriberWasCalled()
        {
            Action<TestMessage> handler = msg => throw new Exception();
            _broker.Subscribe(handler);


            _broker.Raise(new TestMessage());
        }

        [TestMethod]
        public void Raise_FirstSubscriberRaisesException_ContinueToSecondSubscriber()
        {
            Action<TestMessage> handler1 = msg => throw new Exception();
            var wasCalled = false;
            Action<TestMessage> handler2 = msg => wasCalled = true;
            _broker.Subscribe(handler1);
            _broker.Subscribe(handler2);

            _broker.Raise(new TestMessage());

            wasCalled.Should().BeTrue("the raised message was subscribed for that handler");
        }

        [TestMethod]
        public void Raise_MessageHasNoSubscriber_NoError()
        {
            _broker.Raise(new TestMessage());

            _broker
                .Invoking(t => t.Raise(new TestMessage()))
                .Should()
                .NotThrow<Exception>();
                
        }

        // Todo: TC Reihenfolge testen
    }
}
