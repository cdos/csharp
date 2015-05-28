using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            double d = 5;
            double e = 6;

            int i;
            int f;
            int g;

            i = (int)d;
            f = (int)e;
            g = (int)i+f;

            /*Testing C# APP Console*/
            Console.WriteLine(g);
            Console.ReadKey();
        }
    }
}
