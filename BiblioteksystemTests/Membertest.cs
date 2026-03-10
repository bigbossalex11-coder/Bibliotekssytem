using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Core;

namespace BiblioteksystemTests
{
    public class Membertest
    {
        [Fact]
        public void CreateMember_Check_for_CorrectName_ID()
        {
            var member = new Member("name", "membershipID", true );

            Assert.Equal("name",member.Name); 
            Assert.Equal("membershipID",member.MembershipID);
        }
        [Fact]
        public void NewMember_CanBorrow_IsTrue_ByDefault() 
        {
            var member = new Member("name", "membershipID");
            Assert.True(member.CanBorrow);
        }
        [Fact]
        public void NewMember_ListofBooks_empty()
        {
            var member = new Member("name", "membershipID", true);
            Assert.Equal(0, member.BorrowedBooks.Count);
        }
        [Fact]
        public void Member_BorrowBook_AddsBookToLIst()
        {
            var member = new Member("name", "membershipID", true);
            var book =  new Book("ISBN", "title", "author", 2022);
            
            member.BorrowBook(book);

            Assert.True(member.BorrowedBooks.Count == 1);
        }
    }
}
