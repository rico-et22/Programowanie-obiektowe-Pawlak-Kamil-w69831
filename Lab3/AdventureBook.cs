using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class AdventureBook : Book

    {
        public string topic;
        public AdventureBook(string title, Person author, DateTime publishDate, string topic):base(title,author,publishDate)
        {
            this.topic = topic;
        }
    }
}
