using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Student
    {
        private string firstName;
        private string lastName;
        double[] grades = new double[10];
        int countGrades = 0;

        public double SredniaOcen
        {
            get
            {
                if (countGrades == 0 || grades==null) return 0;
                double sum = 0;
                for (int i=0; i<countGrades; i++)
                {
                    sum += grades[i];
                }
                return sum/countGrades;
            }
        }


        public Student(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public void View()
        {
            Console.WriteLine($"Imię:{firstName}, Nazwisko: {lastName}");
        }

        public void DodajOcene(double ocena)
        {
            if (ocena < 2 || ocena > 5)
            {
                Console.WriteLine("Ocena musi być z przedziału 2-5");
                return;
            }
            if (grades==null)
            {
                Console.WriteLine("Tablica nie może być pusta");
                return;
            }
            if (countGrades >= grades.Length)
            {
                Console.WriteLine("Nie można dodać więcej ocen. Tablica jest pełna");
                return;
            }
            grades[countGrades] = ocena;
            countGrades++;
            Console.WriteLine($"Dodano ocenę {ocena:F1}. Aktualna średnia: {SredniaOcen:F2}");
        }
    }
}
