using System;
using System.Collections.Generic;
using System.Text;

namespace PseudoOrk.Commands
{
    public static class Dir
    {
        public static string Run(PathNode currentNode)
        {
            string a = "";
            if (currentNode.children.Count == 0) return null;

            foreach (PathNode x in currentNode.children)
            {
                a += x.path;
            }
            return a;
        }
    }
}
