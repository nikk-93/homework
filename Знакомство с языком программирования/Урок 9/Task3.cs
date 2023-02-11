using Command;
using Extended;

namespace Lesson9
{
    public class Task3 : TaskBase
    {
        public override void Execute()
        {
            var m = Utility.ReadIntConsole("Введите число m");
            var n = Utility.ReadIntConsole("Введите число n");

            Console.WriteLine($"Функция Аккермана: {Utility.AckermannFunction(m, n)}");
        }

        public override string GetName()
        {
            return "Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.";
        }
    }
}