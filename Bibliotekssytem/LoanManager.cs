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
        public List<Loan> Loans { get; private set; }

        public LoanManager()
        {
            Loans = new List<Loan>();
        }
        public void BorrowBooks(Book book, Member member)
        {
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
