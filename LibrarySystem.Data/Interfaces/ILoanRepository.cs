using LibrarySystem.Core;


namespace LibrarySystem.Data.Interfaces
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAllAsync();
        Task<Loan?> GetByIdAsync(int id);
        Task<List<Loan>> GetActiveLoansAsync();
        Task<List<Loan>> GetLoansByMemberAsync(int memberID);

        Task AddAsync(Loan loan);
        Task UpdateAsync(Loan loan);
        Task DeleteAsync(int id);   
    }
}
