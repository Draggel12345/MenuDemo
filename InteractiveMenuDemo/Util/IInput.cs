using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveMenuDemo.Util
{
    interface IInput
    {
        string GetString();
        int GetInt();
    }
}
