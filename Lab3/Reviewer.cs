using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Reviewer : Reader
    {
        public Reviewer(string firstName, string lastName, int age, List<Book> books) : base(firstName, lastName, age, books)
        {
        }
        public override void View()
        {
            foreach (var item in books)
            {
                item.View();
                Console.WriteLine($"Ocena: {new Random().Next(1,11)}/10\n");
            }
        }
    }
}
