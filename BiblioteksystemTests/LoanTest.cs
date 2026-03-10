using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Core;

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
        [Fact]
        public void Loan_ReturnBook_Should_Set_Is_Returned_True()
        {
            var book = new Book("123-321", "Hobbit", "Tolkien", 1937);
            var member = new Member("Johan", "M001");
            var loan = new Loan(book, member);

            loan.ReturnBook();

            Assert.True(loan.IsReturned);
        }
        [Theory]
        [InlineData(17, 30)]
        [InlineData(14, 0)]
        [InlineData(10, 0)]
        public void CalculateLoanFee_Adds_Fee_If_Loan_Is_Late(int daysAfterLoan, decimal expectedFee)
        {
            var book = new Book("123-321", "Hobbit", "Tolkien", 1937);
            var member = new Member("Johan", "M001");
            var loan = new Loan(book, member);
            
            var fakeDate = DateTime.Today.AddDays(daysAfterLoan);
            var fee = loan.CalculateLateFee(fakeDate);
            Assert.Equal(expectedFee, fee);
        }


    }
}
