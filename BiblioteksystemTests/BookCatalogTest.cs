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
        
        [Theory]
        [InlineData ("Lord", true)]
        [InlineData("lord", true)]
        [InlineData("Harry", false)]
        public void Book_Matches_Search_by_title(string searchTerm, bool shouldFind)
        {
            var bookCatalog = new BookCatalog();
            
            var book1 = new Book("978-0-06-093546-2", "Lord Of The Rings", "Tolkien", 1953);
            var book2 = new Book("978-0-06-093546-7", "Lord of the Flies", "William Golding", 1954);
            var book3 = new Book("978-0-06-112008-4", "To Kill a Mockingbird", "Harper Lee", 1960);
            var book4 = new Book("978-0-452-28423-4", "1984", "George Orwell", 1949);
            
            bookCatalog.AddBook(book1);
            bookCatalog.AddBook(book2);
            bookCatalog.AddBook(book3);
            bookCatalog.AddBook(book4);

            var result = bookCatalog.SearchByTitle(searchTerm);

            if (shouldFind)
                Assert.NotEmpty(result);
            else 
                Assert.Empty(result);
        }
        [Fact]
        public void SortByTitle_Sorts_List_By_Title()
        {
            var bookCatalog = new BookCatalog();
            
            var book1 = new Book("978-0-06-093546-2", "Lord Of The Rings", "Tolkien", 1953);
            var book2 = new Book("978-0-06-093546-7", "Lord of the Flies", "William Golding", 1954);
            var book3 = new Book("978-0-06-112008-4", "To Kill a Mockingbird", "Harper Lee", 1960);
            var book4 = new Book("978-0-452-28423-4", "1984", "George Orwell", 1949);

            bookCatalog.AddBook(book1);
            bookCatalog.AddBook(book2);
            bookCatalog.AddBook(book3);
            bookCatalog.AddBook(book4);
            bookCatalog.SortByTitle();
            
            Assert.Equal("1984", bookCatalog.Books[0].Title);
        }
        [Fact]
        public void SortByYear_Sorts_List_By_Year()
        {
            var bookCatalog = new BookCatalog();

            var book1 = new Book("978-0-06-093546-2", "Lord Of The Rings", "Tolkien", 1953);
            var book2 = new Book("978-0-06-093546-7", "Lord of the Flies", "William Golding", 1954);
            var book3 = new Book("978-0-06-112008-4", "To Kill a Mockingbird", "Harper Lee", 1960);
            var book4 = new Book("978-0-452-28423-4", "1984", "George Orwell", 1949);

            bookCatalog.AddBook(book1);
            bookCatalog.AddBook(book2);
            bookCatalog.AddBook(book3);
            bookCatalog.AddBook(book4);
            bookCatalog.SortByYear();

            Assert.Equal(1949, bookCatalog.Books[0].PublishedYear);
        }
    }
}
