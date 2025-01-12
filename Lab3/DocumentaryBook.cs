using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class DocumentaryBook : Book
    {
        public string geographicArea;
        public DocumentaryBook(string title, Person author, DateTime publishDate, string geographicArea) : base(title, author, publishDate)
        {
            this.geographicArea = geographicArea;
        }
        public override void View()
        {
            base.View();
            Console.WriteLine($"obszar geograficzny: {geographicArea}");
        }
    }
}
