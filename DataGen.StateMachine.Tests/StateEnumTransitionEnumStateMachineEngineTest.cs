using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataGen.StateMachine.Tests.StateEnumTransitionEnumStateMachine;

namespace DataGen.StateMachine.Tests
{
    [TestClass]
    public class StateEnumTransitionEnumStateMachineEngineTest
    {
        private static IStateMachineContext<States, Transitions> stateMachineContext;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            stateMachineContext = new StateMachineContext<States, Transitions>(new StateEnumTransitionEnumStateMachineEngine());
        }

        [TestInitialize]
        public void TestInit()
        {
            
        }

        [TestMethod]
        public void StateEnumTransitionEnumStateMachineEngineTest_HandleStateTransition_StoppedPlay_ReturnsPlaying()
        {
            var currentState = States.Stopped;
            var transition = Transitions.Play;
            var expectedState = States.Playing;

            this.AssertHandleStateTransitionResult(currentState, transition, expectedState);
        }

        [TestMethod]
        public void StateEnumTransitionEnumStateMachineEngineTest_HandleStateTransition_PlayingStop_ReturnsStopped()
        {
            var currentState = States.Playing;
            var transition = Transitions.Stop;
            var expectedState = States.Stopped;

            this.AssertHandleStateTransitionResult(currentState, transition, expectedState);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStateTransitionException))]
        public void StateEnumTransitionEnumStateMachineEngineTest_HandleStateTransition_StoppedPause_ThrowsInvalidStateTransitionException()
        {
            this.ExpectHandleStateTransitionException(States.Stopped, Transitions.Pause);
        }

        private void AssertHandleStateTransitionResult(States cuttentState, Transitions transition, States expectedState)
        {
            stateMachineContext.State = cuttentState;

            stateMachineContext.HandleTransition(transition);

            Assert.AreEqual(expectedState, stateMachineContext.State);
        }

        private void ExpectHandleStateTransitionException(States cuttentState, Transitions transition)
        {
            stateMachineContext.State = cuttentState;

            stateMachineContext.HandleTransition(transition);
        }
    }
}
