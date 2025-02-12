using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public class AmexCard : PaymentCard
    {
        public AmexCard(string cardNumber, string pin, Account account)
            : base(cardNumber, pin, account)
        {
            PaymentSystem = PaymentSystem.AmericanExpress;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("American Express Card: " + CardNumber);
        }
    }
}
