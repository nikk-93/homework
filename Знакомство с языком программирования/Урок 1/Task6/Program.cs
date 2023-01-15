internal class Program
{
    private static void Main(string[] args)
    {
        /////
        // 6. Показать вторую цифру трёхзначного числа
        /////
        Console.Write("Введите число: ");
        int number = int.Parse(Console.ReadLine() ?? "0");
        // Position от 1
        Console.WriteLine(GetDigitNumLeft(2, number));
        Console.WriteLine(GetDigitNumRight(2, number));
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