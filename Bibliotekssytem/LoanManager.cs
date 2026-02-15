using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekssytem
{
    /// <summary>
    /// Manages book loans, including borrowing and returning books.
    /// </summary>
    public class LoanManager 
    {
        private const int MaxLoansPerMember = 3;
        public List<Loan> Loans { get; private set; }

        public LoanManager()
        {
            Loans = new List<Loan>();
        }
        public void BorrowBooks(Book book, Member member)
        {
            //A member can borrow a maximum of 3 books at a time
            if (Loans.Count(l => l.Member == member && !l.IsReturned) >= MaxLoansPerMember)
            {
                throw new InvalidOperationException("Member has reached max number of loans");
            }
            
            
            //only available books can be borrowed
            if (!book.IsAvailable) 
                {
                throw new InvalidOperationException("Book is not available"); 
                }
            //Member must have borrowing priviliges
            if (!member.CanBorrow)
            {
                throw new InvalidOperationException("You are not allowed to borrow"); 
            }
            var loan = new Loan(book, member);
            Loans.Add(loan);
            book.IsAvailable = false;
        }
        
        public void ReturnBooks(Book book)
        {
            if (!Loans.Any(l => l.Book == book))
            {
                throw new InvalidOperationException("Book is not borrowed");
            }
            foreach (var loan in Loans)
            {
                if (loan.Book == book)
                {
                    loan.ReturnBook();
                    book.IsAvailable = true;

                }
            }
        }
    }
        
}
