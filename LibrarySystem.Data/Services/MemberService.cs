using LibrarySystem.Core;
using LibrarySystem.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace LibrarySystem.Data.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepo;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepo = memberRepository;
        }
       public async Task <List<Member >> GetActiveMemberAsync()
        {
            return await _memberRepo.GetAllAsync();
        }
  

        public async Task<string?> AddMemberAsync(string name)
        {
            var member = new Member(name);
            await _memberRepo.AddAsync(member);
            return null;
        }

        public async Task DeleteMemberAsync(int id)
        {
            await _memberRepo.DeleteAsync(id);
        }
    }
}
