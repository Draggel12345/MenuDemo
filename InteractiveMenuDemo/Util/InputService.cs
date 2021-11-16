using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace InteractiveMenuDemo.Util
{
    class InputService : IInput
    {
        public int GetInt()
        {
            int integer;
            while (!int.TryParse(ReadLine(), out integer))
            {
                WriteLine("Input has to be an integer and cant be empty field.");
                Write("Try again: ");
            }
            return integer;
        }

        public string GetString()
        {
            string str = ReadLine();
            while (string.IsNullOrEmpty(str))
            {
                WriteLine("Input has to be letters and cant be empty field.");
                Write("Try again: ");
                str = ReadLine();
            }
            return str;
        }
    }
}
