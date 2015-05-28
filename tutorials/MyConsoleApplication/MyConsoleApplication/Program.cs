using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApplication
{
    class Program
    {
        static void Main()
        {
            int x = 3;
            int y = 4;
            int result = MyClassLibrary1.MyMath.AddNumbers(x, y);
            Console.WriteLine(result);
        }


    }
}
