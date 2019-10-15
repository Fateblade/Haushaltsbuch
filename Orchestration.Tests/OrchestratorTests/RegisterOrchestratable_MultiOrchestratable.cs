using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void RegisterOrchestratableIMultiOrchestratable_NoneRegistered_Registered()
        {
            Mock<IMultiOrchestratable> multiOrchestratableMock = new Mock<IMultiOrchestratable>();
            multiOrchestratableMock
                .Setup(p => p.GetHandleableRequestTypes())
                .Returns(() => new List<Type>() { typeof(SampleRequest) });

            _target
                .Invoking(t => t.RegisterOrchestratable(multiOrchestratableMock.Object))
                .Should()
                .NotThrow();
        }

        [TestMethod]
        public void RegisterOrchestratableIMultiOrchestratable_AlreadyRegistered_NoException()
        {
            Mock<IMultiOrchestratable> multiOrchestratableMock = new Mock<IMultiOrchestratable>();
            multiOrchestratableMock
                .Setup(p => p.GetHandleableRequestTypes())
                .Returns(() => new List<Type>() {typeof(SampleRequest) });
            _target.RegisterOrchestratable(multiOrchestratableMock.Object);

            Mock<IMultiOrchestratable> secondMultiOrchestratableMock = new Mock<IMultiOrchestratable>();
            secondMultiOrchestratableMock
                .Setup(p => p.GetHandleableRequestTypes())
                .Returns(() => new List<Type>() { typeof(SampleRequest) });


            _target
                .Invoking(t => t.RegisterOrchestratable(secondMultiOrchestratableMock.Object))
                .Should()
                .NotThrow<OrchestrationException>("Registration for BaseOrchestrationRequest is overwritten");
        }

        [TestMethod]
        public void RegisterOrchestratableIMultiOrchestratable_NullRegistering_ThrowException()
        {
            _target
                .Invoking(t => t.RegisterOrchestratable(null))
                .Should()
                .Throw<OrchestrationException>("null is not a valid orchestratable");
        }


        
    }
    
}
