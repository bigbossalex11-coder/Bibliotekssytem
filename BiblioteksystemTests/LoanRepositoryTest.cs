using LibrarySystem.Core;
using LibrarySystem.Data;
using LibrarySystem.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioteksystemTests
{
    public class LoanRepositoryTest
    {
        private LibraryContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new LibraryContext(options);
        }

        [Fact]
        public async Task AddAsync_ShouldAddLoanToDatabase()
        {
            var context = CreateContext();
            var bookRepo = new BookRepository(context);
            var memberRepo = new MemberRepository(context);
            var loanRepo = new LoanRepository(context);

            var book = new Book("123", "Hobbit", "Tolkien", 1937);
            var member = new Member("Challe", "0001");
            await bookRepo.AddAsync(book);
            await memberRepo.AddAsync(member);

            var loan = new Loan(book, member);
            await loanRepo.AddAsync(loan); 
            var result = await loanRepo.GetAllAsync();

            Assert.Single(result);
        }
        [Fact]
        public async Task GetActiveLoansAsync_ShouldReturnOnlyActiveLoans()
        {
            var context = CreateContext();
            var bookRepo = new BookRepository(context);
            var memberRepo = new MemberRepository(context);
            var loanRepo = new LoanRepository(context);

            var book = new Book("123", "Hobbit", "Tolkien", 1937);
            var member = new Member("Challe", "0001");
            await bookRepo.AddAsync(book);
            await memberRepo.AddAsync(member);

            var loan = new Loan(book, member);
            var loan2 = new Loan(book, member);
            await loanRepo.AddAsync(loan);
            loan2.ReturnBook();
            await loanRepo.UpdateAsync(loan2);
            
            var result = await loanRepo.GetActiveLoansAsync();

            Assert.Single(result);

        }
        [Fact]
        public async Task UpdateAsync_ShouldMarkLoanAsReturned()
        {
            var context = CreateContext();
            var bookRepo = new BookRepository(context);
            var memberRepo = new MemberRepository(context);
            var loanRepo = new LoanRepository(context);

            var book = new Book("123", "Hobbit", "Tolkien", 1937);
            var member = new Member("Challe", "0001");
            await bookRepo.AddAsync(book);
            await memberRepo.AddAsync(member);
            var loan = new Loan(book, member);
            await loanRepo.AddAsync(loan);
            
            loan.ReturnBook();
            await loanRepo.UpdateAsync(loan);

            var result = await loanRepo.GetByIdAsync(loan.Id);
            Assert.NotNull(result);
            Assert.True(result.IsReturned);
        }
        [Fact]
        public async Task GetLoansByMemberAsync_ShouldReturnLoansForMember()
        {
            var context = CreateContext();
            var bookRepo = new BookRepository(context);
            var memberRepo = new MemberRepository(context);
            var loanRepo = new LoanRepository(context);

            var book = new Book("123", "Hobbit", "Tolkien", 1937);
            var member = new Member("Challe", "0001");
            var member2 = new Member("Danne", "0002");
            await bookRepo.AddAsync(book);
            await memberRepo.AddAsync(member);
            await memberRepo.AddAsync(member2);

            var loan = new Loan(book, member);
            var loan2 = new Loan(book, member2);
            await loanRepo.AddAsync(loan);
            await loanRepo.AddAsync(loan2);

            var result = await loanRepo.GetLoansByMemberAsync(member.Id);

            Assert.Single(result);

         }


    }
}
