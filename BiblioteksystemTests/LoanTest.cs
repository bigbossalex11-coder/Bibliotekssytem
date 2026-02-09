using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotekssytem;

namespace BiblioteksystemTests
{
    public class LoanTest
    {
        [Fact]
        public void Loan_Should_Have_Book_And_Member_Set()
        {
            var book = new Book("123-321", "Hobbit","Tolkien", 1937);
            var member = new Member("Johan", "M001");
            var loan = new Loan(book,member);

            Assert.Equal(book, loan.Book);
            Assert.Equal(member, loan.Member);
        }
        [Fact]
        public void Loan_Should_Have_Default_LoanDate_And_IsReturned()
        {
            var book = new Book("123-321", "Hobbit", "Tolkien", 1937);
            var member = new Member("Johan", "M001");
            var loan = new Loan(book, member);

            Assert.Equal(DateTime.Today, loan.LoanDate);
            Assert.False(loan.IsReturned);
        }
        [Fact]
        public void Loan_Should_Have_DueDate_14_Days_From_Today()
        {
            var book = new Book("123-321", "Hobbit", "Tolkien", 1937);
            var member = new Member("Johan", "M001");
            var loan = new Loan(book, member);

            Assert.Equal(DateTime.Today.AddDays(14), loan.DueDate);
        }
    }
}
