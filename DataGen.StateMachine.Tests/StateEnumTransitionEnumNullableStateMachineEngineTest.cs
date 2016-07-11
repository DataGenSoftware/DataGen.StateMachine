using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataGen.StateMachine.Tests.StateEnumTransitionEnumNullableStateMachine;

namespace DataGen.StateMachine.Tests
{
    [TestClass]
    public class StateEnumTransitionEnumNullableStateMachineEngineTest
    {
        private static IStateMachineContext<States, Transitions?> stateMachineContext;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            stateMachineContext = new StateMachineEngineContext<States, Transitions?>(new StateEnumTransitionEnumNullableStateMachineEngine());
        }

        [TestInitialize]
        public void TestInit()
        {
            
        }

        [TestMethod]
        public void StateEnumTransitionEnumNullableStateMachineEngineTest_HandleStateTransition_StoppedPlay_ReturnsPlaying()
        {
            var currentState = States.Stopped;
            var transition = Transitions.Play;
            var expectedState = States.Playing;

            this.AssertHandleStateTransitionResult(currentState, transition, expectedState);
        }

        [TestMethod]
        public void StateEnumTransitionEnumNullableStateMachineEngineTest_HandleStateTransition_PlayingStop_ReturnsStopped()
        {
            var currentState = States.Playing;
            var transition = Transitions.Stop;
            var expectedState = States.Stopped;

            this.AssertHandleStateTransitionResult(currentState, transition, expectedState);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStateTransitionException))]
        public void StateEnumTransitionEnumNullableStateMachineEngineTest_HandleStateTransition_StoppedPause_ThrowsInvalidStateTransitionException()
        {
            this.ExpectHandleStateTransitionException(States.Stopped, Transitions.Pause);
        }

        [TestMethod]
        [ExpectedException(typeof(UnspecifiedTransitionException))]
        public void StateEnumTransitionEnumNullableStateMachineEngineTest_HandleStateTransition_Stoppednull_ThrowsNullTransitionException()
        {
            this.ExpectHandleStateTransitionException(States.Stopped, null);
        }

        private void AssertHandleStateTransitionResult(States cuttentState, Transitions transition, States expectedState)
        {
            stateMachineContext.State = cuttentState;

            stateMachineContext.HandleTransition(transition);

            Assert.AreEqual(expectedState, stateMachineContext.State);
        }

        private void ExpectHandleStateTransitionException(States cuttentState, Transitions? transition)
        {
            stateMachineContext.State = cuttentState;

            stateMachineContext.HandleTransition(transition);
        }
    }
}
