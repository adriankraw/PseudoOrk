using System;
using System.Collections.Generic;
using System.Text;

namespace PseudoOrk.Commands
{
    public abstract class PathNode
    {
        public bool use;
        public string path;
        public List<PathNode> children;
        public PathNode parent;
    }
    class Game : PathNode
    {
        public Game()
        {
            use = false;
            path = "Game";
            children = new List<PathNode>();
            children.Add(new Character() 
            {
                parent = this
            });
            parent = null;
        }
    }
    class Character : PathNode
    {
        public Character()
        {
            use = false;
            path = "Char";
            children = new List<PathNode>();
            children.Add(new Stats()
            {
                parent = this
            });
            parent = null;
        }
    }
    class Stats : PathNode 
    {
        public Stats()
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
            currentNode = new Game();
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
            Cd.Run(currentNode, node);
        }
        public string ShowFolders()
        {
            return Dir.Run(currentNode);
        }
    }
}
