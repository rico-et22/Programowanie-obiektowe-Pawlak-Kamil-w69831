using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.Data.SqlClient;

// Przed uruchomieniem obowiązkowo utwórz bazę danych w SQL Server uruchamiając skrypt z pliku InitSQL.sql
// oraz dostosuj connection string w DatabaseManager.

namespace ATMProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataAccess dbManager = new DatabaseManager();
            ATM atm = new ATM(dbManager);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== BANKOMAT ===");
                Console.WriteLine("1. Włóż kartę");
                Console.WriteLine("2. Wyjście");
                Console.Write("Wybierz opcję: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Podaj numer karty: ");
                        string cardNumber = Console.ReadLine();
                        PaymentCard card = dbManager.GetCardByNumber(cardNumber);
                        if (card == null)
                        {
                            Console.WriteLine("Nie znaleziono karty.");
                            break;
                        }

                        // Sprawdzenie, czy typ karty jest akceptowany przez bankomat
                        if (!atm.AcceptedCardTypes.Contains(card.PaymentSystem))
                        {
                            Console.WriteLine($"Karta typu {card.PaymentSystem} nie jest akceptowana przez ten bankomat.");
                            break;
                        }

                        if (card.IsBlocked)
                        {
                            Console.WriteLine("Karta jest zablokowana.");
                            break;
                        }

                        bool authenticated = false;
                        for (int i = 0; i < 3 && !authenticated; i++)
                        {
                            Console.Write("Podaj PIN: ");
                            string pin = Console.ReadLine();
                            if (card.VerifyPIN(pin))
                            {
                                authenticated = true;
                            }
                            else
                            {
                                Console.WriteLine("Niepoprawny PIN.");
                            }
                        }
                        if (!authenticated)
                        {
                            Console.WriteLine("Karta została zablokowana po 3 nieudanych próbach.");
                            dbManager.UpdateCard(card);
                            break;
                        }

                        Customer customer = new Customer("Klient", card, atm);
                        customer.ShowMenu();
                        break;

                    case "!maintenance":
                        Console.Write("Podaj hasło administratora: ");
                        string adminPass = Console.ReadLine();
                        Administrator admin = new Administrator("Admin", atm);
                        if (admin.Authenticate(adminPass))
                        {
                            admin.ShowMenu();
                        }
                        else
                        {
                            Console.WriteLine("Niepoprawne hasło administratora.");
                        }
                        break;

                    case "2":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Niepoprawna opcja.");
                        break;
                }
            }
            Console.WriteLine("Dziękujemy za skorzystanie z naszych usług.");
        }
    }
}