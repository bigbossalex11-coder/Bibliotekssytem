using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Bibliotekssytem;

namespace BiblioteksystemTests
{
    public class Booktest
    {
        [Fact]
        public void IsCreated_HasISBN_title_author_PublishedYear()
        {
            var book = new Book ("ISBN","title","author",2022);

            var result = book.GetInfo();

            Assert.Equal("ISBN", book.ISBN);
        }
        [Fact]
            public void Book_Is_Available()
        {
            var book = new Book("ISBN", "title", "author", 2022);
            Assert.True(book.IsAvailable);
        }
        [Fact]
        public void Book_Returns_Title_Author()
        {
            var book = new Book("ISBN", "title", "author", 2022);
            var result = book.GetInfo();
            Assert.Contains("title", book.GetInfo());
        }
    }
}
