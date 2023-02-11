using Command;
using Extended;

namespace Lesson9
{
    public class Task1 : TaskBase
    {
        public override void Execute()
        {
            var n = Utility.ReadIntConsole("Введите число");
            WriteNumbers(n);
        }

        public void WriteNumbers(int n)
        {
            if (n <= 0)
                return;
            else
                Console.WriteLine(n);

            WriteNumbers(n - 1);
        }

        public override string GetName()
        {
            return "Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от N до 1. Выполнить с помощью рекурсии.";
        }
    }
}