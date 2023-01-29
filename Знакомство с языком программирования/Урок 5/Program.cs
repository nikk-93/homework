using Task;

Dictionary<int, string> task = new()
{
    {1, "Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве."},
    {2, "Задайте одномерный массив, заполненный случайными числами.Найдите сумму элементов, стоящих на нечётных позициях."},
    {3, "Задайте массив вещественных чисел.Найдите разницу между максимальным и минимальным элементов массива."},
};

Dictionary<int, MethodHandler> taskMethod = new()
{
    {1, CallTask1},
    {2, CallTask2},
    {3, CallTask3},
};

while (true)
{
    Console.Clear();

    WriteTittle();

    string str = Console.ReadLine() ?? "0";
    if (!(int.TryParse(str, out int select) && task.ContainsKey(select) && taskMethod.TryGetValue(select, out var method)))
    {
        Console.WriteLine("Выход...");
        Console.ReadKey();
        return;
    }

    method();

    Console.WriteLine("Для продолжения нажмите любую клавишу...");
    Console.ReadKey();
}

void WriteTittle()
{
    foreach (var item in task)
    {
        Console.WriteLine($"{item.Key}. {item.Value}");
    }
    Console.WriteLine();
    Console.Write("Выберите задание: ");
}

void CallTask1()
{
    Console.WriteLine(task[1]);

    Console.Write("Введите размер массива: ");
    int n = int.Parse(Console.ReadLine() ?? "0");
    int[] arr = new int[n];
    int evenCount = 0;

    var r = new Random();

    for (int i = 0; i < n; i++)
    {
        arr[i] = r.Next(100, 1000);
    }

    Utility.DisplayArr(arr);

    for (int i = 0; i < n; i++)
    {
        if (arr[i] % 2 == 0) evenCount++;
    }

    Console.WriteLine($"Четных: {evenCount}");
}

void CallTask2()
{
    Console.WriteLine(task[2]);

    Console.Write("Введите размер массива: ");
    int n = int.Parse(Console.ReadLine() ?? "0");
    int[] arr = new int[n];
    int sumUnevenIndex = 0;

    var r = new Random();

    for (int i = 0; i < n; i++)
    {
        arr[i] = r.Next(1, 100);
    }

    Utility.DisplayArr(arr);

    for (int i = 0; i < n; i++)
    {
        if (i % 2 != 0) sumUnevenIndex += arr[i];
    }

    Console.WriteLine($"Сумма {sumUnevenIndex}");
}

void CallTask3()
{
    Console.WriteLine(task[3]);

    Console.Write("Введите размер массива: ");
    int n = int.Parse(Console.ReadLine() ?? "0");
    int[] arr = new int[n];
    int maxNum = int.MinValue;
    int minNum = int.MaxValue;

    var r = new Random();

    for (int i = 0; i < n; i++)
    {
        arr[i] = r.Next(1, 100);
    }

    Utility.DisplayArr(arr);

    for (int i = 0; i < n; i++)
    {
        if (maxNum < arr[i]) maxNum = arr[i];
        if (minNum < arr[i]) minNum = arr[i];
    }

    Console.WriteLine($"Max: {maxNum}, Min: {minNum}, Разница: {maxNum - minNum}");
}