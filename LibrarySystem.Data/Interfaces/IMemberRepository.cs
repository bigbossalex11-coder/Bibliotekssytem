using LibrarySystem.Core;


namespace LibrarySystem.Data.Interfaces
{
    public interface IMemberRepository
    {
        Task<List<Member>> GetAllAsync();
        Task<Member?> GetByIdAsync(int id);
        Task<List<Member>> SearchAsync(string searchTerm);
        Task AddAsync (Member member);
        Task UpdateAsync (Member member);
        Task DeleteAsync (int Id);

    }
}
