using InteractiveMenuDemo.Service;
using System;
using System.IO;
using static System.Console;

namespace InteractiveMenuDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RunProgram();
        }

        public static void RunProgram()
        {
            CursorVisible = false;
            MenuService service = new();
            service.Start();
        }
    }
}
