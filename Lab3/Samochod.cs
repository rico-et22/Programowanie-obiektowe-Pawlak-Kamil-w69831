using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Samochod
    {
        private string brand;
        private string model;
        private string body;
        private string color;
        private int year;
        private int mileage;

        public Samochod()
        {
            Console.WriteLine("Nowy samochód:");
            do
            {
                Console.Write("Podaj markę: ");
                brand = Console.ReadLine();
            } while (brand == "");

            do
            {
                Console.Write("Podaj model: ");
                model = Console.ReadLine();
            } while (model == "");

            do
            {
                Console.Write("Podaj nadwozie: ");
                body = Console.ReadLine();
            } while (body == "");

            do
            {
                Console.Write("Podaj kolor: ");
                color = Console.ReadLine();
            } while (color == "");

            bool yearCorrect;
            do
            {
                Console.Write("Podaj rok produkcji: ");
                yearCorrect = int.TryParse(Console.ReadLine(), out mileage);
                if (!yearCorrect)
                {
                    Console.WriteLine("Rok produkcji - liczba całkowita");
                }
            } while (!yearCorrect);

            bool mileageCorrect;
            do
            {
                Console.Write("Podaj przebieg w km: ");
                mileageCorrect = int.TryParse(Console.ReadLine(), out mileage);
                if (!mileageCorrect || mileage < 0)
                {
                    Console.WriteLine("Przebieg - liczba całkowita, nie może być ujemna");
                    mileageCorrect = false;
                }
            } while (!mileageCorrect);
        }

        public Samochod(string brand, string model, string body, string color, int year, int mileage)
        {
            this.body = body;
            this.brand = brand;
            this.model = model;
            this.color = color;
            this.year = year;
            this.mileage = mileage;
        }

        public virtual void View()
        {
            Console.WriteLine("----- Informacje o samochodzie -----");
            Console.WriteLine($"Marka: {brand}");
            Console.WriteLine($"Model: {model}");
            Console.WriteLine($"Nadwozie: {body}");
            Console.WriteLine($"Kolor: {color}");
            Console.WriteLine($"Rok produkcji: {year}");
            Console.WriteLine($"Przebieg: {mileage} km");
        }
    }
}
