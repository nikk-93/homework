using Task;

Dictionary<int, string> task = new()
{
    {1, "Показать двумерный массив размером m×n заполненный вещественными числами"},
    {2, "Задать двумерный массив следующим правилом: Aₘₙ = m+n"},
    {3, "В двумерном массиве заменить элементы, у которых оба индекса чётные на их квадраты"},
    {4, "В матрице чисел найти сумму элементов главной диагонали"},
};

Dictionary<int, MethodHandler> taskMethod = new()
{
    {1, CallTask1},
    {2, CallTask2},
    {3, CallTask3},
    {4, CallTask4},
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

    Console.Write("Введите кол-во строк: ");
    int n = int.Parse(Console.ReadLine()!);
    Console.Write("Введите кол-во столбцов: ");
    int m = int.Parse(Console.ReadLine()!);

    var matrix = new double[n, m];
    var r = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            matrix[i, j] = r.NextDouble();
        }
    }

    Utility.DisplayArr(matrix);
}

void CallTask2()
{
    Console.WriteLine(task[2]);

    Console.Write("Введите кол-во строк: ");
    int n = int.Parse(Console.ReadLine()!);
    Console.Write("Введите кол-во столбцов: ");
    int m = int.Parse(Console.ReadLine()!);

    var matrix = new double[n, m];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            matrix[i, j] = i + j;
        }
    }

    Utility.DisplayArr(matrix);
}

void CallTask3()
{
    Console.WriteLine(task[2]);

    Console.Write("Введите кол-во строк: ");
    int n = int.Parse(Console.ReadLine()!);
    Console.Write("Введите кол-во столбцов: ");
    int m = int.Parse(Console.ReadLine()!);

    var matrix = new double[n, m];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            matrix[i, j] = i + j;
        }
    }

    Utility.DisplayArr(matrix);

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            if (i % 2 == 0 && j % 2 == 0)
                matrix[i, j] = Math.Pow(matrix[i, j], 2);
        }
    }

    Utility.DisplayArr(matrix);
}

void CallTask4()
{
    Console.WriteLine(task[4]);

    Console.Write("Введите кол-во строк: ");
    int n = int.Parse(Console.ReadLine()!);
    Console.Write("Введите кол-во столбцов: ");
    int m = int.Parse(Console.ReadLine()!);

    var matrix = new double[n, m];

    var sum = 0d;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            matrix[i, j] = i + j;
        }
    }

    Utility.DisplayArr(matrix);

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            if (i == j)
                sum += matrix[i, j];
        }
    }

    Console.WriteLine($"Сумма элементов главной диагонали: {sum}");
}
