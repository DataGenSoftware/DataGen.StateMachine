using DataGen.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.StateMachine
{
    public abstract class StateMachineEngine<TState, TTransition>: BaseStateMachineEngine<TState, TTransition>
    {
        protected virtual IDictionary<StateTransition<TState, TTransition>, TState> StatesTransitionsDictionary { get; set; }

        public StateMachineEngine()
        {
            this.StatesTransitionsDictionary = this.InitStatesTransitionsDictionary();
        }

        protected abstract IDictionary<StateTransition<TState, TTransition>, TState> InitStatesTransitionsDictionary();

        public override void HandleStateTransition(StateMachineEngineContext<TState, TTransition> stateMachineContext, TTransition transition)
        {
            if(transition.IsNull())
            {
                throw new UnspecifiedTransitionException();
            }

            stateMachineContext.State = this.TransitState(new StateTransition<TState, TTransition>(stateMachineContext.State, transition));
        }

        protected virtual TState TransitState(StateTransition<TState, TTransition> stateTransition)
        {
            if (this.StatesTransitionsDictionary.ContainsKey(stateTransition))
            {
                return this.StatesTransitionsDictionary[stateTransition];
            }

            throw new InvalidStateTransitionException(stateTransition);
        }
    }
}
