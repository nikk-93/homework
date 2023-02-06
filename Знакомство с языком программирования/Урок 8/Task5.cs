using Command;
using Extended;

namespace Lesson8
{
    public class Task5 : TaskBase
    {
        public override void Execute()
        {
            var n = Utility.ReadIntConsole("Введите кол-во строк");
            Utility.DisplayPascalTriangle(n);
        }

        public override string GetName()
        {
            return "Показать треугольник Паскаля. Сделать вывод в виде равнобедренного треугольника.";
        }
    }
}