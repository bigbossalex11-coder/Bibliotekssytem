using LibrarySystem.Core;

namespace LibrarySystem.Data.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<List<Book>> SearchAsync(string searchTerm);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);

    }
}
