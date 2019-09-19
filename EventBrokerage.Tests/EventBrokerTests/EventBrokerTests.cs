using System;
using CrossCutting.EventBrokerage.Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrossCutting.EventBrokerage.Tests.EventBrokerTests
{
    [TestClass]
    public partial class EventBrokerTests
    {
        private EventBroker _broker;

        [TestInitialize]
        public void TestInitialize()
        {
            _broker = new EventBroker();
        }
    }
}
