//class Zwierze
//{
//    public virtual void DajGlos()
//    {
//        Console.WriteLine("Zwierze wydaje dźwięk");
//    }
//}

//class Pies : Zwierze
//{
//    public override void DajGlos()
//    {
//        Console.WriteLine("Pies wydaje dźwięk");
//    }
//}

//class Kot : Zwierze
//{
//    public override void DajGlos()
//    {
//        Console.WriteLine("Kot wydaje dźwięk");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Zwierze zwierze = new Pies();
//        Zwierze zwierze1 = new Kot();

//        zwierze.DajGlos();
//        zwierze1.DajGlos();
//    }
//}

//abstract class Figura
//{
//    public abstract double ObliczPole();

//    public void Info()
//    {
//        Console.WriteLine("To jest figura geometryczna");
//    }
//}

//class Kwadrat : Figura
//{
//    private double bok;

//    public Kwadrat(double bok)
//    {
//        this.bok = bok;
//    }

//    public override double ObliczPole()
//    {
//        return bok * bok;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Figura figura = new Kwadrat(5);
//        figura.Info();
//        Console.WriteLine($"Pole kwadratu: {figura.ObliczPole()}");
//    }
//}

//interface IZwierze
//{
//    void DajGlos();
//}

//class Pies : IZwierze
//{
//    public void DajGlos()
//    {
//        Console.WriteLine("Pies wydaje dzwiek");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        IZwierze zwierze = new Pies();
//        zwierze.DajGlos();
//    }
//}