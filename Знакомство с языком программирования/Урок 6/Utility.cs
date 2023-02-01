using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task
{
    delegate void MethodHandler();

    public static class Utility
    {
        public static List<int> GetDigitsNumber(int number)
        {
            int num = number;
            List<int> digits = new List<int>();
            int modnum;

            do
            {
                modnum = num % 10;
                digits.Add(modnum);
                num /= 10;
            } while (num > 0);

            return digits;
        }

        public static void DisplayArr<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
        }
        public static void DisplayArr<T>(T[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static int Power(int a, int n)
        {
            int res = 1;

            for (int i = 1; i <= n; i++)
            {
                res *= a;
            }

            return res;
        }

        public static int PowerRecursion(int a, int n)
        {
            if (a == 0 && n <= 0)
                throw new ArithmeticException("Для 0 степень должна быть > 0");

            if (a == 1 || a == 0) return a;

            return n > 1 ? a * PowerRecursion(a, n - 1) : a;
        }

    }
}