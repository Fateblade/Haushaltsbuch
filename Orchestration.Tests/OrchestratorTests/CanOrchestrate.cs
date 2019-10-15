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
        public void CanOrchestrate_NullRequest_ThrowException()
        {
            _target
                .Invoking(t => t.CanOrchestrate(null))
                .Should()
                .Throw<OrchestrationException>("null is an invalid request");
        }

        [TestMethod]
        public void CanOrchestrate_NotRegisteredRequest_ReturnFalse()
        {
            _target
                .Invoking(t => t.CanOrchestrate(new SampleRequest()))
                .Should()
                .NotThrow()
                .Subject
                .Should()
                .BeFalse("no orchestratable exists to handle the request");
        }

        [TestMethod]
        public void CanOrchestrate_RegisteredRequestThatCannotOrchestrate_ReturnFalse()
        {
            Mock<IOrchestratable<SampleRequest>> mockOrchestrator=new Mock<IOrchestratable<SampleRequest>>();
            mockOrchestrator.Setup(t => t.CanHandleRequest(It.IsAny<BaseOrchestrationRequest>())).Returns(false);
            _target.RegisterOrchestratable(mockOrchestrator.Object);

            _target
                .Invoking(t => t.CanOrchestrate(new SampleRequest()))
                .Should()
                .NotThrow()
                .Subject
                .Should()
                .BeFalse("orchestratable that handles these requests returns false");
        }

        [TestMethod]
        public void CanOrchestrate_RegisteredRequestThatCanOrchestrate_ReturnTrue()
        {
            Mock<IOrchestratable<SampleRequest>> mockOrchestrator = new Mock<IOrchestratable<SampleRequest>>();
            mockOrchestrator.Setup(t => t.CanHandleRequest(It.IsAny<BaseOrchestrationRequest>())).Returns(true);
            _target.RegisterOrchestratable(mockOrchestrator.Object);

            _target
                .Invoking(t => t.CanOrchestrate(new SampleRequest()))
                .Should()
                .NotThrow()
                .Subject
                .Should()
                .BeTrue("orchestratable that handles these requests returns true");
        }
    }
}
