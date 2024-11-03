//using System.Linq;
//static void zadanie4()
//{
//    double[] list = new double[10];
//    for (int i = 0; i < 10; i++)
//    {
//        double input = DoubleInput();
//        list[i] = input;
//    }

//    Console.WriteLine($"Suma: {list.Sum()}");
//    Console.WriteLine($"Iloczyn: {list.Aggregate(1, (double a, double b) => a * b)}");
//    Console.WriteLine($"Średnia: {list.Average()}");
//    Console.WriteLine($"Min: {list.Min()}");
//    Console.WriteLine($"Max: {list.Max()}");
//}

//zadanie4();

//static double DoubleInput()
//{
//    Console.WriteLine("Podaj liczbe: ");
//    double input = Convert.ToDouble(Console.ReadLine());
//    return input;
//}