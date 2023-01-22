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

    switch (Console.ReadLine() ?? "")
    {
        case "1":
            // 1. Найти кубы чисел от 1 до N
            CallTask1();
            break;
        case "2":
            // 2. Найти сумму чисел от 1 до А
            CallTask2();
            break;
        case "3":
            // 3. Возведите число А в натуральную степень B используя цикл
            CallTask3();
            break;
        case "4":
            // 4. Подсчитать сумму цифр в числе
            CallTask4();
            break;
        case "5":
            // 5. Написать программу вычисления произведения чисел от 1 до N
            CallTask5();
            break;
        case "6":
            // 6. Показать кубы чисел, заканчивающихся на четную цифру
            CallTask6();
            break;
        case "7":
            // 7. Задать массив из 8 элементов, заполненных нулями и единицами вывести их на экран
            CallTask7();
            break;
        case "8":
            // 8. Определить, присутствует ли в заданном массиве, некоторое число
            CallTask8();
            break;
        case "9":
            // 9. Задать массив, заполнить случайными положительными трёхзначными числами. Показать количество нечетных\четных чисел
            CallTask9();
            break;
        case "10":
            // 10.В одномерном массиве из 123 чисел найти количество элементов из отрезка [10,99]
            CallTask10();
            break;
        case "11":
            // 11.Найти сумму чисел одномерного массива стоящих на нечетной позиции
            CallTask11();
            break;
        case "12":
            // 12. Найти произведение пар чисел в одномерном массиве. Парой считаем первый и последний элемент, второй и предпоследний и т.д.
            CallTask12();
            break;
        case "13":
            // 13. В Указанном массиве вещественных чисел найдите разницу между максимальным и минимальным элементом
            CallTask13();
            break;
        default:
            Console.WriteLine("Выход...");
            Console.ReadKey();
            return;
    }

    Console.WriteLine("Для продолжения нажмите любую клавишу...");
    Console.ReadKey();
}

void WriteTittle()
{
    Console.WriteLine("\n1. Найти кубы чисел от 1 до N");
    Console.WriteLine("\n2. Найти сумму чисел от 1 до А");
    Console.WriteLine("\n3. Возведите число А в натуральную степень B используя цикл");
    Console.WriteLine("\n4. Подсчитать сумму цифр в числе");
    Console.WriteLine("\n5. Написать программу вычисления произведения чисел от 1 до N");
    Console.WriteLine("\n6. Показать кубы чисел, заканчивающихся на четную цифру");
    Console.WriteLine("\n7. Задать массив из 8 элементов, заполненных нулями и единицами вывести их на экран");
    Console.WriteLine("\n8. Определить, присутствует ли в заданном массиве, некоторое число");
    Console.WriteLine("\n9. Задать массив, заполнить случайными положительными трёхзначными числами. Показать количество нечетных/четных чисел");
    Console.WriteLine("\n10. В одномерном массиве из 123 чисел найти количество элементов из отрезка [10,99]");
    Console.WriteLine("\n11. Найти сумму чисел одномерного массива стоящих на нечетной позиции");
    Console.WriteLine("\n12. Найти произведение пар чисел в одномерном массиве. Парой считаем первый и последний элемент, второй и предпоследний и т.д.");
    Console.WriteLine("\n13. В Указанном массиве вещественных чисел найдите разницу между максимальным и минимальным элементом");
    Console.WriteLine();
    Console.Write("Выберите задание: ");
}

void CallTask1()
{
    Console.WriteLine("\n1. Найти кубы чисел от 1 до N");

    Console.Write("Введите число: ");
    int number = int.Parse(Console.ReadLine() ?? "0");

    for (int i = 1; i <= number; i++)
    {
        Console.WriteLine(Math.Pow(i, 3));
    }
}

void CallTask2()
{
    Console.WriteLine("\n2. Найти сумму чисел от 1 до А");

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
    Console.WriteLine("\n3. Возведите число А в натуральную степень B используя цикл");

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
    Console.WriteLine("\n4. Подсчитать сумму цифр в числе");

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
    Console.WriteLine("\n5. Написать программу вычисления произведения чисел от 1 до N");

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
    Console.WriteLine("\n6. Показать кубы чисел, заканчивающихся на четную цифру");

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
    Console.WriteLine("\n7. Задать массив из 8 элементов, заполненных нулями и единицами вывести их на экран");

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
    Console.WriteLine("\n8. Определить, присутствует ли в заданном массиве, некоторое число");

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
    Console.WriteLine("\n9. Задать массив, заполнить случайными положительными трёхзначными числами. Показать количество нечетных/четных чисел");

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
    Console.WriteLine("\n10. В одномерном массиве из 123 чисел найти количество элементов из отрезка [10,99]");

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
    Console.WriteLine("\n11. Найти сумму чисел одномерного массива стоящих на нечетной позиции");

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
    Console.WriteLine("\n12. Найти произведение пар чисел в одномерном массиве. Парой считаем первый и последний элемент, второй и предпоследний и т.д.");

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
    Console.WriteLine("\n13. В Указанном массиве вещественных чисел найдите разницу между максимальным и минимальным элементом");

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