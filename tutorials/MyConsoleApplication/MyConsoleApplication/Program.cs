using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            //string result = GetName(0);
            //int x = 3;
            //int y = 4;
            //int result = MyClassLibrary1.MyMath.AddNumbers(x, y);
            //Console.WriteLine(result);

            //Arrays
            int[] array2 = new int[] { 1, 3, 5, 7, 9 };
            array2 = new int[] { 11, 33, 55, 77, 99 };

            int[] array3 = { 1, 3, 5, 7, 9 };

            int[,] multiDimensionalArray1 = new int[2, 3];

            //int[][] jaggedArray = new int[6][];
            //jaggedArray[0] = new int[] { 1, 2, 3, 4 };
            //jaggedArray[1] = new int[] { 1, 2, 3 };
            //jaggedArray[2] = new int[] { 1, 2 };
            //jaggedArray[3] = new int[] { 1, 2, 3, 4,5,6,7 };
            //jaggedArray[4] = new int[] { 1 };
            //jaggedArray[5] = new int[] { 1, 2, 3, 4 };

            //foreach (int [] row in jaggedArray)
            //{
            //    foreach (int element in row)
            //    {
            //        System.Console.Write(element + " ");
            //    }
            //    System.Console.Write(row);
            //}

            //int[][] jaggedArray2 = new int[3][];

            //contains a bunch of zeros
            //jaggedArray2[0] = new int[5];
            //jaggedArray2[1] = new int[4];
            //jaggedArray2[2] = new int[2];

            //jagggedarray with multidimensional array
            //int[][,] myJaggedArray = new int[3][,]
            //{
            //    new int[,] { {1,3},{5,7}},
            //    new int[,] {{2,2},{3,3}},
            //    new int[,] {{33,44},{55,66}},                
            //};

            //Console.WriteLine("{0}",myJaggedArray[0][1,0]);

            //string a = "hello";
            //string b = "h";
            //// Append to contents of 'b'
            //b += "ello";
            //Console.WriteLine(a == b);
            //Console.WriteLine((object)a == (object)b);

            string a = "\u0068ello ";
            string b = "world";
            Console.WriteLine(a + b);
            Console.WriteLine(a + b == "Hello World"); // == performs a case-sensitive comparison

        }

        //public static string GetName(int ID)
        //{
        //    if (ID >= 0 && ID < names.Length) //ID is greater or equal to 0 AND ID  is less than length of array names.
        //        return names[ID];
        //    else
        //        return String.Empty;
        //}
        //private static string[] names = { "Spencer", "Sally", "Doug" };


    }
}
