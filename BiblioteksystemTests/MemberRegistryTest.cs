using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Bibliotekssytem;
using Xunit;

namespace BiblioteksystemTests
{
    public class MemberRegistryTest
    {
        [Fact]
        public void AddMember_Ads_Member_To_MemberList()
        {
            var memberRegistry = new MemberRegistry();
            var member = new Member("Charlie","0001", true);

            memberRegistry.AddMember(member);

            Assert.Contains(member, memberRegistry.Members);
        }
        [Fact]
        public void RemoveMember_Removes_Member_From_List()
        {
            var memberRegistry = new MemberRegistry();
            var member = new Member("Charlie", "0001", true);
            memberRegistry.AddMember(member);

            memberRegistry.RemoveMember(member);

            Assert.Empty(memberRegistry.Members);
        }
        [Theory]
        [InlineData("Alice",true)]
        [InlineData("alice",true)]
        [InlineData("Alex",false)]
        public void Member_Matches_Search_By_Name(string searchTerm, bool shouldFind)
        {
            var memberRegistry = new MemberRegistry();

            var member1 = new Member("Alice", "1001", true);
            var member2 = new Member("Bob", "1002", true);
            var member3 = new Member("Alice Berg", "1003", true);
            var member4 = new Member("Charlie Patron", "1004", true);

            memberRegistry.AddMember(member1);
            memberRegistry.AddMember(member2);
            memberRegistry.AddMember(member3);
            memberRegistry.AddMember(member4);

            var result = memberRegistry.SearchByName(searchTerm);

            if (shouldFind)
                Assert.NotEmpty(result);
            else
                Assert.Empty(result);
        }
    }
}
