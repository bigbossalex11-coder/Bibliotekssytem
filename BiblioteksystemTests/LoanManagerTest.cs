using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
