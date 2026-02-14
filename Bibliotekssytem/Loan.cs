
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekssytem
{
    public class Loan
    {
        public Book Book { get; private set; }
        public Member Member { get; private set; }
        public DateTime LoanDate { get; private set; }
        public bool IsReturned { get; private set; }
        public DateTime DueDate { get; private set; }

        public Loan(Book book, Member member)
        {
            Book = book;
            Member = member;
            LoanDate = DateTime.Today;
            IsReturned = false;
            DueDate = LoanDate.AddDays(14);
        }

        public void ReturnBook()
        {
            IsReturned = true;
        }
    }
}
