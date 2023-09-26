using BusinessObject.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberAPI : ControllerBase
    {
        private IMemberRepository repository = new MemberRepository();
        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetMembers() => repository.GetMembers();

        [HttpPost]
        public IActionResult PostMember(Member m)
        {
            repository.SaveMember(m);
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult DeleteMember(int id)
        {
            var m = repository.FindMemberById(id);
            if (m == null)
                return NotFound();
            repository.DeleteMember(m);
            return NoContent();
        }
        [HttpPut("id ")]
        public IActionResult UpdateMember(int id, Member m)
        {
            var mTmp = repository.FindMemberById(id);
            if(mTmp == null)
            {
                return NotFound();
            }
            m.MemberId = mTmp.MemberId;
            repository.UpdateMember(m);
            return NoContent();
        }
    }
}
