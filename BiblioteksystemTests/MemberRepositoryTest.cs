using LibrarySystem.Data;
using LibrarySystem.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Core;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace BiblioteksystemTests
{

    public class MemberRepositoryTest
    {
        private LibraryContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new LibraryContext(options);
        }
        [Fact]
        public async Task AddAsync_ShouldAddMemberToDataBase()
        {
            var context = CreateContext();
            var repo = new MemberRepository(context);
            var member = new Member("Challe","0001");

            await repo.AddAsync(member);
            var result = await repo.GetAllAsync();

            Assert.Single(result);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectMember()
        {
            var context = CreateContext();
            var repo = new MemberRepository(context);
            var member = new Member("Challe", "0001");
            await repo.AddAsync(member);
            
            var result = await repo.GetByIdAsync(member.Id);

            Assert.NotNull(result);
            Assert.Equal(result .Id, member.Id);
         }
        [Fact]
        public async Task DeleteAsync_ShouldRemoveMemberFromDatabase()
        {
            var context = CreateContext();
            var repo = new MemberRepository(context);
            var member = new Member("Challe", "0001");
            await repo.AddAsync(member);

            await repo.DeleteAsync(member.Id);
            var result = await repo.GetAllAsync();

            Assert.Empty(result);
        }
        [Fact]
        public async Task SearchByAsync_ShouldReturnMatchingMembers()
        {
            var context = CreateContext();
            var repo = new MemberRepository(context);
            var member = new Member("Challe", "0001");
            var member2 = new Member("Danne", "0002");
            await repo.AddAsync(member);
            await repo.AddAsync(member2);

            var result = await repo.SearchAsync("Challe");

            Assert.Single(result);
        }
        [Fact]
        public async Task UpdateAsync_ShouldChangeMemberName()
        {
            var context = CreateContext();
            var repo = new MemberRepository(context);
            var member = new Member("Challe", "0001");
            await repo.AddAsync (member);
            member.Name = "John";
            await repo.UpdateAsync(member);

            var result = await repo.GetByIdAsync(member.Id);
            
            Assert.NotNull(result);
            Assert.Equal(result.Name, member.Name);
        }
    }

}
