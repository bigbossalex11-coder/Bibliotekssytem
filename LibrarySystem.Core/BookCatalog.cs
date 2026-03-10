using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Core
{
    public class BookCatalog : ISearchable<Book>
    {
        public List<Book> Books { get; private set; }

        public BookCatalog()
        {
            Books = new List<Book>();
        }
        public void AddBook(Book book)
        {
            Books.Add(book);
        }
        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }

        public List<Book> SearchByTitle(string searchTerm)
        {
            var result = new List<Book>();

            foreach (var book in Books)
            {
                if (book.Title.ToLower().Contains(searchTerm.ToLower()))
                {
                    result.Add(book);
                }

            }
            return result;
        }
        public List<Book> Search(string searchTerm)
        {
            return SearchByTitle(searchTerm);
        }
        public void SortByTitle()
        {
            Books.Sort((a, b) => string.Compare(a.Title, b.Title));

        }
        public void SortByYear()
        {
            Books.Sort((a, b) => (a.PublishedYear.CompareTo(b.PublishedYear)));
        }

    }
}
