using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract.DataClasses;
using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract.Exceptions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Orchestration.Tests.OrchestratorTests
{
    public partial class OrchestratorTests
    {
        [TestMethod]
        public void RegisterOrchestratableDelegate_NullPassed_ThrowException()
        {
            _target
                .Invoking(t => t.RegisterOrchestratable<BaseOrchestrationRequest>((Action<BaseOrchestrationRequest>)null))
                .Should()
                .Throw<OrchestrationException>("null is not a valid delegate");
        }

        [TestMethod]
        public void RegisterOrchestratableDelegate_DelegatePassed_NoException()
        {
            _target
                .Invoking(t => t.RegisterOrchestratable<BaseOrchestrationRequest>((request) => { }))
                .Should()
                .NotThrow();
        }

        [TestMethod]
        public void RegisterOrchestratableDelegate_DelegatePassedForAlreadyRegisteredOrchestration_NoException()
        {
            _target.RegisterOrchestratable<BaseOrchestrationRequest>((request)=>{ });

            _target
                .Invoking(t => t.RegisterOrchestratable<BaseOrchestrationRequest>((request) => { }))
                .Should()
                .NotThrow("registered registration is overwritten");
        }
    }
}
