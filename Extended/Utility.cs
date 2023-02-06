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
                Console.Write(arr[i] + "\t");
            }

            Console.WriteLine();
        }
        public static void DisplayArr<T>(T[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
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

        public static void SortElementsRow<T>(T[,] matrix, int rowNum, bool descending = false) where T : IComparable<T>
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
                SortElementsRow(matrix, i, descending);
            }
        }

        public static T GetSumRow<T>(this T[,] matrix, int rowNum) where T : IAdditionOperators<T, T, T>
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

        public static IEnumerable<(T, int)> GetFrequencyDictionary<T>(this IEnumerable<T> source) where T : IComparable<T>
        {
            return source
                    .Select(e => e)
                    .GroupBy(c => c)
                    .Select(g => (g.Key, g.Count()))
                    .OrderByDescending(t => t.Item2).ThenBy(t => t.Item1);
        }

        public static void DisplayFrequencyDictionary<T>(this IEnumerable<T> source) where T : IComparable<T>
        {
            var frequencyDictionary = source.GetFrequencyDictionary();
            var count = source.Count();

            foreach (var item in frequencyDictionary)
            {
                Console.WriteLine($"Символ {item.Item1} встречается {item.Item2} раз. Частота {(100.0 * item.Item2 / count):F2} %");
            }

            Console.WriteLine();
        }

        public static T[] MatrixToArray<T>(this T[,] matrix)
        {
            return matrix.Cast<T>().ToArray();
        }

        public static T[,] Multiply<T>(this T[,] a, T[,] b) where T : IAdditionOperators<T, T, T>, IMultiplyOperators<T, T, T>
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            var r = new T[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }

        public static int MaxIndex<T>(this IEnumerable<T> source) where T : IComparable<T>
        {
            int maxIndex = -1;
            T maxValue = default(T)!;

            int index = 0;
            foreach (T value in source)
            {
                if (value.CompareTo(maxValue) > 0 || maxIndex == -1)
                {
                    maxIndex = index;
                    maxValue = value;
                }
                index++;
            }
            return maxIndex;
        }

        public static (int, int) MaxIndex<T>(this T[,] matrix) where T : IComparable<T>
        {
            int maxIndexI = 0;
            int maxIndexJ = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[maxIndexI, maxIndexJ].CompareTo(matrix[i, j]) < 0)
                    {
                        maxIndexI = i;
                        maxIndexJ = j;
                    }
                }
            }

            return (maxIndexI, maxIndexJ);
        }

        public static T[,] RemoveRowColMaxElement<T>(this T[,] matrix) where T : IComparable<T>
        {
            var maxIndex = matrix.MaxIndex();
            var matrixRet = new T[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];

            var countI = 0;
            var countJ = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == maxIndex.Item1) continue;
                countJ = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == maxIndex.Item2) continue;
                    matrixRet[countI, countJ] = matrix[i, j];
                    countJ++;
                }

                countI++;
            }

            return matrixRet;
        }

        public static int[,,] CreateCubeWithUnique(int w, int h, int l, int from)
        {
            var numbers = new List<int>();
            var r = new Random();
            var cube = new int[w, h, l];

            for (int i = from; i < w * h * l + from; i++)
            {
                numbers.Add(i);
            }

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    for (int k = 0; k < l; k++)
                    {
                        var index = r.Next(0, numbers.Count);
                        cube[i, j, k] = numbers[index];
                        numbers.RemoveAt(index);

                    }
                }
            }

            return cube;
        }

        public static void DisplayArr<T>(T[,,] arr, bool withCoord = true)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine($"{i}-ая плоскость куба");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        string text = withCoord ? arr[i, j, k] + $"({i},{j},{k})" : arr[i, j, k]!.ToString()!;
                        Console.Write($"{text}\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static void DisplayPascalTriangle(int n)
        {
            for (int i = 0; i < n; i++)
            {
                string s = string.Empty;

                for (int c = 0; c <= i; c++)
                {
                    s += " " + BinomialCoefficient(i, c) + " ";
                }

                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                Console.WriteLine(s);
            }
        }

        public static long BinomialCoefficient(int n, int m)
        {
            long ans = 1;
            m = m > n - m ? n - m : m;
            int j = 1;
            for (; j <= m; j++, n--)
            {
                if (n % j == 0)
                {
                    ans *= n / j;
                }
                else
                if (ans % j == 0)
                {
                    ans = ans / j * n;
                }
                else
                {
                    ans = (ans * n) / j;
                }
            }
            return ans;
        }
    }
}