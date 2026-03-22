using System.ComponentModel.DataAnnotations;


namespace LibrarySystem.Core
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "ISBN måste vara exakt 13 siffror")]
        public string ISBN { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Titel måste vara mellan 1 och 100 tecken")]
        public string Title { get; set; }
        [Required]
        [RegularExpression(@"^[a-öA-Ö\s.\-]+$", ErrorMessage = "Författare får bara innehålla bokstäver")]
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();

        private Book() { }
        

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
