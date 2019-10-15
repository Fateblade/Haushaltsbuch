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
        public void RegisterOrchestratableIOrchestratable_NoneRegistered_Registered()
        {
            Mock<IOrchestratable<BaseOrchestrationRequest>> orchestratableMock = new Mock<IOrchestratable<BaseOrchestrationRequest>>();
            
            _target
                .Invoking(t=>t.RegisterOrchestratable(orchestratableMock.Object))
                .Should()
                .NotThrow();
        }

        [TestMethod]
        public void RegisterOrchestratableIOrchestratable_AlreadyRegistered_NoException()
        {
            Mock<IOrchestratable<BaseOrchestrationRequest>> orchestratableMock = new Mock<IOrchestratable<BaseOrchestrationRequest>>();
            _target.RegisterOrchestratable(orchestratableMock.Object);

            _target
                .Invoking(t => t.RegisterOrchestratable(orchestratableMock.Object))
                .Should()
                .NotThrow<OrchestrationException>("Registration for BaseOrchestrationRequest is overwritten");
        }

        [TestMethod]
        public void RegisterOrchestratableIOrchestratable_NullRegistering_ThrowException()
        {
            _target
                .Invoking(t => t.RegisterOrchestratable(null))
                .Should()
                .Throw<OrchestrationException>("null is not a valid orchestratable");
        }
    }
}
