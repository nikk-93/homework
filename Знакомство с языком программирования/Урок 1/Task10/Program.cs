internal class Program
{
    private static void Main(string[] args)
    {
        /////
        // 10. Найти третью цифру числа или сообщить, что её нет
        /////
        Console.Write("Введите число: ");
        int number = int.Parse(Console.ReadLine() ?? "0");
        // Position от 1

        int leftDig = GetDigitNumLeft(3, number);
        int rightDig = GetDigitNumRight(3, number);

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