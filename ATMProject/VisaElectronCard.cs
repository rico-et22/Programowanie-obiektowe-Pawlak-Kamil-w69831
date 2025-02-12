using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public class VisaElectronCard : PaymentCard
    {
        public VisaElectronCard(string cardNumber, string pin, Account account)
            : base(cardNumber, pin, account)
        {
            PaymentSystem = PaymentSystem.VisaElectron;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Visa Electron Card: " + CardNumber);
        }
    }
}
