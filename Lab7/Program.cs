using CsvHelper;
using Lab7;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;

// zadanie 1

//CREATE DATABASE Clients;
//GO

//USE Clients;
//CREATE TABLE Clients
//(
//    Id INT PRIMARY KEY IDENTITY(1,1),
//    FirstName NVARCHAR(100) NOT NULL,
//    LastName NVARCHAR(100) NOT NULL,
//    Email NVARCHAR(100) NOT NULL,
//    Phone NVARCHAR(50) NOT NULL,
//    RegistrationDate DATETIME NOT NULL DEFAULT GETDATE()
//);

//class Program
//{
//    private static string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Clients;Integrated Security=True;Encrypt=False";
//    private static DatabaseManager _dbManager = new DatabaseManager(_connectionString);
//    private static ClientManager _clientManager = new ClientManager(_dbManager);

//    public static void Main(string[] args)
//    {
//        bool exit = false;
//        while (!exit)
//        {
//            Console.WriteLine("\n=== MENU ===");
//            Console.WriteLine("1. Dodaj klienta");
//            Console.WriteLine("2. Pokaż klientów");
//            Console.WriteLine("3. Zmień dane klienta");
//            Console.WriteLine("4. Usuń klienta");
//            Console.WriteLine("5. Szukaj po nazwisku");
//            Console.WriteLine("0. Wyjdź");
//            Console.Write("Wybierz opcję: ");

//            string choice = Console.ReadLine();
//            switch (choice)
//            {
//                case "1":
//                    AddClient();
//                    break;
//                case "2":
//                    DisplayClients();
//                    break;
//                case "3":
//                    UpdateClient();
//                    break;
//                case "4":
//                    DeleteClient();
//                    break;
//                case "5":
//                    SearchClientsByLastName();
//                    break;
//                case "0":
//                    exit = true;
//                    break;
//                default:
//                    Console.WriteLine("Nieprawidłowy wybór.");
//                    break;
//            }
//        }
//    }

//    private static void AddClient()
//    {
//        Console.Write("Imię: ");
//        string firstName = Console.ReadLine();

//        Console.Write("Nazwisko: ");
//        string lastName = Console.ReadLine();

//        Console.Write("Email: ");
//        string email = Console.ReadLine();

//        Console.Write("Telefon min. 9 znaków: ");
//        string phone = Console.ReadLine();

//        var newClient = new Client
//        {
//            FirstName = firstName,
//            LastName = lastName,
//            Email = email,
//            Phone = phone,
//            RegistrationDate = DateTime.Now
//        };

//        try
//        {
//            _clientManager.AddClient(newClient);
//            Console.WriteLine("Dodano pomyślnie.");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Błąd: {ex.Message}");
//        }
//    }

//    private static void DisplayClients()
//    {
//        Console.Write("Numer strony (domyślnie 1): ");
//        if (!int.TryParse(Console.ReadLine(), out int pageNumber)) pageNumber = 1;

//        Console.Write("Ilość na stronę (domyślnie 10): ");
//        if (!int.TryParse(Console.ReadLine(), out int pageSize)) pageSize = 10;

//        var clients = _clientManager.GetAllClients(pageSize, pageNumber);
//        if (clients.Count == 0)
//        {
//            Console.WriteLine("Nie znaleziono.");
//        }
//        else
//        {
//            foreach (var client in clients)
//            {
//                Console.WriteLine(
//                    $"[{client.Id}] {client.FirstName} {client.LastName}, " +
//                    $"Email: {client.Email}, Tel: {client.Phone}, " +
//                    $"zarejestrowano: {client.RegistrationDate}");
//            }
//        }
//    }

//    private static void UpdateClient()
//    {
//        Console.Write("Numer klienta: ");
//        if (!int.TryParse(Console.ReadLine(), out int id))
//        {
//            Console.WriteLine("Niepoprawne id!");
//            return;
//        }

//        // For simplicity, ask for all fields:
//        Console.Write("Nowe imię: ");
//        string firstName = Console.ReadLine();

//        Console.Write("Nowe nazwisko: ");
//        string lastName = Console.ReadLine();

//        Console.Write("Nowy email: ");
//        string email = Console.ReadLine();

//        Console.Write("Nowy nr tel min. 9 znaków: ");
//        string phone = Console.ReadLine();

//        var updatedClient = new Client
//        {
//            Id = id,
//            FirstName = firstName,
//            LastName = lastName,
//            Email = email,
//            Phone = phone
//        };

//        try
//        {
//            _clientManager.UpdateClient(updatedClient);
//            Console.WriteLine("Zaktualizowano.");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Błąd: {ex.Message}");
//        }
//    }

//    private static void DeleteClient()
//    {
//        Console.Write("Podaj id klienta do usunięcia: ");
//        if (!int.TryParse(Console.ReadLine(), out int id))
//        {
//            Console.WriteLine("Niepoprawne id!");
//            return;
//        }

//        try
//        {
//            _clientManager.DeleteClient(id);
//            Console.WriteLine("Usunięto klienta.");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Błąd: {ex.Message}");
//        }
//    }

