internal class Program
{
    private static void Main(string[] args)
    {
        /////
        // 2. По заданному номеру дня недели вывести его название
        /////
        Dictionary<int, string> weekDays = new Dictionary<int, string>()
        {
            { 0, "Понедельник" },
            { 1, "Вторник" },
            { 2, "Среда" },
            { 3, "Четверг" },
            { 4, "Пятница" },
            { 5, "Суббота" },
            { 6, "Воскресенье" },
        };

        Console.Write("Введите номер дня недели: ");
        int numWeekDay = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine(weekDays[numWeekDay]);
    }
}