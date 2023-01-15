internal class Program
{
    private static void Main(string[] args)
    {
        /////
        // 8. Удалить вторую цифру трёхзначного числа
        /////
        int number = new Random().Next(100, 1000);
        Console.WriteLine(number);
        Console.WriteLine(DeleteDigitLeft(2, number));
        Console.WriteLine(DeleteDigitRight(2, number));
    }

    public static int DeleteDigitLeft(int position, int number)
    {
        var digits = GetDigitsOfNumber(number);
        digits.RemoveAt(digits.Count - position);

        return GetNumberFromDigits(digits);
    }

    public static int DeleteDigitRight(int position, int number)
    {
        var digits = GetDigitsOfNumber(number);
        digits.RemoveAt(position - 1);

        return GetNumberFromDigits(digits);
    }

    public static int GetNumberFromDigits(List<int> digits)
    {
        int newNumber = 0;

        for (int i = 0; i < digits.Count; i++)
        {
            newNumber += digits[i] * Convert.ToInt32(Math.Pow(10, i));
        }

        return newNumber;
    }

    public static List<int> GetDigitsOfNumber(int number)
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