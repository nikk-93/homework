using Task;

Dictionary<int, string> task = new()
{
    {1, "Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве."},
    {2, "Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях."},
    {3, "Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива."},
    {4, "Найти точку пересечения двух прямых заданных уравнением y = k1 * x + b1, y = k2 * x + b2, b1 k1 и b2 и k2 заданы"},
    {5, "Написать программу масштабирования фигуры"},
};

Dictionary<int, MethodHandler> taskMethod = new()
{
    {1, CallTask1},
    {2, CallTask2},
    {3, CallTask3},
    {4, CallTask4},
    {5, CallTask5},
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
        if ((i + 1) % 2 != 0) sumUnevenIndex += arr[i];
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
        if (minNum > arr[i]) minNum = arr[i];
    }

    Console.WriteLine($"Max: {maxNum}, Min: {minNum}, Разница: {maxNum - minNum}");
}

void CallTask4()
{
    Console.WriteLine(task[4]);

    Console.Write("Введите k1: ");
    var k1 = double.Parse(Console.ReadLine()!);
    Console.Write("Введите b1: ");
    var b1 = double.Parse(Console.ReadLine()!);

    Console.Write("Введите k2: ");
    var k2 = double.Parse(Console.ReadLine()!);
    Console.Write("Введите b2: ");
    var b2 = double.Parse(Console.ReadLine()!);

    if (k1 == k2)
        if (b1 == b2)
            Console.WriteLine("Прямые одинаковы");
        else
            Console.WriteLine("Прямые не пересекаются");
    else
    {
        var x = (b2 - b1) / (k1 - k2);
        var y = k1 * x + b1;

        Console.WriteLine($"Прямые пересекаются в точке ({x},{y})");
    }
}

void CallTask5()
{
    Console.WriteLine(task[5]);

    Console.Write("Введите вершины фигуры: ");
    var split = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    Console.Write("Введите коэф: ");
    var k = double.Parse(Console.ReadLine()!);

    var coords = new (double, double)[split.Length];

    for (int i = 0; i < split.Length; i++)
    {
        var point = split[i].Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
        coords[i] = (double.Parse(point[0]), double.Parse(point[1]));
    }

    for (int i = 0; i < coords.Length; i++)
    {
        coords[i].Item1 *= k;
        coords[i].Item2 *= k;
    }

    for (int i = 0; i < coords.Length; i++)
    {
        Console.Write($"({coords[i].Item1},{coords[i].Item2})");
    }

    Console.WriteLine();
}