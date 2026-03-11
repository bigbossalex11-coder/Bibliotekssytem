using LibrarySystem.Core;
using LibrarySystem.Data;
using LibrarySystem.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BiblioteksystemTests
{
    public class BookRepositoryTest
    {
        private LibraryContext CreateContext()
        {
            var options = new DbContextOptionsBuilder <LibraryContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new LibraryContext(options);
        }

        [Fact]
        public async Task AddAsync_ShouldAddBookToDatabase()
        {
            var context = CreateContext();
            var repo = new BookRepository(context);
            var book = new Book("123-321", "Hobbit", "Tolkien", 1937);

            await repo.AddAsync(book);
            var result = await repo.GetAllAsync();
            
            Assert.Single(result);
        }
        [Fact]
        public async Task GetByIDAsync_ShouldReturnCorrectBook()
        {
            var context = CreateContext();
            var repo = new BookRepository(context);
            var book = new Book("123-321", "Hobbit", "Tolkien", 1937);
            await repo.AddAsync(book);

            var result = await repo.GetByIdAsync(book.Id);

            Assert.NotNull(result);
            Assert.Equal(result.Title, book.Title);
        }
        [Fact]
        public async Task DeleteAsync_ShouldRemoveBookFromDatabase()
        {
            var context = CreateContext();
            var repo = new BookRepository(context);
            var book = new Book("123-321", "Hobbit", "Tolkien", 1937);
            await repo.AddAsync(book);

            await repo.DeleteAsync(book.Id);
            var result = await repo.GetAllAsync();

            Assert.Empty(result);
        }
        [Fact]
        public async Task SearchAsync_ShouldReturnMatchingBooks()
        {
            var context = CreateContext();
            var repo = new BookRepository(context);
            var book = new Book("123-321", "Hobbit", "Tolkien", 1937);
            var book2 = new Book("978-0-06-093546-7", "Lord of the Flies", "William Golding", 1954);
            await repo.AddAsync(book);
            await repo.AddAsync(book2);

            var result = await repo.SearchAsync("Hobbit");
            
            Assert.Single(result);
        }
        [Fact]
        public async Task UpdateAsync_ShouldChangeBookTitle()
        {
            var context = CreateContext();
            var repo = new BookRepository(context);
            var book = new Book("123-321", "Hobbit", "Tolkien", 1937);
            await repo.AddAsync(book);
            
            book.Title = "Smauge";
            await repo.UpdateAsync(book);

            var result = await repo.GetByIdAsync(book.Id);

            Assert.NotNull(result);
            Assert.Equal(result.Title , book.Title);
        }
    }
    
}
