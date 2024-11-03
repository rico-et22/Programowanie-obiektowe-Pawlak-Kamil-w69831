//using System.Linq;
// Napisz program obliczający wyróżnik delta i pierwiastki trójmianu kwadratowego
//zadanie1();

//static void zadanie1()
//{
//    double a = DoubleInput();
//    double b = DoubleInput();
//    double c = DoubleInput();
//    double delta, x1, x2;

//    if (a != 0)
//    {
//        delta = Math.Pow(b, 2) - (4 * a * c);
//        if (delta < 0) Console.WriteLine("brak rozwiazania w zbiorze liczb rzeczywistych");
//        else if (delta == 0)
//        {
//            x1 = -b / (2 * a);
//            Console.WriteLine("jedno rozwiazanie x1= " + x1);
//        }
//        else
//        {
//            x1 = (-b - Math.Sqrt(delta)) / (2 * a);
//            x2 = (-b + Math.Sqrt(delta)) / (2 * a);
//            Console.WriteLine("Dwa rozwiazania: \tx1= " + x1 + "\t x2= " + x2);
//        }
//    }
//    else
//    {
//        Console.WriteLine("to nie jest rownanie kwadratowe");
//    }
//}

//static double DoubleInput()
//{
//    Console.WriteLine("Podaj liczbe: ");
//    double input = Convert.ToDouble(Console.ReadLine());
//    return input;
//}