//    private static void SearchClientsByLastName()
//    {
//        Console.Write("Wpisz nazwisko ");
//        string lastName = Console.ReadLine();

//        var results = _clientManager.SearchClientsByLastName(lastName);
//        if (results.Count == 0)
//        {
//            Console.WriteLine("Nie znaleziono.");
//        }
//        else
//        {
//            foreach (var client in results)
//            {
//                Console.WriteLine(
//                    $"[{client.Id}] {client.FirstName} {client.LastName}, " +
//                    $"Email: {client.Email}, Tel: {client.Phone}, " +
//                    $"zarejestrowano: {client.RegistrationDate}");
//            }
//        }
//    }
//}

// zadanie 2

class Program
{
    private static readonly string filePath = "clients.csv";

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("=== zarządzanie klientami ===");
            Console.WriteLine("1. Dodaj");
            Console.WriteLine("2. Pokaż");
            Console.WriteLine("3. Zmień");
            Console.WriteLine("4. Usuń");
            Console.WriteLine("5. Wyjdź");
            Console.Write("Opcja: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    AddClient();
                    break;
                case "2":
                    DisplayClients();
                    break;
                case "3":
                    UpdateClient();
                    break;
                case "4":
                    DeleteClient();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Niepoprawna opcja.");
                    break;
            }
            Console.WriteLine();
        }
    }

    static List<ClientTask2> ReadClients()
    {
        if (!File.Exists(filePath))
        {
            return new List<ClientTask2>();
        }

        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            try
            {
                var records = csv.GetRecords<ClientTask2>().ToList();
                return records;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
                return new List<ClientTask2>();
            }
        }
    }

    static void WriteClients(List<ClientTask2> clients)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(clients);
        }
    }

    static void AddClient()
    {
        List<ClientTask2> clients = ReadClients();

        ClientTask2 newClient = new ClientTask2();
        // Automatyczne przypisanie Id (max istniejące Id + 1)
        int maxId = clients.Any() ? clients.Max(c => c.Id) : 0;
        newClient.Id = maxId + 1;

        Console.Write("Imię: ");
        newClient.FirstName = Console.ReadLine();

        Console.Write("Nazwisko: ");
        newClient.LastName = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();
        if (!ValidationHelper.IsValidEmail(email))
        {
            Console.WriteLine("Zły format email.");
            return;
        }
        newClient.Email = email;

        Console.Write("Nr tel min. 9 znaków: ");
        string phone = Console.ReadLine();
        if (!ValidationHelper.IsValidPhone(phone))
        {
            Console.WriteLine("Zły format nr telefonu.");
            return;
        }
        newClient.Phone = phone;

        clients.Add(newClient);
        WriteClients(clients);

        Console.WriteLine("Dodano pomyślnie.");
    }

    static void DisplayClients()
    {
        List<ClientTask2> clients = ReadClients();

        if (clients.Count == 0)
        {
            Console.WriteLine("Nie znaleziono.");
            return;
        }

        Console.WriteLine("Klienci:");
        foreach (var client in clients)
        {
            Console.WriteLine($"Id: {client.Id}, Imię: {client.FirstName}, Nazwisko: {client.LastName}, Email: {client.Email}, Tel: {client.Phone}");
        }
    }
    static void UpdateClient()
    {
        List<ClientTask2> clients = ReadClients();

        Console.Write("Id klienta: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Nieprawidłowy id.");
            return;
        }

        var client = clients.FirstOrDefault(c => c.Id == id);
        if (client == null)
        {
            Console.WriteLine("Nie znaleziono.");
            return;
        }

        Console.Write($"Imię (zostaw puste by zostawić '{client.FirstName}'): ");
        string newFirstName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newFirstName))
        {
            client.FirstName = newFirstName;
        }

        Console.Write($"Nazwisko (zostaw puste by zostawić '{client.LastName}'): ");
        string newLastName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newLastName))
        {
            client.LastName = newLastName;
        }

        Console.Write($"Email (zostaw puste by zostawić '{client.Email}'): ");
        string newEmail = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newEmail))
        {
            if (!ValidationHelper.IsValidEmail(newEmail))
            {
                Console.WriteLine("Niepoprawny email.");
                return;
            }
            client.Email = newEmail;
        }

        Console.Write($"Tel min. 9 znaków (zostaw puste by zostawić '{client.Phone}'): ");
        string newPhone = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newPhone))
        {
            if (!ValidationHelper.IsValidPhone(newPhone))
            {
                Console.WriteLine("Niepoprawny nr telefonu.");
                return;
            }
            client.Phone = newPhone;
        }

        WriteClients(clients);
        Console.WriteLine("Zaktualizowano pomyślnie.");
    }
    static void DeleteClient()
    {
        List<ClientTask2> clients = ReadClients();

        Console.Write("Id klienta: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Niepoprawny id.");
            return;
        }

        var client = clients.FirstOrDefault(c => c.Id == id);
        if (client == null)
        {
            Console.WriteLine("Nie znaleziono.");
            return;
        }

        clients.Remove(client);
        WriteClients(clients);
        Console.WriteLine("Usunięto pomyślnie.");
    }
}