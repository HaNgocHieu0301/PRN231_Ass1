using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class MemberDAO
    {
        public static List<Member> GetMembers()
        {
            var listMember = new List<Member>();
            try
            {
                using var context = new PRN231_As1Context();
                listMember = context.Members.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return listMember;
        }

        public static Member FindMemberById(int id)
        {
            Member m = new Member();
            try
            {
                using var context = new PRN231_As1Context();
                m = context.Members.SingleOrDefault(m => m.MemberId == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return m;
        }

        public static void SaveMember(Member m)
        {
            try
            {
                using var context = new PRN231_As1Context();
                context.Members.Add(m);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void UpdateMember(Member m)
        {
            try
            {
                using var context = new PRN231_As1Context();
                context.Entry<Member>(m).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteMember(Member m)
        {
            try
            {
                using var context = new PRN231_As1Context();
                var m1 = context.Members.SingleOrDefault(c => c.MemberId == m.MemberId);
                if (m1 != null)
                {
                    context.Members.Remove(m1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}