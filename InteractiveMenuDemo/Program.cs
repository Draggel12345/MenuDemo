using InteractiveMenuDemo.Service;
using static System.Console;

namespace InteractiveMenuDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CursorVisible = false;
            MenuService service = new();
            service.Start();
        }
    }
}
