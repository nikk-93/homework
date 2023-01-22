using Task;

Dictionary<int, string> task = new()
{
    {1, "Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве."},
    {2, "Задайте одномерный массив, заполненный случайными числами.Найдите сумму элементов, стоящих на нечётных позициях."},
    {3, "Задайте массив вещественных чисел.Найдите разницу между максимальным и минимальным элементов массива."},
    {4, "Кегли"},
    {5, "Двумерные массивы"},
    {6, "Рекурсия"},
};

Dictionary<int, MethodHandler> taskMethod = new()
{
    {1, CallTask1},
    {2, CallTask2},
    {3, CallTask3},
    {4, CallTask4},
    {5, CallTask5},
    {6, CallTask6},
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

void CallTask4()
{
    Console.WriteLine(task[4]);

    Console.Write("Введите количество кеглей: ");
    int n = int.Parse(Console.ReadLine() ?? "0");
    char[] skittles = new char[n];

    Console.Write("Введите количество бросков: ");
    int k = int.Parse(Console.ReadLine() ?? "0");

    var lr = new int[k, 2];

    Console.WriteLine($"Введите {k} пар(ы) чисел li, ri:");
    for (int i = 0; i < k; i++)
    {
        var numbers = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
        lr[i, 0] = int.Parse(numbers[0]);
        if (!(1 <= lr[i, 0] && lr[i, 0] <= n)) lr[i, 0] = 1;
        lr[i, 1] = int.Parse(numbers[1]);
        if (!(1 <= lr[i, 1] && lr[i, 1] <= n)) lr[i, 1] = 1;

        lr[i, 0]--;
        lr[i, 1]--;
    }

    for (int i = 0; i < skittles.Length; i++)
    {
        skittles[i] = 'I';

        for (int j = 0; j < lr.GetLength(0); j++)
        {
            if (!(lr[j, 0] <= i && i <= lr[j, 1])) continue;

            skittles[i] = '.';
            break;
        }
    }

    Utility.DisplayArr(skittles);
}

void CallTask5()
{
    Console.WriteLine(task[5]);

    Console.Write("Введите нечетное число: ");
    int n = int.Parse(Console.ReadLine() ?? "0");
    char[,] star = new char[n, n];

    int center = n / 2;

    for (int i = 0; i < star.GetLength(0); i++)
    {
        for (int j = 0; j < star.GetLength(1); j++)
        {
            if (i == center || j == center)
            {
                star[i, j] = '*';
                continue;
            }

            if (i == j || i == (n - 1) - j)
            {
                star[i, j] = '*';
                continue;
            }

            star[i, j] = '.';
        }
    }

    Utility.DisplayArr(star);
}

void CallTask6()
{
    Console.WriteLine(task[6]);

    Console.Write("Введите число: ");
    int a = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Введите степень: ");
    int n = int.Parse(Console.ReadLine() ?? "0");

    Console.WriteLine($"Возведение в степень: {Utility.Power(a, n)}");
    Console.WriteLine($"Возведение в степень (рекурсия): {Utility.PowerRecursion(a, n)}");
}