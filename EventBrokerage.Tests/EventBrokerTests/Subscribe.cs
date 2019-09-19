using CrossCutting.EventBrokerage.Contract.Exceptions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CrossCutting.EventBrokerage.Tests.EventBrokerTests
{
    //[TestClass] //muss nur in einer der partiellen klassen gesetzt werden
    public partial class EventBrokerTests
    {
        //was wird getestet _ was ist die ausgangslage _ was soll am ende sein
        //Triple-A Pattern
        //  Arrange
        //  Act
        //  Assert

        [TestMethod]
        public void Subscribe_NullASHandler_ArgumentNullException()  
        {
            _broker
                .Invoking(t => t.Subscribe<TestMessage>(null))
                .Should()
                .Throw<ArgumentException>();
        }

        [TestMethod]
        public void Subscribe_NoSubscriptionsButOneAdd_OneSubscription()
        {
            
            Action<TestMessage> handler = msg => msg.Message = "Test";

            _broker.Subscribe(handler);

            _broker
                .SubscriptionsAmount
                .Should()
                .Be(1, "one subscription was added");
        }

        [TestMethod]
        public void Subscribe_NoSubscriptionsButTwoAdds_TwoSubscription()
        {
            Action<TestMessage> handler = msg => msg.Message = "Test";
            Action<TestMessage> handler2 = msg => msg.Message = "Test";


            _broker.Subscribe(handler);
            _broker.Subscribe(handler2);

            _broker
                .SubscriptionsAmount
                .Should()
                .Be(2, "two subscriptions were added");
        }

        [TestMethod]
        public void Subscribe_TwoEqualHandlerAdded_DuplicatedHandlerException()
        {
            Action<TestMessage> handler = msg => msg.Message = "Test";
            _broker.Subscribe(handler);

            _broker
                .Invoking(t => t.Subscribe(handler))
                .Should()
                .Throw<DuplicatedHandlerException>("duplicate handlers are not allowed");
        }
    }
}
