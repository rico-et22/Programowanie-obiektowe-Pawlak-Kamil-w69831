using System;
using System.Linq;
using System.Security.Cryptography;
// zadanie 1

//enum Operation
//{
//    Add = 1,
//    Subtract,
//    Multiply,
//    Divide,
//}

//class Program
//{
//    static double? Add(double a, double b)
//    {
//        try
//        {
//            return a + b;
//        }
//        catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
//        catch (Exception e)
//        {
//            Console.WriteLine(e.Message);
//        }
//        return null;
//    }
//    static double? Subtract(double a, double b)
//    {
//        try
//        {
//            return a - b;
//        }
//        catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
//        catch (Exception e)
//        {
//            Console.WriteLine(e.Message);
//        }
//        return null;
//    }
//    static double? Multiply(double a, double b)
//    {
//        try
//        {
//            return a * b;
//        }
//        catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
//        catch (Exception e)
//        {
//            Console.WriteLine(e.Message);
//        }
//        return null;
//    }
//    static double? Divide(double a, double b)
//    {
//        try
//        {
//            if (b == 0) throw new DivideByZeroException();
//            return a / b;
//        }
//        catch (DivideByZeroException e)
//        {
//            Console.WriteLine("Nie można dzielić przez zero");
//        }
//        catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
//        catch (Exception e)
//        {
//            Console.WriteLine(e.Message);
//        }
//        return null;
//    }
//    static void Main(string[] args)
//    {
//        double? a = null, b = null;
//        Operation? selection = null;
//        List<double> results = new List<double>();

//        do
//        {
//            do
//            {
//                if (results.Count > 0)
//                {
//                    Console.WriteLine("Historia:");
//                    results.ForEach(r => Console.WriteLine(r.ToString()));
//                }
//                Console.WriteLine("Podaj typ operacji:");
//                Console.WriteLine("1- dodawanie:");
//                Console.WriteLine("2- odejmowanie");
//                Console.WriteLine("3- mnożenie");
//                Console.WriteLine("4- dzielenie");
//                Console.WriteLine("0- zakończ");

//                try
//                {
//                    int input = int.Parse(Console.ReadLine());
//                    if (input == 0) return;
//                    if (Enum.IsDefined(typeof(Operation), input)) selection = (Operation)input;
//                    else Console.WriteLine("Nieprawidłowy wybór");
//                }
//                catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
//                catch (Exception ex) { Console.WriteLine(ex.Message); };
//            } while (selection == null);

//            do
//            {
//                Console.WriteLine("Podaj a:");
//                try
//                {
//                    a = double.Parse(Console.ReadLine());
//                }
//                catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
//                catch (Exception ex) { Console.WriteLine(ex.Message); };
//            } while (a == null);

//            do
//            {
//                Console.WriteLine("Podaj b:");
//                try
//                {
//                    b = double.Parse(Console.ReadLine());
//                }
//                catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
//                catch (Exception ex) { Console.WriteLine(ex.Message); };
//            } while (b == null);

//            if (selection.HasValue && a != null && b != null)
//            {
//                double? result;
//                try
//                {
//                    switch (selection)
//                    {
//                        case Operation.Add:
//                            result = Add((double)a, (double)b);
//                            break;
//                        case Operation.Subtract:
//                            result = Subtract((double)a, (double)b);
//                            break;
//                        case Operation.Multiply:
//                            result = Multiply((double)a, (double)b);
//                            break;
//                        case Operation.Divide:
//                            result = Divide((double)a, (double)b);
//                            break;
//                        default: throw new ArgumentOutOfRangeException();
//                    }
//                }
//                catch (Exception ex) { result = null; Console.WriteLine(ex.Message); };
//                if (result.HasValue)
//                {
//                    Console.WriteLine($"{result.Value}");
//                    results.Add(result.Value);
//                }
//            }
//            selection = null;
//            a = null;
//            b = null;
//        } while (true);
//    }
//}

// zadanie 2

//enum OrderStatus
//{
//    Oczekujące = 1,
//    Przyjęte,
//    Zrealizowane,
//    Anulowane
//}

