using Command;
using Extended;

namespace Lesson8
{
    public class Task3 : TaskBase
    {
        public override void Execute()
        {
            var n = Utility.ReadIntConsole("Введите кол-во строк");
            var m = Utility.ReadIntConsole("Введите кол-во столбцов");
            var matrix = Utility.CreateMatrix(n, m);
            Utility.DisplayArr(matrix);
            Utility.DisplayArr(matrix.RemoveRowColMaxElement());
        }

        public override string GetName()
        {
            return "В двумерном массиве целых чисел. Удалить строку и столбец, на пересечении которых расположен наименьший элемент.";
        }
    }
}