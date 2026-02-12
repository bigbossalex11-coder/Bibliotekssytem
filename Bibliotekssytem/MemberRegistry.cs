using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekssytem
{
    public class MemberRegistry
    {
        public List<Member> Members {  get; set; }
        
        public MemberRegistry()
        {
            Members = new List<Member>();
        }
        public void AddMember(Member member)
            { Members.Add(member); }

        public void RemoveMember(Member member) 
            { Members.Remove(member); }

    }
    
}
