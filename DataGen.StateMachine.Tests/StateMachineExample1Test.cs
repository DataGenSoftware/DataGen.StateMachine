using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataGen.StateMachine.Example1;

namespace DataGen.StateMachine.Tests
{
    [TestClass]
    public class StateMachineExample1Test
    {
        private static IStateMachineEngine<States, Transitions> stateMachine;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            stateMachine = new StateMachineEngine();
        }

        [TestInitialize]
        public void TestInit()
        {
            
        }

        [TestMethod]
        public void StateMachineExample1_HandleStateTransition_StoppedPlay_ReturnsPlaying()
        {
            var currentState = States.Stopped;
            var transition = Transitions.Play;
            var expectedState = States.Playing;

            this.AssertHandleStateTransitionResult(currentState, transition, expectedState);
        }

        [TestMethod]
        public void StateMachineExample1_HandleStateTransition_PlayingStop_ReturnsStopped()
        {
            var currentState = States.Playing;
            var transition = Transitions.Stop;
            var expectedState = States.Stopped;

            this.AssertHandleStateTransitionResult(currentState, transition, expectedState);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStateTransitionException))]
        public void StateMachineExample1_HandleStateTransition_StoppedPause_ThrowsInvalidStateTransitionException()
        {
            this.ExpectHandleStateTransitionException(States.Stopped, Transitions.Pause);
        }

        [TestMethod]
        [ExpectedException(typeof(UnspecifiedTransitionException))]
        public void StateMachineExample1_HandleStateTransition_StoppedNull_ThrowsNullTransitionException()
        {
            this.ExpectHandleStateTransitionException(States.Stopped, Transitions.Unknown);
        }

        private void AssertHandleStateTransitionResult(States cuttentState, Transitions transition, States expectedState)
        {
            StateMachineContext<States, Transitions> stateMachineContext = this.MakeStateMachineContext(cuttentState, transition);

            stateMachine.HandleStateTransition(stateMachineContext);

            Assert.AreEqual(expectedState, stateMachineContext.State);
        }

        private void ExpectHandleStateTransitionException(States cuttentState, Transitions transition)
        {
            StateMachineContext<States, Transitions> stateMachineContext = this.MakeStateMachineContext(cuttentState, transition);

            stateMachine.HandleStateTransition(stateMachineContext);
        }

        private StateMachineContext<States, Transitions> MakeStateMachineContext(States cuttentState, Transitions transition)
        {
            var stateMachineContext = new StateMachineContext<States, Transitions>(new StateMachineEngine(), cuttentState);
            stateMachineContext.Transition = transition;
            return stateMachineContext;
        }

    }
}
