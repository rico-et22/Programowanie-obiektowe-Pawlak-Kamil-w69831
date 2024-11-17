using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Student: Osoba
    {
        private string NrAlbumu { get; set; }

        public Student(string firstName, string lastName, int age, string nrAlbumu):base(firstName,lastName,age)
        {
            NrAlbumu = nrAlbumu;
        }

        public void ViewStudent()
        {
            View();
            Console.WriteLine($"Nr albumu:{NrAlbumu}");
        }
    }
}
