using Command;
using Extended;

namespace Lesson9
{
    public class Task2 : TaskBase
    {
        public override void Execute()
        {
            var n = Utility.ReadIntConsole("Введите число n");
            var m = Utility.ReadIntConsole("Введите число m");

            Console.WriteLine($"Сумма от n до m: {Utility.SumArithmeticProgression(n, m)}");
        }

        public override string GetName()
        {
            return "Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.";
        }
    }
}