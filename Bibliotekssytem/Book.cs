using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekssytem
{
    public class Book
    {
      public string ISBN { get; init; }
      public string Title { get; private set; }
      public string Author { get; private set; }
      public int PublishedYear {  get; private set; }
      public bool IsAvailable { get; set; }

        public Book(string iSBN, string title, string author, int publishedYear, bool isAvailable = true)
        {
            ISBN = iSBN;
            Title = title;
            Author = author;
            PublishedYear = publishedYear;
            IsAvailable = isAvailable;
        }
        public string GetInfo()
        {
            return $"{Title} by {Author} written in {PublishedYear} is {IsAvailable}";
        }
    }
}
