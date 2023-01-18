internal class Program
{
    private static void Main(string[] args)
    {
        /////
        // 3. Задать номер четверти, показать диапазоны для возможных координат
        /////
        Console.Write("Введите номер четверти: ");
        int numQuarter = int.Parse(Console.ReadLine() ?? "0");

        switch (numQuarter)
        {
            case 1:
                Console.WriteLine("Допустимые значения x: [0, +inf)");
                Console.WriteLine("Допустимые значения y: [0, +inf)");
                break;
            case 2:
                Console.WriteLine("Допустимые значения x: [0, +inf)");
                Console.WriteLine("Допустимые значения y: [0, -inf)");
                break;
            case 3:
                Console.WriteLine("Допустимые значения x: [0, -inf)");
                Console.WriteLine("Допустимые значения y: [0, -inf)");
                break;
            case 4:
                Console.WriteLine("Допустимые значения x: [0, -inf)");
                Console.WriteLine("Допустимые значения y: [0, +inf)");
                break;
            default:
                Console.WriteLine("Четверть не определена");
                break;
        }
    }
}