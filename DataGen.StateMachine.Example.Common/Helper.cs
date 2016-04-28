using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.StateMachine.Example.Common
{
    public static class StateMachineExampleHelper
    {
        public static void DisplayState<TState, TTransition>(this IStateMachineContext<TState, TTransition> player)
        {
            Console.WriteLine();
            Console.WriteLine(string.Format("Current state: {0}", player.State.ToString()));
        }

        public static void GetUserCommand(Action<string> menuCommandHandler)
        {
            var key = Console.ReadKey();
            Console.WriteLine();
            menuCommandHandler(key.KeyChar.ToString());
        }

        public static void HandleCommand<TState, TTransition>(TTransition transition, IStateMachineContext<TState, TTransition> player)
        {
            try
            {
                player.HandleTransition(transition);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void WrongCommand()
        {
            Console.WriteLine("Wrong command! Try again.");
        }
    }
}
