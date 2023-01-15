internal class Program
{
    private static void Main(string[] args)
    {
        /////
        // 5. Показать последнюю цифру трёхзначного числа
        /////
        Console.Write("Введите число: ");
        int number = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine(GetDigitNum(1, number));
    }

    public static int GetDigitNum(int digit, int number)
    {
        int pow10 = digit / 10;
        var digits = GetDigitsNumber(number);
        return digits[pow10];
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