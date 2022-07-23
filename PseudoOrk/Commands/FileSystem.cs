using System;
using System.Collections.Generic;
using System.Text;

namespace PseudoOrk.Commands
{
    abstract class PathNode
    {
        public bool use;
        public string path;
        public List<PathNode> children;
        public PathNode parent;
    }
    class GameNode : PathNode
    {
        public GameNode()
        {
            use = false;
            path = "Game";
            children = new List<PathNode>();
            children.Add(new CharacterNode() 
            {
                parent = this
            });
            parent = null;
        }
    }
    class CharacterNode : PathNode
    {
        public CharacterNode()
        {
            use = false;
            path = "Char";
            children = new List<PathNode>();
            children.Add(new StatsNode()
            {
                parent = this
            });
            parent = null;
        }
    }
    class StatsNode : PathNode 
    {
        public StatsNode()
        {
            use = false;
            path = "Stats";
            children = null;
            parent = null;
        }
    }
    internal class FileSystem
    {
        PathNode currentNode;
        PathNode tmpGetPathNode;
        string erg = "";
        Stack<PathNode> stack;
        public FileSystem()
        {
            currentNode = new GameNode();
        }
        public string GetPath()
        {
            if (currentNode.parent == null)
            {
                return currentNode.path;
            }
            else
            {
                erg = "";
                if (stack == null)
                {
                    stack = new Stack<PathNode>();
                }
                else 
                {
                    stack.Clear();
                }
                tmpGetPathNode = currentNode;
                while (tmpGetPathNode != null)
                {
                    stack.Push(tmpGetPathNode);
                    tmpGetPathNode = tmpGetPathNode.parent != null ? tmpGetPathNode.parent : null;
                }
                while (stack.Count != 0)
                {
                    tmpGetPathNode = stack.Pop();
                    erg += tmpGetPathNode.path + "/";
                }
                tmpGetPathNode = null;
                return erg;
            }
        }
        public void EnterPath(System.Type node)
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
