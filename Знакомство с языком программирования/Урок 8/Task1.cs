using Command;
using Extended;

namespace Lesson8
{
    public class Task1 : TaskBase
    {
        public override void Execute()
        {
            Console.WriteLine("Введите текст: ");
            var str = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Частотный словарь: ");
            str.DisplayFrequencyDictionary();

            var n = Utility.ReadIntConsole("Введите кол-во строк");
            var m = Utility.ReadIntConsole("Введите кол-во столбцов");
            var matrix = Utility.CreateMatrix(n, m);
            Utility.DisplayArr(matrix);

            var array = matrix.MatrixToArray();
            Console.WriteLine("Частотный словарь для матрицы: ");
            array.DisplayFrequencyDictionary();
        }

        public override string GetName()
        {
            return "Составить частотный словарь (текст, массив).";
        }
    }
}