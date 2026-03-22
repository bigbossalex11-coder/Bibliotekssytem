using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Core
{
        public class Member
        {
            public int Id {  get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string MembershipID { get; set; }
            public bool CanBorrow { get; set; }
            public List<Book> BorrowedBooks { get; set; }

            private Member()
        {

        }

            public Member(string name, bool canBorrow = true)
            {
                Name = name;
                MembershipID = "M-" + Guid.NewGuid().ToString()[..8];
                CanBorrow = canBorrow;
                BorrowedBooks = new List<Book>();
            }
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
