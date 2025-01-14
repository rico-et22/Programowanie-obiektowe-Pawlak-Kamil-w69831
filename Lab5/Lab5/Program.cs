using System;
// zadanie 1

enum Operation
{
    Add = 1,
    Subtract,
    Multiply,
    Divide,
}

class Program
{
    static double? Add(double a, double b)
    {
        try
        {
            return a + b;
        }
        catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    static double? Subtract(double a, double b)
    {
        try
        {
            return a - b;
        }
        catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    static double? Multiply(double a, double b)
    {
        try
        {
            return a * b;
        }
        catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    static double? Divide(double a, double b)
    {
        try
        {
            if (b == 0) throw new DivideByZeroException();
            return a / b;
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine("Nie można dzielić przez zero");
        }
        catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    static void Main(string[] args)
    {
        double? a = null, b = null;
        Operation? selection = null;
        List<double> results = new List<double>();

        do
        {
            do
            {
                if (results.Count > 0)
                {
                    Console.WriteLine("Historia:");
                    results.ForEach(r => Console.WriteLine(r.ToString()));
                }
                Console.WriteLine("Podaj typ operacji:");
                Console.WriteLine("1- dodawanie:");
                Console.WriteLine("2- odejmowanie");
                Console.WriteLine("3- mnożenie");
                Console.WriteLine("4- dzielenie");
                Console.WriteLine("0- zakończ");

                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input == 0) return;
                    if (Enum.IsDefined(typeof(Operation), input)) selection = (Operation)input;
                    else Console.WriteLine("Nieprawidłowy wybór");
                }
                catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
                catch (Exception ex) { Console.WriteLine(ex.Message); };
            } while (selection == null);

            do
            {
                Console.WriteLine("Podaj a:");
                try
                {
                    a = double.Parse(Console.ReadLine());
                }
                catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
                catch (Exception ex) { Console.WriteLine(ex.Message); };
            } while (a == null);

            do
            {
                Console.WriteLine("Podaj b:");
                try
                {
                    b = double.Parse(Console.ReadLine());
                }
                catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
                catch (Exception ex) { Console.WriteLine(ex.Message); };
            } while (b == null);

            if (selection.HasValue && a != null && b != null)
            {
                double? result;
                try
                {
                    switch (selection)
                    {
                        case Operation.Add:
                            result = Add((double)a, (double)b);
                            break;
                        case Operation.Subtract:
                            result = Subtract((double)a, (double)b);
                            break;
                        case Operation.Multiply:
                            result = Multiply((double)a, (double)b);
                            break;
                        case Operation.Divide:
                            result = Divide((double)a, (double)b);
                            break;
                        default: throw new ArgumentOutOfRangeException();
                    }
                }
                catch (Exception ex) { result = null; Console.WriteLine(ex.Message); };
                if (result.HasValue)
                {
                    Console.WriteLine($"{result.Value}");
                    results.Add(result.Value);
                }
            }
            selection = null;
            a = null;
            b = null;
        } while (true);
    }
}