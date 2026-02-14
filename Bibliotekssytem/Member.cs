using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekssytem
{
    public class Member
    {
        public string  Name { get; set; }
        public string  MembershipID { get; private set; }
        public bool CanBorrow { get; private set; }
        public List<Book> BorrowedBooks { get; private set; }

        public Member(string name, string membershipID, bool canBorrow = true)
        {
            Name = name;
            MembershipID = membershipID;
            CanBorrow = canBorrow;
            BorrowedBooks = new List<Book>();
        }
        public void BorrowBook(Book book)
        {
            BorrowedBooks.Add(book);
        }
    }
}
