using LibrarySystem.Core;
using LibrarySystem.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibrarySystem.Data.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly LibraryContext _context;

        public MemberRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Member>> GetAllAsync()
        {
            return await _context.Members.ToListAsync();
        }
        public async Task<Member?> GetByIdAsync(int id)
        {
            return await _context.Members.FindAsync(id);
        }
        public async Task<List<Member>> SearchAsync(string searchTerm)
        {
            return await _context.Members.Where(m => m.Name.Contains(searchTerm)).ToListAsync();
        }

        public async Task AddAsync(Member member)
        {
            try
            {
                _context.Members.Add(member);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
               throw new Exception("Kunde inte lägga till medlem", ex); 
            }
        }

        public async Task UpdateAsync(Member member)
        {
            try
            {
                _context.Members.Update(member);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Kunde inte uppdatera medlem", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var member = await _context.Members.FindAsync(id);
                if (member != null)
                {
                    _context.Members.Remove(member);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Kunde inte ta bort medlem", ex);
            }
        }


    }

}