using System;
using PseudoOrk.App;

namespace PseudoOrk
{
    class Program
    {
        static void Main(string[] args)
        {
            Application._instance = new Application();
            Application._instance.Run();
        }
    }
}
