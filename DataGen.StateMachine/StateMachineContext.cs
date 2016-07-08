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
        protected virtual BaseStateMachineEngine<TState, TTransition> StateMachine { get; set; }

        public virtual TState State { get; set; }

        public virtual void HandleTransition(TTransition transition)
        {
            this.StateMachine.HandleStateTransition(this, transition);
        }

        public StateMachineContext(BaseStateMachineEngine<TState, TTransition> stateMachine, TState state)
        {
            this.StateMachine = stateMachine;
            this.State = state;
        }

        public StateMachineContext(BaseStateMachineEngine<TState, TTransition> stateMachine)
        {
            this.StateMachine = stateMachine;
            this.State = default(TState);
        }
    }
}
