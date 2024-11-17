using Lab2;

// obiekt klasy lub inaczej instancja klasy
//Osoba osoba = new Osoba();
//osoba.FirstName = "Jan";
//osoba.LastName = "Nowak";
//osoba.Age = 20;
//osoba.View();

//Osoba osoba1 = new Osoba("Janina","Kowalska",23);
//osoba1.View();

// ZADANIE 1
//CreatePerson();
// ZADANIE 2
//CreateBankAccount();
// dziedziczenie
Dziedziczenie();

void Dziedziczenie()
{
    Student student = new Student("Kamil", "Pawlak", 21, "w69831");
    student.View();
    student.ViewStudent();
}

static void CreatePerson()
{
    Console.WriteLine("Podaj imię: ");
    string firstName = Console.ReadLine();
    Console.WriteLine("Podaj nazwisko: ");
    string lastName = Console.ReadLine();
    Console.WriteLine("Podaj wiek: ");
    int age = int.Parse(Console.ReadLine());
    Osoba osoba=new Osoba(firstName, lastName, age);
    osoba.View();
}

static void CreateBankAccount()
{
    BankAccount konto = new BankAccount("Jan Kowalski", 1000);
    konto.Wplata(500);
    konto.View();
    konto.Wyplata(200);
    konto.View();
    Console.WriteLine($"Saldo: {konto.Saldo}");
}
