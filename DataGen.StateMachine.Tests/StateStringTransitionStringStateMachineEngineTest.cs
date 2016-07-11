using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataGen.StateMachine.Tests.StateStringTransitionStringStateMachine;

namespace DataGen.StateMachine.Tests
{
    [TestClass]
    public class StateStringTransitionStringStateMachineEngine
    {
        private static IStateMachineContext<string, string> stateMachineContext;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            stateMachineContext = new StateMachineEngineContext<string, string>(new StateStringTransitionStringStateMachine.StateStringTransitionStringStateMachineEngine());
        }

        [TestInitialize]
        public void TestInit()
        {
            
        }

        [TestMethod]
        public void StateStringTransitionStringStateMachineEngineTest_HandleStateTransition_StoppedPlay_ReturnsPlaying()
        {
            var currentState = "Stopped";
            var transition = "Play";
            var expectedState = "Playing";

            this.AssertHandleStateTransitionResult(currentState, transition, expectedState);
        }

        [TestMethod]
        public void StateStringTransitionStringStateMachineEngineTest_HandleStateTransition_PlayingStop_ReturnsStopped()
        {
            var currentState = "Playing";
            var transition = "Stop";
            var expectedState = "Stopped";

            this.AssertHandleStateTransitionResult(currentState, transition, expectedState);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStateTransitionException))]
        public void StateStringTransitionStringStateMachineEngineTest_HandleStateTransition_StoppedPause_ThrowsInvalidStateTransitionException()
        {
            this.ExpectHandleStateTransitionException("Stopped", "Pause");
        }

        private void AssertHandleStateTransitionResult(string cuttentState, string transition, string expectedState)
        {
            stateMachineContext.State = cuttentState;

            stateMachineContext.HandleTransition(transition);

            Assert.AreEqual(expectedState, stateMachineContext.State);
        }

        private void ExpectHandleStateTransitionException(string cuttentState, string transition)
        {
            stateMachineContext.State = cuttentState;

            stateMachineContext.HandleTransition(transition);
        }
    }
}
