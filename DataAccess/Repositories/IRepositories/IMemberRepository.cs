using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.IRepositories
{
    public interface IMemberRepository
    {
        List<Member> GetMembers();
        public Member FindMemberById(int id);

        public void SaveMember(Member m);

        public void UpdateMember(Member m);

        public void DeleteMember(Member m);
    }
}