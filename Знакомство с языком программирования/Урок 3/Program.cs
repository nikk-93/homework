using Task;

Dictionary<int, string> task = new()
{
    {1, "Найти кубы чисел от 1 до N"},
    {2, "Найти сумму чисел от 1 до А"},
    {3, "Возведите число А в натуральную степень B используя цикл"},
    {4, "Подсчитать сумму цифр в числе"},
    {5, "Написать программу вычисления произведения чисел от 1 до N"},
    {6, "Показать кубы чисел, заканчивающихся на четную цифру"},
    {7, "Задать массив из 8 элементов, заполненных нулями и единицами вывести их на экран"},
    {8, "Определить, присутствует ли в заданном массиве, некоторое число"},
    {9, "Задать массив, заполнить случайными положительными трёхзначными числами. Показать количество нечетных/четных чисел"},
    {10, "В одномерном массиве из 123 чисел найти количество элементов из отрезка [10,99]"},
    {11, "Найти сумму чисел одномерного массива стоящих на нечетной позиции"},
    {12, "Найти произведение пар чисел в одномерном массиве. Парой считаем первый и последний элемент, второй и предпоследний и т.д."},
    {13, "В Указанном массиве вещественных чисел найдите разницу между максимальным и минимальным элементом"},
};

Dictionary<int, MethodHandler> taskMethod = new()
{
    {1, CallTask1},
    {2, CallTask2},
    {3, CallTask3},
    {4, CallTask4},
    {5, CallTask5},
    {6, CallTask6},
    {7, CallTask7},
    {8, CallTask8},
    {9, CallTask9},
    {10, CallTask10},
    {11, CallTask11},
    {12, CallTask12},
    {13, CallTask13},
};

List<int> GetDigitsNumber(int number)
{
    int num = number;
    List<int> digits = new List<int>();
    int modnum;

    do
    {
        modnum = num % 10;
        digits.Add(modnum);
        num /= 10;
    } while (num > 0);

    return digits;
}

void DisplayArr(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i] + " ");
    }

    Console.WriteLine();
}

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

    Console.Write("Введите число: ");
    int number = int.Parse(Console.ReadLine() ?? "0");

    for (int i = 1; i <= number; i++)
    {
        Console.WriteLine(Math.Pow(i, 3));
    }
}

void CallTask2()
{
    Console.WriteLine(task[2]);

    int sum = 0;
    Console.Write("Введите число: ");
    int number = int.Parse(Console.ReadLine() ?? "0");

    for (int i = 1; i <= number; i++)
    {
        sum += i;
    }

    Console.WriteLine(sum);
}

void CallTask3()
{
    Console.WriteLine(task[3]);

    int res = 1;
    Console.Write("Введите число: ");
    int number = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Введите степень: ");
    int pow = int.Parse(Console.ReadLine() ?? "0");

    for (int i = 1; i <= pow; i++)
    {
        res *= number;
    }

    Console.WriteLine(res);
}

void CallTask4()
{
    Console.WriteLine(task[4]);

    int sum = 0;
    Console.Write("Введите число: ");
    int number = int.Parse(Console.ReadLine() ?? "0");

    var digits = GetDigitsNumber(number);

    for (int i = 0; i < digits.Count; i++)
    {
        sum += digits[i];
    }

    Console.WriteLine(sum);
}

void CallTask5()
{
    Console.WriteLine(task[5]);

    int res = 1;
    Console.Write("Введите число: ");
    int number = int.Parse(Console.ReadLine() ?? "0");

    for (int i = 1; i <= number; i++)
    {
        res *= i;
    }

    Console.WriteLine(res);
}

void CallTask6()
{
    Console.WriteLine(task[6]);

    Console.Write("Введите число: ");
    int number = int.Parse(Console.ReadLine() ?? "0");

    for (int i = 1; i <= number; i++)
    {
        if (Math.Pow(i, 3) % 10 == 2)
            Console.WriteLine(i);
    }
}

