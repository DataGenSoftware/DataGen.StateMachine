using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGen.Extensions;

namespace DataGen.StateMachine
{
    public class StateMachineContext<TState, TTransition> : IStateMachineContext<TState, TTransition>
    {
        protected virtual IStateMachineEngine<TState, TTransition> StateMachine { get; set; }

        public virtual TState State { get; set; }

        public virtual TTransition Transition { get; set; }

        public virtual StateTransition<TState, TTransition> StateTransition
        {
            get
            {
                if (this.Transition.IsNotNull())
                {
                    return new StateTransition<TState, TTransition>()
                    {
                        State = this.State,
                        Transition = this.Transition
                    };
                }

                return null;
            }
        }

        public virtual void HandleTransition(TTransition transition)
        {
            this.Transition = transition;
            this.StateMachine.HandleStateTransition(this);
        }

        public StateMachineContext(IStateMachineEngine<TState, TTransition> stateMachine, TState state)
        {
            this.StateMachine = stateMachine;
            this.State = state;
        }
    }
}
