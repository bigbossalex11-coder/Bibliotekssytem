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
        public List<Loan> Loans { get; set; }

        public LoanManager()
        {
            Loans = new List<Loan>();
        }
        public void BorrowBooks(Book book, Member member)
        {
            var loan = new Loan(book, member);
            Loans.Add(loan);
        }
        public void ReturnBooks(Book book)
        {
            foreach (var loan in Loans)
            {
                if (loan.Book == book)
                {
                    loan.ReturnBook();
                }
            }
        }
    }
        
}
