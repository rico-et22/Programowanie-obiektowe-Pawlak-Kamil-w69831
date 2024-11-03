//using System.Linq;
//static void zadanie2()
//{
//    menu();
//}

//static void menu()
//{
//ViewMenu:
//    Console.WriteLine("----- Kalkulator -----");
//    Console.WriteLine("1. Suma \n 2. Różnica \n 3. Iloczyn \n 4. Iloraz \n 5. Potęgowanie \n 6. Pierwiastek \n 7. Funkcje trygonometryczne \n 8. Wyjście");
//    Console.WriteLine("Wybierz opcje");
//    int choice = Convert.ToInt32(Console.ReadLine());
//    switch (choice)
//    {
//        case 1: Total(); break;
//        case 2: Difference(); break;
//        case 3: ProductNumber(); break;
//        case 4: EquationNumber(); break;
//        case 5: PotentiationNumber(); break;
//        case 6: SquareNumber(); break;
//        case 7: Trigonometry(); break; // zamiana wartosci (Input * Math.PI) * 100;
//        case 8: Close(); break;
//        default: Console.WriteLine("Bledy wybor, wybierz jeszcze raz opcje."); goto ViewMenu;
//    }
//}

//static void Total()
//{
//    double a = DoubleInput();
//    double b = DoubleInput();
//    Console.WriteLine($"Suma {a}+{b}={a + b}");
//}

//static void Difference()
//{
//    double a = DoubleInput();
//    double b = DoubleInput();
//    Console.WriteLine($"Różnica {a}-{b}={a - b}");
//}

//static void ProductNumber()
//{
//    double a = DoubleInput();
//    double b = DoubleInput();
//    Console.WriteLine($"Iloczyn {a}*{b}={a * b}");
//}

//static void EquationNumber()
//{
//    double a = DoubleInput();
//    double b = DoubleInput();
//    Console.WriteLine($"Iloraz {a}/{b}={a / b}");
//}

//static void PotentiationNumber()
//{
//    double a = DoubleInput();
//    double b = DoubleInput();
//    Console.WriteLine($"potęga {a}^{b}={Math.Pow(a, b)}");
//}

//static void SquareNumber()
//{
//    double a = DoubleInput();
//    Console.WriteLine($"pierwiastek {a}={Math.Sqrt(a)}");
//}

//static void Trigonometry()
//{
//    double input = DoubleInput();
//    double a = (input * Math.PI) / 180;
//    Console.WriteLine($"sin {input}={Math.Sin(a)}");
//    Console.WriteLine($"cos {input}={Math.Cos(a)}");
//    Console.WriteLine($"tg {input}={Math.Tan(a)}");
//    Console.WriteLine($"ctg {input}={1 / Math.Tan(a)}");
//}

//static void Close()
//{
//    Console.WriteLine("Koniec programu");
//    System.Environment.Exit(1);
//}

//static double DoubleInput()
//{
//    Console.WriteLine("Podaj liczbe: ");
//    double input = Convert.ToDouble(Console.ReadLine());
//    return input;
//}

//zadanie2();
