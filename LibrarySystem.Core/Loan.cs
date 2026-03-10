namespace LibrarySystem.Core { 
public class Loan
{
    public int Id {  get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int MemberId { get; set; }
    public Member Member { get; set; }
    public DateTime LoanDate { get; set; }
    public bool IsReturned { get; set; }
    public DateTime DueDate { get; set; }
    
    private Loan()
        {

        }

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
