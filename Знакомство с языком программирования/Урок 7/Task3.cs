using Command;
using Extended;

namespace Lesson7
{
    public class Task3 : TaskBase
    {
        public override void Execute()
        {
            var n = Utility.ReadIntConsole("Введите кол-во строк");
            var m = Utility.ReadIntConsole("Введите кол-во столбцов");

            var matrix = Utility.CreateMatrix(n, m);
            Utility.DisplayArr(matrix);

            Console.WriteLine($"Строка с максимальной суммой: {matrix.GetIndexRowSum() + 1}");
            Console.WriteLine($"Строка с минимальной суммой: {matrix.GetIndexRowSum(true) + 1}");
        }

        public override string GetName()
        {
            return "В прямоугольной матрице найти строку с наименьшей суммой элементов.";
        }
    }
}