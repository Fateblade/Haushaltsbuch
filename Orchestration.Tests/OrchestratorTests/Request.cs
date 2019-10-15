using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract;
using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract.DataClasses;
using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract.Exceptions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Orchestration.Tests.OrchestratorTests
{
    public partial class OrchestratorTests
    {
        [TestMethod]
        public void Request_NullRequest_ThrowException()
        {
            _target
                .Invoking(t => t.Request(null))
                .Should()
                .Throw<OrchestrationException>("null is an invalid request");
        }

        [TestMethod]
        public void Request_NotRegisteredRequest_ThrowException()
        {
            _target
                .Invoking(t => t.Request(new SampleRequest()))
                .Should()
                .Throw<OrchestrationException>("request was not registered");
        }

        [TestMethod]
        public void Request_RegisteredRequest_ExecuteRequest()
        {
            var result = false;
            Mock<IOrchestratable<SampleRequest>> mockOrchestrator = new Mock<IOrchestratable<SampleRequest>>();
            mockOrchestrator
                .Setup(t => t.HandleRequest(It.IsAny<BaseOrchestrationRequest>()))
                .Callback(() => { result = true; });
            _target.RegisterOrchestratable(mockOrchestrator.Object);

            _target
                .Invoking(t => t.Request(new SampleRequest()))
                .Should()
                .NotThrow("orchestratable was registered for the request");

            result
                .Should()
                .BeTrue("Orchestratable was called");
        }
    }
}
