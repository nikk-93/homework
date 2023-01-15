internal class Program
{
    private static void Main(string[] args)
    {
        /////
        // Задача 10: Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает вторую цифру этого числа.
        // Задача 13: Напишите программу, которая выводит третью цифру заданного числа или сообщает, что третьей цифры нет.
        /////
        int number = new Random().Next(1, 200);
        Console.WriteLine("Число {0}: ", number);
        Console.Write("Какую цифру по порядку показать: ");
        int position = int.Parse(Console.ReadLine() ?? "0");

        int leftDig = GetDigitNumLeft(position, number);
        int rightDig = GetDigitNumRight(position, number);

        if (leftDig == -1)
            Console.WriteLine("Цифра слева не найдена");
        else
            Console.WriteLine("Цифра слева: {0}", leftDig);

        if (rightDig == -1)
            Console.WriteLine("Цифра справа не найдена");
        else
            Console.WriteLine("Цифра справа: {0}", rightDig);
    }

    public static int GetDigitNumLeft(int position, int number)
    {
        var digits = GetDigitsNumber(number);
        return digits.Count - position > -1 ? digits[digits.Count - position] : -1;
    }

    public static int GetDigitNumRight(int position, int number)
    {
        var digits = GetDigitsNumber(number);
        return digits.Count - position > -1 ? digits[position - 1] : -1;
    }

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
}