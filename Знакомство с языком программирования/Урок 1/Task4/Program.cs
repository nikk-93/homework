internal class Program
{
    private static void Main(string[] args)
    {
        /////
        // 4. Показать четные числа от 1 до N
        /////
        Console.Write("Введите число: ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        for (int i = 1; i <= n; i++)
        {
            if (i % 2 == 0)
                Console.WriteLine("Число {0} - четное", i);
            else
                Console.WriteLine("Число {0} - нечетное", i);
        }
    }
}