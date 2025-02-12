using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(string cardNumber, decimal amount)
        {
            CardNumber = cardNumber;
            Amount = amount;
            Date = DateTime.Now;
        }
    }
}
