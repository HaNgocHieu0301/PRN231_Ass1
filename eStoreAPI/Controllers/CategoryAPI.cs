using DataAccess.Repositories.IRepositories;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessObject.Models;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAPI : ControllerBase
    {
        private ICategoryRepository repository = new CategoryRepository();
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories() => repository.GetCategories();

        [HttpPost]
        public IActionResult PostCategory(Category m)
        {
            repository.SaveCategory(m);
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult DeleteCategory(int id)
        {
            var m = repository.FindCategoryById(id);
            if (m == null)
                return NotFound();
            repository.DeleteCategory(m);
            return NoContent();
        }
        [HttpPut("id ")]
        public IActionResult UpdateCategory(int id, Category m)
        {
            var mTmp = repository.FindCategoryById(id);
            if (mTmp == null)
            {
                return NotFound();
            }
            m.CategoryId = mTmp.CategoryId;
            repository.UpdateCategory(m);
            return NoContent();
        }
    }
}