//enum Operation
//{
//    View = 1,
//    Change,
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Dictionary<int, List<string>> orderContents = new Dictionary<int, List<string>>() {
//            {1, ["masło", "mleko"] },
//            {2, ["chleb", "szynka"] }
//        };

//        Dictionary<int, OrderStatus> orderStatuses = new Dictionary<int, OrderStatus>() {
//            {1, OrderStatus.Przyjęte },
//            {2, OrderStatus.Zrealizowane }
//        };

//        Operation? selection = null;

//        do
//        {
//            do
//            {
//                Console.WriteLine("Podaj typ operacji:");
//                Console.WriteLine("1- lista zamówień:");
//                Console.WriteLine("2- zmiana statusu");
//                Console.WriteLine("0- zakończ");

//                try
//                {
//                    int input = int.Parse(Console.ReadLine());
//                    if (input == 0) return;
//                    if (Enum.IsDefined(typeof(Operation), input)) selection = (Operation)input;
//                    else Console.WriteLine("Nieprawidłowy wybór");
//                }
//                catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
//                catch (Exception ex) { Console.WriteLine(ex.Message); };
//            } while (selection == null);

//            if (selection == Operation.View)
//            {
//                foreach (var item in orderStatuses)
//                {
//                    Console.WriteLine($"Zamówienie {item.Key}: ");
//                    Console.WriteLine($"Status {item.Value}");
//                    Console.WriteLine($"Zawartość {String.Join(",", orderContents[item.Key])}");
//                }
//            }

//            else if (selection == Operation.Change)
//            {
//                int? orderId = null;
//                do
//                {
//                    try
//                    {
//                        Console.WriteLine("Podaj id zamówienia:");
//                        int input = int.Parse(Console.ReadLine());
//                        if (orderStatuses.ContainsKey(input)) orderId = input;
//                        else throw new KeyNotFoundException();
//                    }
//                    catch (KeyNotFoundException ex) { Console.WriteLine("Nie znaleziono takiego zamówienia"); }
//                    catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
//                    catch (Exception ex) { Console.WriteLine(ex.Message); };
//                } while (orderId == null);

//                OrderStatus? newStatus = null;
//                do
//                {
//                    try
//                    {
//                        Console.WriteLine("Podaj nowy status:");
//                        Console.WriteLine("1- Oczekujące");
//                        Console.WriteLine("2- Przyjęte");
//                        Console.WriteLine("3- Zrealizowane");
//                        Console.WriteLine("4- Anulowane");
//                        int input = int.Parse(Console.ReadLine());
//                        if (Enum.IsDefined(typeof(OrderStatus), input))
//                        {
//                            if ((OrderStatus)input != orderStatuses[(int)orderId]) newStatus = (OrderStatus)input;
//                            else throw new ArgumentException();
//                        }
//                        else Console.WriteLine("Nieprawidłowy wybór");
//                    }
//                    catch (ArgumentException ex) { Console.WriteLine("Status nie może być taki sam"); }
//                    catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
//                    catch (Exception ex) { Console.WriteLine(ex.Message); };
//                } while (newStatus == null);
//                if (newStatus != null && orderId != null) orderStatuses[(int)orderId] = (OrderStatus)newStatus;
//            }

//            selection = null;
//        } while (true);
//    }
//}

// zadanie 3

enum Color
{
    Czerwony,
    Niebieski,
    Zielony,
    Żółty,
    Fioletowy
}

class Program
{
    static void Main(string[] args)
    {
        List<Color> availableColors = new List<Color>([
            Color.Czerwony,
            Color.Niebieski,
            Color.Zielony,
            Color.Fioletowy,
            Color.Żółty
            ]);
        Random r = new Random();
        int randomNumber = r.Next(0, availableColors.Count);
        Color randomColor = availableColors[randomNumber];
        Color? guessedColor = null;

        do
        {
            try
            {
                Console.WriteLine("Podaj kolor:");
                Console.WriteLine(String.Join(",", availableColors));
                string input = Console.ReadLine();
                if (int.TryParse(input, out _))
                {
                    throw new ArgumentException();
                }
                if (Enum.TryParse(input, out Color selectedColor))
                {
                    if (selectedColor == randomColor) guessedColor = selectedColor;
                    else Console.WriteLine("zły wybór");
                }
                else throw new ArgumentException();
            }
            catch (ArgumentException ex) { Console.WriteLine("Nieprawidłowy kolor"); }
            catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
            catch (Exception ex) { Console.WriteLine(ex.Message); };
        } while (guessedColor == null);

        Console.WriteLine("Udało się!");
    }
}