using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get user input.

            System.Console.WriteLine("Enter a number");
            string input = System.Console.ReadLine();

            // Convert the input string to an int. 
            int j;
            System.Int32.TryParse(input, out j);

            // Write a different string each iteration. 
            string s;
            for (int i = 0; i < 20; i++)
            {
                // A simple format string with no alignment formatting.
                s = System.String.Format("{0} * {1} * {2} = {3}", i, j, j, (i * j * j));
                System.Console.WriteLine(s);
            }

            //Keep the console window open in debug mode.
            System.Console.ReadKey();
        }
    }
}
