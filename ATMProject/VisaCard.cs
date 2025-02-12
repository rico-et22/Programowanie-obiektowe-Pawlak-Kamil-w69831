using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public class VisaCard : PaymentCard
    {
        public VisaCard(string cardNumber, string pin, Account account)
            : base(cardNumber, pin, account)
        {
            PaymentSystem = PaymentSystem.Visa;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Visa Card: " + CardNumber);
        }
    }
}
