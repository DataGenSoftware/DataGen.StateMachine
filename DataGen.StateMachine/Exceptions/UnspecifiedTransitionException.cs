using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.StateMachine
{
    public class UnspecifiedTransitionException : Exception
    {
        public UnspecifiedTransitionException()
            :base("Transition not set.")
        {
        }
    }
}
