using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Bibliotekssytem;
using Xunit;

namespace BiblioteksystemTests
{
    public class LoanManagerTest
    {
        [Fact]
        public void BorrowBooks_Ads_Book_And_Member_To_List()
        {
            var loanManager = new LoanManager();
            var book = new Book("123-321", "Hobbit", "Tolkien", 1937);
            var member = new Member("Charlie", "0001", true);

            loanManager.BorrowBooks(book, member);

            Assert.Single(loanManager.Loans);
        }
        [Fact]
        public void ReturnBook_Marks_Book_As_Returned_as_True()
        {
            var loanManager = new LoanManager();
            var book = new Book("123-321", "Hobbit", "Tolkien", 1937);
            var member = new Member("Charlie", "0001", true);

            loanManager.BorrowBooks(book,member);
            loanManager.ReturnBooks(book);

            Assert.True(loanManager.Loans[0].IsReturned);
        }
        [Fact]
        public void BorrowBooks_DoesNotAddLoan_WhenCanBorrowIsFalse()
        {
            var member = new Member("name", "membershipID", false); 
            var book = new Book("ISBN", "title", "author", 2022);
            var loanManager = new LoanManager();
            
            Assert.Throws<InvalidOperationException>(() => loanManager.BorrowBooks(book, member));
        }
        [Fact]
        public void BorrowBooks_Set_Book_As_Not_Available_WhenBookIsBorrowed()
        {
            var member = new Member("name", "membershipID", true);
            var book = new Book("ISBN", "title", "author", 2022);
            var loanManager = new LoanManager();

            loanManager.BorrowBooks(book, member);

            Assert.False(book.IsAvailable);
        }
        [Fact]
        public void ReturnBooks_Set_Book_As_Avaiblable_WhenReturned()
        {
            var loanManager = new LoanManager();
            var book = new Book("123-321", "Hobbit", "Tolkien", 1937);
            var member = new Member("Charlie", "0001", true);

            loanManager.BorrowBooks(book, member);
            loanManager.ReturnBooks(book);

            Assert.True(book.IsAvailable);
        }
        [Fact]
        public void BorrowBooks_Throws_Exception_When_Book_is_Unavailable()
        {
            var loanManager = new LoanManager();
            var book = new Book("123-321", "Hobbit", "Tolkien", 1937, false);
            var member = new Member("Charlie", "0001", true);


            Assert.Throws<InvalidOperationException>(() => loanManager.BorrowBooks(book, member));
        }
        

    }
}
