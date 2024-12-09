using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Licz
    {
        private double value = 0;

        public void Dodaj(double d) { value += d; }
        public void Odejmij(double d) { value -= d; }

        public void GetValue()
        {
            Console.WriteLine(value);
        }

        public Licz(double initialValue)
        {
            value = initialValue;
        }
    }
}