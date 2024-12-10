using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Book
    {
        protected string title;
        protected Person author;
        protected DateTime publishDate;

        public Book(string title, Person author, DateTime publishDate)
        {
            this.title = title;
            this.author = author;
            this.publishDate = publishDate;
        }

        public void View()
        {
            Console.WriteLine($"Tytuł: {title}, Autor:");
            author.View();
            Console.WriteLine($"Data wydania: {publishDate}");
        }
    }
}
