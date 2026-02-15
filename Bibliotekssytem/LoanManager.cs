using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekssytem
{
    public class LoanManager
    {
        public List<Loan> Loans { get; private set; }

        public LoanManager()
        {
            Loans = new List<Loan>();
        }
        public void BorrowBooks(Book book, Member member)
        {
            if (book.IsAvailable && member.CanBorrow)
            {
                var loan = new Loan(book, member);
                Loans.Add(loan);
                book.IsAvailable = false;
            }
        }
        public void ReturnBooks(Book book)
        {
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
