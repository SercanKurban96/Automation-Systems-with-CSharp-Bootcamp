using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayTutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] value = new int[5];
            //int[] value = { 1, 2, 3, 4, 5 };

            //int a = value.Length;

            //int[,] matrix = new int[3, 3];

            //Console.WriteLine("*********************************************************");

            //int[] value = new int[5];

            //value[0] = 1;
            //value[1] = 10;
            //value[2] = 100;
            //value[3] = 1000;
            //value[4] = 10000;

            //for (int i = 0; i < value.Length; i++)
            //{
            //    Console.WriteLine("Array Element: " + i + ": " + value[i]);
            //}

            //Console.WriteLine("*********************************************************");

            //int[] value = { 1, 10, 100, 1000, 10000 };

            //foreach (int getValue in value)
            //{
            //    Console.WriteLine("Array Elements: " + getValue);
            //}

            //Console.WriteLine("*********************************************************");

            //int[,] matrix = new int[2, 3];
            //matrix[0, 0] = 1;
            //matrix[0, 1] = 2;
            //matrix[0, 2] = 3;
            //matrix[1, 0] = 4;
            //matrix[1, 1] = 5;
            //matrix[1, 2] = 6;

            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        Console.Write(matrix[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine("*********************************************************");

            int[,] matrix = new int[3, 3];
            // Matrix Value Assignment

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = i * 3 + j + 1;
                }
            }

            // Print Matrix

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
