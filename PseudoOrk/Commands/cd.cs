using System;
using System.Collections.Generic;
using System.Text;

namespace PseudoOrk.Commands
{
    public static class Cd
    {
        public static void Run(PathNode currentNode, System.Type node)
        {
            int i;
            for (i = 0; i < currentNode.children.Count; i++)
            {
                if (currentNode.children[i].GetType() == node)
                {
                    break;
                }
            }
            if (i == currentNode.children.Count - 1 && currentNode.children[currentNode.children.Count - 1].GetType() != node)
            {
                return;
            }
            else
            {
                currentNode = currentNode.children[i];
            }
        }
    }
}
