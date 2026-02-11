using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotekssytem;
using Xunit;

namespace BiblioteksystemTests
{
    public class BookCatalogTest
    {
        [Fact]
        public void AddBook_Ads_Book_To_BookCatalog()
        {
            var bookCatalog = new BookCatalog();
            var book = new Book("ISBN", "title", "author", 2022);

            bookCatalog.AddBook(book);

            Assert.Contains(book, bookCatalog.Books); 
        }
        [Fact]
        public void RemoveBook_Removes_Book_from_BookCatalog()
        {
            var bookCatalog = new BookCatalog();
            var book = new Book("ISBN", "title", "author", 2022);

            bookCatalog.AddBook(book);
            bookCatalog.RemoveBook(book);

            Assert.Empty(bookCatalog.Books);
        }
    }
}
