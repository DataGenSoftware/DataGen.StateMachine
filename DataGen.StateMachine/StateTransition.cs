using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.StateMachine
{
    public class StateTransition<TState, TTransition>
    {
        public TState State { get; set; }

        public TTransition Transition { get; set; }

        public override string ToString()
        {
            return string.Format("State: {0}, Transision: {1}", this.State.ToString(), this.Transition.ToString());
        }

        public override int GetHashCode()
        {
            return new { this.State, this.Transition }.GetHashCode();
        }

        public override bool Equals(object other)
        {
            return Equals(other as StateTransition<TState, TTransition>);
        }

        public bool Equals(StateTransition<TState, TTransition> other)
        {
            return other != null && other.State.Equals(this.State) && other.Transition.Equals(this.Transition);
        }

        public StateTransition()
        {
        }

        public StateTransition(TState state, TTransition transition)
        {
            this.State = state;
            this.Transition = transition;
        }
    }
}
