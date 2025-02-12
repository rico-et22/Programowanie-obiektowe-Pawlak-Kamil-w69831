using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public class Administrator : User
    {
        private ATM Atm;
        public Administrator(string username, ATM atm)
            : base(username)
        {
            Atm = atm;
        }

        public bool Authenticate(string password)
        {
            string storedPassword = Atm.DataAccess.GetSetting("AdminPassword");
            return password == storedPassword;
        }

        public override void ShowMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== Panel Administratora ===");
                Console.WriteLine("0. Zmiana ustawień administratora (hasło)");
                Console.WriteLine("1. Zmiana salda gotówki bankomatu");
                Console.WriteLine("2. Generowanie historii wypłat");
                Console.WriteLine("3. Wyświetlenie zapasów gotówki");
                Console.WriteLine("4. Wyjście");
                Console.Write("Wybierz opcję: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        Console.Write("Podaj nowe hasło administratora: ");
                        string newPass = Console.ReadLine();
                        Atm.DataAccess.UpdateSetting("AdminPassword", newPass);
                        Console.WriteLine("Hasło administratora zostało zaktualizowane.");
                        break;
                    case "1":
                        Console.Write("Podaj nominał: ");
                        if (!int.TryParse(Console.ReadLine(), out int denomination))
                        {
                            Console.WriteLine("Niepoprawny nominał.");
                            break;
                        }
                        Console.Write("Podaj liczbę banknotów do dodania: ");
                        if (!int.TryParse(Console.ReadLine(), out int count))
                        {
                            Console.WriteLine("Niepoprawna liczba.");
                            break;
                        }
                        Atm.CashReserve.AddCash(denomination, count);
                        Atm.DataAccess.UpdateCashReserveSetting(denomination, Atm.CashReserve.Notes[denomination]);
                        Console.WriteLine("Gotówka została dodana.");
                        break;
                    case "2":
                        Atm.DisplayTransactionHistory();
                        break;
                    case "3":
                        Atm.CashReserve.DisplayReserve();
                        break;
                    case "4":
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
