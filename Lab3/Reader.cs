using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Reader : Person
    {
        protected List<Book> books = new List<Book>();
        public Reader(string firstName, string lastName, int age, List<Book> books) : base(firstName, lastName, age)
        {
            this.books = books;
        }
        public void ViewBook()
        {
            foreach (Book book in books)
            {
                book.View();
            }
        }
        public override void View()
        {
            base.View();
            ViewBook();
        }
    }
}
