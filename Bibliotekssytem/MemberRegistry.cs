using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekssytem
{
    public class MemberRegistry : ISearchable<Member>
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

        public List<Member> SearchByName(string searchTerm)
        {
            var result = new List<Member>();
            foreach (var member in Members)
            {
                if (member.Name.ToLower().Contains(searchTerm.ToLower())) 
                result.Add(member);
            }
            return result;
        }
        public List<Member> Search(string searchTerm)
        {
            return SearchByName(searchTerm);
        }
    }
    
}
