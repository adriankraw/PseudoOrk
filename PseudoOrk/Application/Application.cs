using System;
using System.Collections.Generic;
using System.Text;
using PseudoOrk.Commands;

namespace PseudoOrk.App
{
    internal class Application
    {
        public static Application _instance;
        private Command commands = new Command();
        public void Run()
        {
            Console.WriteLine("Welcome \n");
            while (true)
            {
                commands.ReadLine();
                commands.HandleLine();
            }
        }
    }

}
