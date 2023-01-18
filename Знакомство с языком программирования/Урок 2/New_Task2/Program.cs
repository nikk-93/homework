internal class Program
{
    private static void Main(string[] args)
    {
        /////
        // 2. По двум заданным числам проверять является ли одно квадратом другого
        /////
        Console.Write("Введите первое число: ");
        int fnum = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Введите второе число: ");
        int snum = int.Parse(Console.ReadLine() ?? "0");

        if (snum * snum == fnum)
            Console.WriteLine("Число {0} является квадратом {1}", fnum, snum);
        else
            Console.WriteLine("Число {0} не является квадратом {1}", fnum, snum);
    }
}