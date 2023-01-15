internal class Program
{
    private static void Main(string[] args)
    {
        /////
        // 7. Дано число из отрезка [10, 99]. Показать наибольшую цифру числа
        /////
        int number = new Random().Next(10, 100);
        Console.WriteLine(number);
        Console.WriteLine(GetMaxDigit(number));
    }

    public static int GetMaxDigit(int number)
    {
        int maxDigit = int.MinValue;
        foreach (var item in GetDigitsNumber(number))
        {
            if (maxDigit < item)
                maxDigit = item;
        }

        return maxDigit;
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