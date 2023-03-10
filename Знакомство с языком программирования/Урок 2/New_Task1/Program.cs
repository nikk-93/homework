internal class Program
{
    private static void Main(string[] args)
    {
        /////
        // 1. Дано число обозначающее день недели. Выяснить является номер дня недели выходным
        /////
        Dictionary<int, string> weekDays = new()
        {
            { 0, "Понедельник" },
            { 1, "Вторник" },
            { 2, "Среда" },
            { 3, "Четверг" },
            { 4, "Пятница" },
            { 5, "Суббота" },
            { 6, "Воскресенье" },
        };

        Dictionary<int, string> weekEnds = new()
        {
            { 5, "Суббота" },
            { 6, "Воскресенье" },
        };

        Console.Write("Введите номер дня недели: ");
        int numWeekDay = int.Parse(Console.ReadLine() ?? "0") - 1;
        weekDays.TryGetValue(numWeekDay, out string? nameWeekDay);

        if (nameWeekDay != null)
        {
            Console.WriteLine(nameWeekDay);
            weekEnds.TryGetValue(numWeekDay, out string? nameWeekEndDay);
            Console.WriteLine(nameWeekEndDay != null ? "выходной" : "не выходной");
        }
        else
            Console.WriteLine("Нет такого дня");
    }
}