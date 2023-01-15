internal class Program
{
    private static void Main(string[] args)
    {
        /////
        // 9. Выяснить, кратно ли число заданному, если нет, вывести остаток.
        /////
        Console.Write("Введите делимое число: ");
        int fnum = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Введите делитель число: ");
        int snum = int.Parse(Console.ReadLine() ?? "0");

        int mod = fnum % snum;

        if (mod == 0)
            Console.WriteLine("Частное: {0}", fnum / snum);
        else
            Console.WriteLine("Остаток: {0}", mod);
    }
}