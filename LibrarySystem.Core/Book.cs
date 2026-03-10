

namespace LibrarySystem.Core
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();

        private Book()
        {

        }

        public Book(string iSBN, string title, string author, int publishedYear, bool isAvailable = true)
        {
            ISBN = iSBN;
            Title = title;
            Author = author;
            PublishedYear = publishedYear;
            IsAvailable = isAvailable;
        }
        public string GetInfo()
        {
            return $"{Title} by {Author} written in {PublishedYear} - {(IsAvailable ? "Tillgänglig" : "Utlånad")}";
        }
    }
}
