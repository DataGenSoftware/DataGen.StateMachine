using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataGen.StateMachine.Tests.StateEnumTransitionEnumNullableStateMachine;

namespace DataGen.StateMachine.Tests
{
    [TestClass]
    public class FakeStateEnumTransitionEnumNullableStateMachineEngineTest
    {
        private static IStateMachineContext<FakeStates, FakeTransitions?> stateMachineContext;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            stateMachineContext = new StateMachineContext<FakeStates, FakeTransitions?>(new FakeStateEnumTransitionEnumNullableStateMachineEngine());
        }

        [TestInitialize]
        public void TestInit()
        {
            
        }

        [TestMethod]
        public void FakeStateEnumTransitionEnumNullableStateMachineEngineTest_HandleStateTransition_StoppedPlay_ReturnsPlaying()
        {
            var currentState = FakeStates.Stopped;
            var transition = FakeTransitions.Play;
            var expectedState = FakeStates.Playing;

            this.AssertHandleStateTransitionResult(currentState, transition, expectedState);
        }

        [TestMethod]
        public void FakeStateEnumTransitionEnumNullableStateMachineEngineTest_HandleStateTransition_PlayingStop_ReturnsStopped()
        {
            var currentState = FakeStates.Playing;
            var transition = FakeTransitions.Stop;
            var expectedState = FakeStates.Stopped;

            this.AssertHandleStateTransitionResult(currentState, transition, expectedState);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStateTransitionException))]
        public void FakeStateEnumTransitionEnumNullableStateMachineEngineTest_HandleStateTransition_StoppedPause_ThrowsInvalidStateTransitionException()
        {
            this.ExpectHandleStateTransitionException(FakeStates.Stopped, FakeTransitions.Pause);
        }

        [TestMethod]
        [ExpectedException(typeof(UnspecifiedTransitionException))]
        public void FakeStateEnumTransitionEnumNullableStateMachineEngineTest_HandleStateTransition_Stoppednull_ThrowsNullTransitionException()
        {
            this.ExpectHandleStateTransitionException(FakeStates.Stopped, null);
        }

        private void AssertHandleStateTransitionResult(FakeStates cuttentState, FakeTransitions transition, FakeStates expectedState)
        {
            stateMachineContext.State = cuttentState;

            stateMachineContext.HandleTransition(transition);

            Assert.AreEqual(expectedState, stateMachineContext.State);
        }

        private void ExpectHandleStateTransitionException(FakeStates cuttentState, FakeTransitions? transition)
        {
            stateMachineContext.State = cuttentState;

            stateMachineContext.HandleTransition(transition);
        }
    }
}
