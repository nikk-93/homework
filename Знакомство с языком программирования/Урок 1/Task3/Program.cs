internal class Program
{
    private static void Main(string[] args)
    {
        /////
        // 3. Выяснить является ли число чётным
        /////
        Console.Write("Введите число: ");
        int number = int.Parse(Console.ReadLine() ?? "0");

        if (number % 2 == 0)
            Console.WriteLine("Число {0} - четное", number);
        else
            Console.WriteLine("Число {0} - нечетное", number);
    }
}


// 6. Показать вторую цифру трёхзначного числа
// 7. Дано число из отрезка [10, 99]. Показать наибольшую цифру числа
// 8. Удалить вторую цифру трёхзначного числа
// 9. Выяснить, кратно ли число заданному, если нет, вывести остаток.
// 10. Найти третью цифру числа или сообщить, что её нет