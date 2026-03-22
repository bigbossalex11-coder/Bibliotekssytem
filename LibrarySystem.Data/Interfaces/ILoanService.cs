using LibrarySystem.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Data.Interfaces
{
    public interface ILoanService
    {
        Task<List<Loan>> GetActiveLoansAsync();
        Task<string?> AddLoanAsync(int bookId, int memberId);
        Task ReturnLoanAsync(Loan loan);
        Task DeleteLoanAsync(int id);
        Task<List<Loan>> GetLoansByBookIdAsync(int bookId);
    }
}
