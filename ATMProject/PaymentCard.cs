using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public enum PaymentSystem
    {
        Visa,
        AmericanExpress,
        VisaElectron,
        Mastercard
    }

    public abstract class PaymentCard
    {
        public string CardNumber { get; set; }
        public string PIN { get; set; }
        public PaymentSystem PaymentSystem { get; protected set; }
        public int FailedAttempts { get; set; }
        public bool IsBlocked { get; set; }
        public Account Account { get; set; }

        public PaymentCard(string cardNumber, string pin, Account account)
        {
            CardNumber = cardNumber;
            PIN = pin;
            Account = account;
            FailedAttempts = 0;
            IsBlocked = false;
        }

        public abstract void DisplayInfo();

        public bool VerifyPIN(string pin)
        {
            if (IsBlocked)
                return false;

            if (PIN == pin)
            {
                FailedAttempts = 0;
                return true;
            }
            else
            {
                FailedAttempts++;
                if (FailedAttempts >= 3)
                {
                    IsBlocked = true;
                }
                return false;
            }
        }
    }
}
