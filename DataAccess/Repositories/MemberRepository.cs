using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.Repositories.IRepositories;

namespace DataAccess.Repositories;

public class MemberRepository : IMemberRepository
{
    public List<Member> GetMembers() => MemberDAO.GetMembers();
    public Member FindMemberById(int id) => MemberDAO.FindMemberById(id);
    public void SaveMember(Member m) => MemberDAO.SaveMember(m);
    public void UpdateMember(Member m) => MemberDAO.UpdateMember(m);
    public void DeleteMember(Member m) => MemberDAO.DeleteMember(m);
}