void CallTask7()
{
    Console.WriteLine(task[7]);

    Console.Write("Введите размер массива: ");
    int n = int.Parse(Console.ReadLine() ?? "0");
    int[] arr = new int[n];
    var r = new Random();

    for (int i = 0; i < n; i++)
    {
        arr[i] = r.Next(0, 2);
    }

    DisplayArr(arr);
}

void CallTask8()
{
    Console.WriteLine(task[8]);

    Console.Write("Введите размер массива: ");
    int n = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Введите число: ");
    int number = int.Parse(Console.ReadLine() ?? "0");
    int[] arr = new int[n];
    var r = new Random();

    for (int i = 0; i < n; i++)
    {
        arr[i] = r.Next(0, 100);
    }

    DisplayArr(arr);

    for (int i = 0; i < n; i++)
    {
        if (arr[i] == number)
        {
            Console.WriteLine($"Число {number} присутствует в массиве");
            break;
        }
    }
}

void CallTask9()
{
    Console.WriteLine(task[9]);

    Console.Write("Введите размер массива: ");
    int n = int.Parse(Console.ReadLine() ?? "0");
    int[] arr = new int[n];
    int evenCount = 0;
    int unevenCount = 0;

    var r = new Random();

    for (int i = 0; i < n; i++)
    {
        arr[i] = r.Next(100, 1000);
    }

    DisplayArr(arr);

    for (int i = 0; i < n; i++)
    {
        if (arr[i] % 2 == 0) evenCount++;
        else unevenCount++;
    }

    Console.WriteLine($"Четных: {evenCount}\nНечетных{unevenCount}");
}

void CallTask10()
{
    Console.WriteLine(task[10]);

    Console.Write("Введите размер массива: ");
    int n = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Введите начало интервала: ");
    int a = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Введите конец интервала: ");
    int b = int.Parse(Console.ReadLine() ?? "0");
    int[] arr = new int[n];
    int countElementInterval = 0;

    var r = new Random();

    for (int i = 0; i < n; i++)
    {
        arr[i] = r.Next(a / 2, b * 2 + 1);
    }

    DisplayArr(arr);

    for (int i = 0; i < n; i++)
    {
        if (a <= arr[i] && arr[i] <= b) countElementInterval++;
    }

    Console.WriteLine($"Количество элементов в интервале: {countElementInterval}");
}

void CallTask11()
{
    Console.WriteLine(task[11]);

    Console.Write("Введите размер массива: ");
    int n = int.Parse(Console.ReadLine() ?? "0");
    int[] arr = new int[n];
    int sumUnevenIndex = 0;

    var r = new Random();

    for (int i = 0; i < n; i++)
    {
        arr[i] = r.Next(1, 100);
    }

    DisplayArr(arr);

    for (int i = 0; i < n; i++)
    {
        if (i % 2 != 0) sumUnevenIndex += arr[i];
    }

    Console.WriteLine($"Сумма {sumUnevenIndex}");
}

void CallTask12()
{
    Console.WriteLine(task[12]);

    Console.Write("Введите размер массива: ");
    int n = int.Parse(Console.ReadLine() ?? "0");
    int[] arr = new int[n];

    var r = new Random();

    for (int i = 0; i < n; i++)
    {
        arr[i] = r.Next(100, 1000);
    }

    DisplayArr(arr);

    for (int i = 0; i < n / 2; i++)
    {
        Console.WriteLine($"Произведение {i} и {n - 1 - i} элементов: {arr[i] * arr[n - 1 - i]}");
    }
}

void CallTask13()
{
    Console.WriteLine(task[13]);

    Console.Write("Введите размер массива: ");
    int n = int.Parse(Console.ReadLine() ?? "0");
    int[] arr = new int[n];
    int maxNum = int.MinValue;
    int minNum = int.MaxValue;

    var r = new Random();

    for (int i = 0; i < n; i++)
    {
        arr[i] = r.Next(100, 1000);
    }

    DisplayArr(arr);

    for (int i = 0; i < n; i++)
    {
        if (maxNum < arr[i]) maxNum = arr[i];
        if (minNum < arr[i]) minNum = arr[i];
    }

    Console.WriteLine($"Max: {maxNum}, Min: {minNum}, Разница: {maxNum - minNum}");
}