internal class Program
{
    private static void Main(string[] args)
    {
        /////
        // 4. Найти расстояние между точками в пространстве 2D/3D
        /////
        Console.Write("Введите размерность: ");
        int dimension = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Введите координаты первой точки (разделять ';'): ");
        var pointFrom = ParseCoordinatesPoint(dimension, Console.ReadLine() ?? "0");

        Console.Write("Введите координаты второй точки (разделять ';'): ");
        var pointTo = ParseCoordinatesPoint(dimension, Console.ReadLine() ?? "0");

        Console.WriteLine(GetEuclideanDistance(dimension, pointFrom, pointTo));
    }

    public static double[] ParseCoordinatesPoint(int dimension, string raw)
    {
        double[] pointCoordinate = new double[dimension];

        var rawCoordinate = raw.Replace(" ", "").Split(';', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < dimension; i++)
        {
            if (rawCoordinate.Length > i)
                pointCoordinate[i] = Convert.ToDouble(rawCoordinate[i]);
            else
                pointCoordinate[i] = 0d;
        }

        return pointCoordinate;
    }

    public static double GetEuclideanDistance(double[] pointFrom, double[] pointTo)
    {
        return GetEuclideanDistance(pointFrom.Length, pointFrom, pointTo);
    }

    public static double GetEuclideanDistance(int dimension, double[] pointFrom, double[] pointTo)
    {
        double sum = 0;

        for (int i = 0; i < dimension; i++)
        {
            sum += Math.Pow(pointTo[i] - pointFrom[i], 2);
        }

        return Math.Sqrt(sum);
    }
}