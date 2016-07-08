using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataGen.StateMachine.Tests.StateEnumTransitionEnumStateMachine;

namespace DataGen.StateMachine.Tests
{
    [TestClass]
    public class FakeStateEnumTransitionEnumStateMachineEngineTest
    {
        private static IStateMachineContext<FakeStates, FakeTransitions> stateMachineContext;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            stateMachineContext = new StateMachineContext<FakeStates, FakeTransitions>(new FakeStateEnumTransitionEnumStateMachineEngine());
        }

        [TestInitialize]
        public void TestInit()
        {
            
        }

        [TestMethod]
        public void FakeStateEnumTransitionEnumStateMachineEngineTest_HandleStateTransition_StoppedPlay_ReturnsPlaying()
        {
            var currentState = FakeStates.Stopped;
            var transition = FakeTransitions.Play;
            var expectedState = FakeStates.Playing;

            this.AssertHandleStateTransitionResult(currentState, transition, expectedState);
        }

        [TestMethod]
        public void FakeStateEnumTransitionEnumStateMachineEngineTest_HandleStateTransition_PlayingStop_ReturnsStopped()
        {
            var currentState = FakeStates.Playing;
            var transition = FakeTransitions.Stop;
            var expectedState = FakeStates.Stopped;

            this.AssertHandleStateTransitionResult(currentState, transition, expectedState);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStateTransitionException))]
        public void FakeStateEnumTransitionEnumStateMachineEngineTest_HandleStateTransition_StoppedPause_ThrowsInvalidStateTransitionException()
        {
            this.ExpectHandleStateTransitionException(FakeStates.Stopped, FakeTransitions.Pause);
        }

        [TestMethod]
        [ExpectedException(typeof(UnspecifiedTransitionException))]
        public void FakeStateEnumTransitionEnumStateMachineEngineTest_HandleStateTransition_StoppedUnknown_ThrowsNullTransitionException()
        {
            this.ExpectHandleStateTransitionException(FakeStates.Stopped, FakeTransitions.Unknown);
        }

        private void AssertHandleStateTransitionResult(FakeStates cuttentState, FakeTransitions transition, FakeStates expectedState)
        {
            stateMachineContext.State = cuttentState;

            stateMachineContext.HandleTransition(transition);

            Assert.AreEqual(expectedState, stateMachineContext.State);
        }

        private void ExpectHandleStateTransitionException(FakeStates cuttentState, FakeTransitions transition)
        {
            stateMachineContext.State = cuttentState;

            stateMachineContext.HandleTransition(transition);
        }
    }
}
