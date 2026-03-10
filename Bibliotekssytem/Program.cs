using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Linq;


namespace Bibliotekssytem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookCatalog catalog = new BookCatalog();
            var book1 = new Book("978-0-06-093546-2", "Lord Of The Rings", "Tolkien", 1953);
            var book2 = new Book("978-0-06-093546-7", "Lord of the Flies", "William Golding", 1954);
            var book3 = new Book("978-0-06-112008-4", "To Kill a Mockingbird", "Harper Lee", 1960);
            var book4 = new Book("978-0-452-28423-4", "1984", "George Orwell", 1949);

            catalog.AddBook(book1);
            catalog.AddBook(book2);
            catalog.AddBook(book3);
            catalog.AddBook(book4);

            MemberRegistry registry = new MemberRegistry();
            var member1 = new Member("Alice", "1001", true);
            var member2 = new Member("Bob", "1002", true);
            var member3 = new Member("Alice Berg", "1003", true);
            var member4 = new Member("Charlie Patron", "1004", true);

            registry.AddMember(member1);
            registry.AddMember(member2);
            registry.AddMember(member3);
            registry.AddMember(member4);

            LoanManager manager = new LoanManager();

            while (true)
            {
                Console.WriteLine("\n=== Bibliotekssystem ===");
                Console.WriteLine("1. Visa alla böcker");
                Console.WriteLine("2. Sök bok");
                Console.WriteLine("3. Låna bok");
                Console.WriteLine("4. Returnera bok");
                Console.WriteLine("5. Visa medlemmar");
                Console.WriteLine("6. Statistik");
                Console.WriteLine("0. Avsluta");
                Console.Write("\nVälj: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        return;
                    case "1":
                        foreach (var book in catalog.Books)
                        {
                            Console.WriteLine(book.GetInfo());
                        }
                        break;
                    case "2":
                        Console.Write("Sökterm: ");
                        var searchTerm = Console.ReadLine();
                        var results = catalog.SearchByTitle(searchTerm);
                        foreach (var book in results)
                        {
                            Console.WriteLine(book.GetInfo());
                        }
                        break;
                    case "3":
                        foreach(var book in catalog.Books)
                        {
                            if (book.IsAvailable)
                            {
                                Console.WriteLine(book.GetInfo());
                            }
                        }
                        try
                        {
                            Console.Write("Ange boktitle: ");
                            var bookTitle = Console.ReadLine();
                            var searchResult = catalog.SearchByTitle(bookTitle);
                            var selectedBook = searchResult.First();

                            foreach (var member in registry.Members)
                            {
                                Console.WriteLine($"ID: {member.MembershipID} | Namn: {member.Name}");
                            }
                            Console.WriteLine("Ange medlems-ID: ");
                            var memberID = Console.ReadLine();

                            var selectedMember = registry.Members.First(m => m.MembershipID == memberID);
                            manager.BorrowBooks(selectedBook, selectedMember);
                            Console.WriteLine("Boken har lånats!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Fel: {ex.Message}");
                        }
                        break;
                    case "4":
                        foreach (var book in catalog.Books)
                        {
                            if (!book.IsAvailable)
                            {
                                Console.WriteLine(book.GetInfo());
                            }
                        }

                        try
                        {
                            Console.Write("Ange boktitle: ");
                            var returTitle = Console.ReadLine();
                            var returnResult = catalog.SearchByTitle(returTitle);
                            var returnBook = returnResult.First();

                            manager.ReturnBooks(returnBook);
                            Console.WriteLine("Boken har returnerats!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Fel: {ex.Message}");
                        }
                        break;
                        
                        
                    case "5":
                        foreach(var member in registry.Members)
                        {
                            Console.WriteLine($"ID: {member.MembershipID} | Namn: {member.Name} | Kan låna: {(member.CanBorrow ? "Ja" : "Nej")}");
                        }
                        break;

                    case "6":
                        Console.WriteLine($"Totalt antal böcker: {catalog.Books.Count}");
                        Console.WriteLine($"Tillgänliga: {catalog.Books.Count(b => b.IsAvailable)}");
                        Console.WriteLine($"Utlånade: {catalog.Books.Count(b => !b.IsAvailable)}");
                        Console.WriteLine($"Antal medlemar: {registry.Members.Count}");
                        Console.WriteLine($"Antal lån: {manager.Loans.Count}");
                        break;
                }


            }

        }
    }
}
