using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.StateMachine
{
    public abstract class StateMachineEngine<TState, TTransition>: IStateMachineEngine<TState, TTransition>
    {
        protected virtual IDictionary<StateTransition<TState, TTransition>, TState> StatesTransitionsDictionary { get; set; }

        public StateMachineEngine()
        {
            this.StatesTransitionsDictionary = this.InitStatesTransitionsDictionary();
        }

        protected abstract IDictionary<StateTransition<TState, TTransition>, TState> InitStatesTransitionsDictionary();
        
        public virtual void HandleStateTransition(StateMachineContext<TState, TTransition> stateMachineContext)
        {
            if(stateMachineContext.Transition.Equals(default(TTransition)))
            {
                throw new UnspecifiedTransitionException();
            }

            stateMachineContext.State = this.TransitState(stateMachineContext.StateTransition);
            stateMachineContext.Transition = default(TTransition);
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
