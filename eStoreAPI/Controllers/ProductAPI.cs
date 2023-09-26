using DataAccess.Repositories.IRepositories;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessObject.Models;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPI : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => repository.GetProducts();

        [HttpPost]
        public IActionResult PostProduct(Product m)
        {
            m.Category = null;
            repository.SaveProduct(m);
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            var m = repository.FindProductById(id);
            if (m == null)
                return NotFound();
            repository.DeleteProduct(m);
            return NoContent();
        }
        [HttpPut("id ")]
        public IActionResult UpdateProduct(int id, Product m)
        {
            var mTmp = repository.FindProductById(id);
            if (mTmp == null)
            {
                return NotFound();
            }
            m.ProductId = id;
            repository.UpdateProduct(m);
            return NoContent();
        }
    }
}
