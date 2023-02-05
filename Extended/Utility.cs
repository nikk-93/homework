using System.Numerics;
using System.Reflection;
using Command;

namespace Extended
{
    public static class Utility
    {
        public static Dictionary<int, TaskBase> GetTasks(Assembly assembly)
        {
            var task = new Dictionary<int, TaskBase>();

            //AppDomain.CurrentDomain.GetAssemblies()

            var instances = from t in assembly.GetTypes()
                            where t.BaseType == typeof(TaskBase)
                               && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as TaskBase;

            int count = 0;

            foreach (var instance in instances)
            {
                task.Add(++count, instance);
            }

            return task;
        }

        public static int ReadIntConsole(string message)
        {
            Console.Write($"{message}: ");
            return int.Parse(Console.ReadLine() ?? "0");
        }

        public static List<int> GetDigitsNumber(int number)
        {
            int num = number;
            List<int> digits = new List<int>();
            int modNum;

            do
            {
                modNum = num % 10;
                digits.Add(modNum);
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

        public static int[,] CreateMatrix(int rows, int cols, int from = 1, int to = 10)
        {
            var matrix = new int[rows, cols];
            var r = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = r.Next(from, to + 1);
                }
            }

            return matrix;
        }

        public static int[,] GetTransposeMatrix(int[,] matrix)
        {
            int[,] tMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    tMatrix[j, i] = matrix[i, j];
                }
            }

            return tMatrix;
        }

        public static void TransposeMatrix(ref int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Swap(ref matrix[i, j], ref matrix[j, i]);
                }
            }
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        public static void SwapRows<T>(ref T[,] matrix, int r1, int r2)
        {
            if (r1 >= matrix.GetLength(0) ||
                r2 >= matrix.GetLength(0))
                return;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Swap(ref matrix[r1, j], ref matrix[r2, j]);
            }
        }

        public static void SwapColumns<T>(T[,] matrix, int r1, int r2)
        {
            if (r1 >= matrix.GetLength(1) ||
                r2 >= matrix.GetLength(1))
                return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Swap(ref matrix[i, r1], ref matrix[i, r2]);
            }
        }

        public static void SortRow<T>(T[,] matrix, int rowNum, bool descending = false) where T : IComparable<T>
        {

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                var indexElement = 0;

                for (int j = 0; j < matrix.GetLength(1) - i; j++)
                {
                    if (descending &&
                        matrix[rowNum, indexElement].CompareTo(matrix[rowNum, j]) > 0 ||
                       !descending &&
                        matrix[rowNum, indexElement].CompareTo(matrix[rowNum, j]) < 0)
                        indexElement = j;
                }

                Swap(ref matrix[rowNum, indexElement], ref matrix[rowNum, matrix.GetLength(1) - i - 1]);
            }
        }

        public static void SortElementsRows<T>(this T[,] matrix, bool descending = false) where T : IComparable<T>
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                SortRow(matrix, i, descending);
            }
        }

        public static T? GetSumRow<T>(this T[,] matrix, int rowNum) where T : IAdditionOperators<T, T, T>
        {
            var sum = default(T)!;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[rowNum, j];
            }

            return sum;
        }

        public static int GetIndexRowSum<T>(this T[,] matrix, bool descending = false) where T : IAdditionOperators<T, T, T>, IComparable<T>
        {
            int index = 0;

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (!descending && matrix.GetSumRow(index)?.CompareTo(matrix.GetSumRow(i)) < 0 ||
                     descending && matrix.GetSumRow(index)?.CompareTo(matrix.GetSumRow(i)) > 0)
                    index = i;
            }

            return index;
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