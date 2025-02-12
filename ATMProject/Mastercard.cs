using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public class Mastercard : PaymentCard
    {
        public Mastercard(string cardNumber, string pin, Account account)
            : base(cardNumber, pin, account)
        {
            PaymentSystem = PaymentSystem.Mastercard;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Mastercard: " + CardNumber);
        }
    }
}
