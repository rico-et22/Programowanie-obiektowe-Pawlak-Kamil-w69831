using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public class Customer : User
    {
        public PaymentCard Card { get; set; }
        public ATM Atm { get; set; }

        public Customer(string username, PaymentCard card, ATM atm)
            : base(username)
        {
            Card = card;
            Atm = atm;
        }

        public override void ShowMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== Menu Klienta ===");
                Console.WriteLine("1. Wypłata gotówki");
                Console.WriteLine("2. Sprawdzenie salda");
                Console.WriteLine("3. Wyjście");
                Console.Write("Wybierz opcję: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Podaj kwotę do wypłaty: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                        {
                            Atm.ProcessWithdrawal(Card, amount);
                        }
                        else
                        {
                            Console.WriteLine("Niepoprawna kwota.");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Aktualne saldo: " + Card.Account.Balance + " PLN");
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Niepoprawna opcja.");
                        break;
                }
            }
        }
    }
}
