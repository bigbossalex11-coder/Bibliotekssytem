using LibrarySystem.Core;
using LibrarySystem.Data.Interfaces;


namespace LibrarySystem.Data.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepo;
        private readonly IBookRepository _bookRepo;
        private readonly IMemberRepository _memberRepo;

        public LoanService(ILoanRepository loanRepo, IBookRepository bookRepo, IMemberRepository memberRepo)
        {
            _loanRepo = loanRepo;
            _bookRepo = bookRepo;
            _memberRepo = memberRepo;
        }

        public async Task<List<Loan>> GetActiveLoansAsync()
        {
            return await _loanRepo.GetActiveLoansAsync();
        }
        public async Task<string?> AddLoanAsync(int bookId, int memberId)
        {
            var book = await _bookRepo.GetByIdAsync(bookId);
            var member = await _memberRepo.GetByIdAsync(memberId);

            if (book == null || member == null)
            {
                return "Boken eller medlemmen hittades inte.";
            }
            if (!book.IsAvailable)
            {
                return "Boken är redan utlånad";
            }
            if (!member.CanBorrow)
            {
                return "Medlemmen har inte lånerättigheter";
            }

            var newLoan = new Loan(book, member);
            book.IsAvailable = false;
            await _loanRepo.AddAsync(newLoan);
            await _bookRepo.UpdateAsync(book);
            return null;
        }
        public async Task ReturnLoanAsync(Loan loan)
        {
            loan.ReturnBook();
            await _loanRepo.UpdateAsync(loan);

            var book = await _bookRepo.GetByIdAsync(loan.BookId);
            if (book != null)
            {
                book.IsAvailable = true;
                await _bookRepo.UpdateAsync(book);
            }
        }
        public async Task DeleteLoanAsync(int id)
        {
            var loan = await _loanRepo.GetByIdAsync(id);
            if (loan != null)
            {
                var book = await _bookRepo.GetByIdAsync(loan.BookId);
                if (book != null)
                {
                    book.IsAvailable = true;
                    await _bookRepo.UpdateAsync(book);
                    await _loanRepo.DeleteAsync(id);
                }

            }

        }
    }
}
