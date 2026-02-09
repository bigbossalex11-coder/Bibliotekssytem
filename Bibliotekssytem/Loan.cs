
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekssytem
{
    public class Loan
    {
        public Book Book { get; set; }
        public Member Member { get; set; }
        public DateTime LoanDate { get; set; }
        public bool IsReturned { get; set; }
        public DateTime DueDate { get; set; }

    public Loan(Book book, Member member)
        {
            Book = book;
            Member = member;
            LoanDate = DateTime.Today;
            IsReturned = false;
            DueDate = LoanDate.AddDays(14);
        }
    }
}
