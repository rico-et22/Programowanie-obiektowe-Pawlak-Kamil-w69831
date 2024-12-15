using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal abstract class Osoba
    {
        private string firstName;
        private string lastName;
        private string pesel;

        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Pesel { get { return pesel; } set { pesel = value; } }
        public int Age
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Pesel) || Pesel.Length != 11)
                {
                    throw new InvalidOperationException("Nieprawidłowy numer PESEL");
                }

                int year = int.Parse(Pesel.Substring(0, 2));
                int month = int.Parse(Pesel.Substring(2, 2));
                int day = int.Parse(Pesel.Substring(4, 2));

                int century;

                if (month > 20)
                {
                    century = 2000;
                    month -= 20;
                }
                else
                {
                    century = 1900;
                }

                int fullYear = century + year;

                DateTime dateOfBirth;
                try
                {
                    dateOfBirth = new DateTime(fullYear, month, day);
                }
                catch
                {
                    throw new InvalidOperationException("Numer PESEL zawiera nieprawidłową datę");
                }

                DateTime today = DateTime.Today;
                int age = today.Year - dateOfBirth.Year;
                if (today < dateOfBirth.AddYears(age))
                {
                    age--;
                }

                return age;
            }
        }
        public string Gender
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Pesel) || Pesel.Length != 11)
                {
                    throw new InvalidOperationException("Nieprawidłowy numer PESEL");
                }

                return Convert.ToInt32(Pesel[9]) % 2 == 0 ? "kobieta" : "mężczyzna";
            }
        }
        public abstract void GetEducationInfo();
        public abstract void GetFullName();
        public abstract void CanGoAloneToHome();
    }
}
