using System;
using System.Collections.Generic;
using System.Text;

namespace PseudoOrk.Commands
{
    internal class Command
    {
        private string input;
        private FileSystem fileSystem = new FileSystem();

        public void ReadLine()
        {
            Console.Write("<" + fileSystem.GetPath() + "> : ");
            input = Console.ReadLine();
        }
        public void HandleLine()
        {
            try
            {
                fileSystem.EnterPath(Type.GetType("PseudoOrk.Commands." + input, true, true));
                Console.WriteLine("<"+ fileSystem.GetPath() + "> :");
            }
            catch (Exception e)
            {
                Console.WriteLine(input+ " Could not be Found");
            }
        }
    }
}
