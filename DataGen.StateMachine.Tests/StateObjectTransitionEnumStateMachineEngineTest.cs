using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataGen.StateMachine.Tests.StateObjectTransitionEnumStateMachine;
using StateMachine.Tests.StateObjectTransitionEnumStateMachine.States;
using DataGen.StateMachine.ObjectOriented;

namespace DataGen.StateMachine.Tests
{
    [TestClass]
    public class StateObjectTransitionEnumStateMachineEngineTest
    {
        private static IStateMachineContext<IState<Transitions>, Transitions> stateMachineContext;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            stateMachineContext = new ObjectOrientedStateMachineContext<IState<Transitions>, Transitions>();
        }

        [TestInitialize]
        public void TestInit()
        {
            
        }

        [TestMethod]
        public void StateObjectTransitionEnumStateMachineEngineTest_HandleStateTransition_StoppedPlay_ReturnsPlaying()
        {
            var currentState = new Stopped();
            var transition = Transitions.Play;
            var expectedStateType = typeof(Playing);

            this.AssertHandleStateTransitionResult(currentState, transition, expectedStateType);
        }

        [TestMethod]
        public void StateObjectTransitionEnumStateMachineEngineTest_HandleStateTransition_PlayingStop_ReturnsStopped()
        {
            var currentState = new Playing();
            var transition = Transitions.Stop;
            var expectedStateType = typeof(Stopped);

            this.AssertHandleStateTransitionResult(currentState, transition, expectedStateType);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStateTransitionException))]
        public void StateObjectTransitionEnumStateMachineEngineTest_HandleStateTransition_StoppedPause_ThrowsInvalidStateTransitionException()
        {
            this.ExpectHandleStateTransitionException(new Stopped(), Transitions.Pause);
        }

        private void AssertHandleStateTransitionResult(IState<Transitions> cuttentState, Transitions transition, Type expectedStateType)
        {
            stateMachineContext.State = cuttentState;

            stateMachineContext.HandleTransition(transition);

            Assert.IsInstanceOfType(stateMachineContext.State, expectedStateType);
        }

        private void ExpectHandleStateTransitionException(IState<Transitions> cuttentState, Transitions transition)
        {
            stateMachineContext.State = cuttentState;

            stateMachineContext.HandleTransition(transition);
        }
    }
}
