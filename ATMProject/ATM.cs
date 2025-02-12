using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public class ATM
    {
        public CashReserve CashReserve { get; set; }
        public List<Transaction> Transactions { get; set; }
        public IDataAccess DataAccess { get; set; }

        public List<PaymentSystem> AcceptedCardTypes { get; set; }

        public ATM(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
            CashReserve = new CashReserve(DataAccess.GetCashReserveSettings());
            Transactions = DataAccess.GetTransactions();
            string acceptedTypesStr = DataAccess.GetSetting("AcceptedCardTypes");
            AcceptedCardTypes = ParseAcceptedCardTypes(acceptedTypesStr);
        }

        private List<PaymentSystem> ParseAcceptedCardTypes(string settingValue)
        {
            List<PaymentSystem> accepted = new List<PaymentSystem>();
            var tokens = settingValue.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string? token in tokens)
            {
                if (Enum.TryParse(token.Trim(), true, out PaymentSystem ps))
                {
                    accepted.Add(ps);
                }
            }
            return accepted;
        }

        public void ProcessWithdrawal(PaymentCard card, decimal amount)
        {
            if (card.IsBlocked)
            {
                Console.WriteLine("Karta jest zablokowana.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Niepoprawna kwota.");
                return;
            }

            if (!card.Account.Withdraw(amount))
            {
                Console.WriteLine("Niewystarczające środki na koncie.");
                return;
            }

            if (!CashReserve.CanDispense(amount))
            {
                Console.WriteLine("Bankomat nie posiada wystarczającej ilości gotówki.");
                card.Account.Deposit(amount);
                return;
            }

            if (CashReserve.Dispense(amount, out Dictionary<int, int> dispensed))
            {
                Transaction trans = new Transaction(card.CardNumber, amount);
                Transactions.Add(trans);
                DataAccess.InsertTransaction(trans);
                Console.WriteLine("Wypłata udana. Wypłacone nominały:");
                foreach (var d in dispensed)
                {
                    Console.WriteLine($"{d.Key} PLN: {d.Value} szt.");
                }
            }
            else
            {
                Console.WriteLine("Nie można wypłacić żądanej kwoty przy użyciu dostępnych nominałów.");
                card.Account.Deposit(amount);
            }
            DataAccess.UpdateCard(card);
        }

        public void DisplayTransactionHistory()
        {
            Console.WriteLine("Historia wypłat:");
            foreach (Transaction t in Transactions)
            {
                Console.WriteLine($"{t.Date}: Karta {t.CardNumber} - Kwota: {t.Amount} PLN");
            }
        }
    }
}
