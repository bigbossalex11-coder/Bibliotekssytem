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
    }
}
