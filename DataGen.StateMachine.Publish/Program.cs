using DataGen.Publish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.StateMachine.Publish
{
    class Program
    {
        static void Main(string[] args)
        {
            var publishManagerBuilder = new PublishManagerBuilder();
            publishManagerBuilder.Build();
            var publishManager = publishManagerBuilder.PublishManager;

            publishManager.DisplayMenu();
        }
    }
}
