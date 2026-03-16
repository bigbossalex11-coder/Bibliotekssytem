using LibrarySystem.Data;
using LibrarySystem.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Core;
using System.Runtime.InteropServices;


namespace Bibliotekssytem
{
    public class Program
    {

        static async Task Main(string[] args)
        {
            using var context = new LibraryContext(new DbContextOptions<LibraryContext>());
            await context.Database.MigrateAsync();
            var bookRepo = new BookRepository(context);

            var books = await bookRepo.GetAllAsync();
            
            if (!books.Any())
            {
                var newBook = new Book("1234567", "the Book", "alex", 2020, true);
                await bookRepo.AddAsync(newBook);
            }
            books = await bookRepo.GetAllAsync();

            foreach (var book in books) 
            {
                Console.WriteLine(book.Title);
            } 
        }
    }
}
        
          