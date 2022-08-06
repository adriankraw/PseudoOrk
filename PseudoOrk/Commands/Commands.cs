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
                string app = input.Split(' ')[0];
                string parameters = input.Replace(app, "").TrimStart();
                switch (app)
                {
                    case "cd":
                        fileSystem.EnterPath(Type.GetType("PseudoOrk.Commands." + parameters, true, true));
                        break;
                    case "dir":
                        Console.WriteLine(fileSystem.ShowFolders());
                        break;
                }
                //Console.WriteLine("<"+ fileSystem.GetPath() + "> :");
            }
            catch (Exception e)
            {
                Console.WriteLine(input+ " Could not be Found");
            }
        }
    }
}
