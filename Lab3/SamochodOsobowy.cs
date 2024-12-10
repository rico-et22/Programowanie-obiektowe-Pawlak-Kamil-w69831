using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class SamochodOsobowy : Samochod
    {
        private double weight;
        private double displacement;
        private int persons;

        public SamochodOsobowy() : base()
        {
            Console.WriteLine("Dane samochodu osobowego:");
            bool weightCorrect;
            do
            {
                Console.Write("Podaj wagę w t: ");
                weightCorrect = double.TryParse(Console.ReadLine(), out weight);
                if (!weightCorrect || weight < 0.8 || weight > 4.5)
                {
                    Console.WriteLine("Waga ma być 0,8-4,5 t");
                    weightCorrect = false;
                }
            } while (!weightCorrect);

            bool displacementCorrect;
            do
            {
                Console.Write("Podaj pojemność silnika w l: ");
                displacementCorrect = double.TryParse(Console.ReadLine(), out displacement);
                if (!displacementCorrect || displacement < 0.8 || displacement > 3)
                {
                    Console.WriteLine("Pojemność silnika ma być między 0,8 a 3 l");
                    displacementCorrect = false;
                }
            } while (!displacementCorrect);

            bool personsCorrect;
            do
            {
                Console.Write("Podaj ilość osób: ");
                personsCorrect = int.TryParse(Console.ReadLine(), out persons);
                if (!personsCorrect || persons < 1)
                {
                    Console.WriteLine("Ilość osób minimum 1");
                    personsCorrect = false;
                }
            } while (!personsCorrect);
        }
        public override void View()
        {
            base.View();
            Console.WriteLine($"Waga: {weight} t");
            Console.WriteLine($"Pojemność silnika: {displacement} l");
            Console.WriteLine($"Ilość osób: {persons}");
        }
    }
}
