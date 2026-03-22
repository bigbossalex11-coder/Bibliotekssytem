using LibrarySystem.Core;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Data.Interfaces
{
    public interface IMemberService
    {
        Task<List<Member>> GetActiveMemberAsync();
        Task<string?> AddMemberAsync(string name);
        Task DeleteMemberAsync(int id);
    }
}
