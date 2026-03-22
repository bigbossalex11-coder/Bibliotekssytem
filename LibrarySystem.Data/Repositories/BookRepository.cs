using LibrarySystem.Data.Interfaces;
using LibrarySystem.Core;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;    
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }
        public async Task<List<Book>> SearchAsync(string searchTerm)
        {
            return await _context.Books.Where(b => b.Title.Contains(searchTerm)).ToListAsync();
        }

        public async Task AddAsync(Book book)
        {
            try
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("kunde inte lägga till en bok", ex);
            }
        }
        public async Task UpdateAsync(Book book)
        {
            try
            {
                _context.Books.Update(book);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Kunde inte uppdatera boken", ex);
            }
        }    

        public async Task DeleteAsync(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book != null)
                {
                    _context.Books.Remove(book);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kunde inte ta bort bok", ex);
            }
        }


    }
    
}
