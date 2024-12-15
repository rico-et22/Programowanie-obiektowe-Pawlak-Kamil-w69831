
//enum Kolor
//{
//    Czerwony, //0
//    Zielony, //1
//    Żółty, //2
//    Niebieski = 10,
//    Czarny //11
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Kolor mojKolor = Kolor.Czerwony;
//        Console.WriteLine($"Wybrany kolor: {mojKolor}");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        try
//        {
//            Console.WriteLine("Podaj licznik:");
//            int licznik = int.Parse(Console.ReadLine());
//            Console.WriteLine("Podaj mianownik:");
//            int mianownik = int.Parse(Console.ReadLine());

//            int wynik = licznik / mianownik;
//            Console.WriteLine($"Wynik dzielenia: {wynik}");
//        }
//        catch (DivideByZeroException ex)
//        {
//            Console.WriteLine("Nie można dzielić przez zero");
//            Console.WriteLine(ex.Message);
//        }
//        catch (FormatException ex)
//        {
//            Console.WriteLine("Nieprawidłowy format danych");
//            Console.WriteLine(ex.Message);
//        }
//        finally
//        {
//            Console.WriteLine("Wykonał się blok finally");
//        }
//    }
//}

class MojeWyjatki : Exception
{
    public MojeWyjatki(string message) : base(message)
    {

    }

}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            SprawdzLiczbe(-23);
        }
        catch (MojeWyjatki e)
        {
            { Console.WriteLine(e.Message); }
        }

        static void SprawdzLiczbe(int liczba)
        {
            if (liczba <= 0)
            {
                throw new MojeWyjatki("Liczba musi byc wieksza od zera!");
            }
        }
    }
}