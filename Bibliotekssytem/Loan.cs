
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekssytem
{
    /// <summary>
    /// Represents a book loan with due date and late fee calculation.
    /// </summary>
    public class Loan
    {
        public Book Book { get; private set; }
        public Member Member { get; private set; }
        public DateTime LoanDate { get; private set; }
        public bool IsReturned { get; private set; }
        public DateTime DueDate { get; private set; }
        private const int LoanPeriodDays = 14;
        private const decimal LateFeePerDay = 10m;

        public Loan(Book book, Member member)
        {
            Book = book;
            Member = member;
            LoanDate = DateTime.Today;
            IsReturned = false;
            DueDate = LoanDate.AddDays(LoanPeriodDays);
        }

        public void ReturnBook()
        {
            IsReturned = true;
        }
        public decimal CalculateLateFee(DateTime currentDate)
        {
            //fee is 10 kr per day past due date
            var dayslate = (currentDate - DueDate).Days;
            if (dayslate > 0)
            {
                return dayslate * LateFeePerDay; 
            }
            return 0;
        }
    }
}
