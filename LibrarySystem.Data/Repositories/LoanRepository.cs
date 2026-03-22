using LibrarySystem.Core;
using LibrarySystem.Data.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace LibrarySystem.Data.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryContext _context;

        public LoanRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Loan>> GetAllAsync()
        {
            return await _context.Loans.ToListAsync();
        }
        public async Task<Loan?> GetByIdAsync(int id)
        {
            return await _context.Loans.FindAsync(id);
        }
        public async Task<List<Loan>> GetActiveLoansAsync()
        {
            return await _context.Loans.Where(l => l.IsReturned == false).ToListAsync();
        }
        public async Task<List<Loan>> GetLoansByMemberAsync(int memberId)
        {
            return await _context.Loans.Where(l => l.MemberId == memberId).ToListAsync();

        }
        public async Task AddAsync(Loan loan)
        {
            try
            {
                _context.Loans.Add(loan);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Kunde inte lägga till lån", ex);
            }
        }
          
        public async Task UpdateAsync(Loan loan)
        {
            try
            {
                _context.Loans.Update(loan);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Kunde inte uppdatera befintligt lån", ex);
            }
               
        }
        public async Task DeleteAsync(int id)
        {
            try
            {
                var loan = await _context.Loans.FindAsync(id);
                if (loan != null)
                {
                    _context.Loans.Remove(loan);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("Kunde inte ta bort befintligt lån", ex);
            }
        }
    }
}
  




    
