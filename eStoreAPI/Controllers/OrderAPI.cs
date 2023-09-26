using DataAccess.Repositories.IRepositories;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessObject.Models;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAPI : ControllerBase
    {
        private IOrderRepository repository = new OrderRepository();
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders() => repository.GetOrders();

        [HttpPost]
        public IActionResult PostOrder(Order o)
        {
            //Order o = new Order();
            //o.MemberId = 1;
            //o.OrderDate = DateTime.Now;
            //o.Freight = 10;
            o.Member = null;
            repository.SaveOrder(o);
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult DeleteOrder(int id)
        {
            var m = repository.FindOrderById(id);
            if (m == null)
                return NotFound();
            repository.DeleteOrder(m);
            return NoContent();
        }
        [HttpPut("id ")]
        public IActionResult UpdateOrder(int id, Order m)
        {
            var mTmp = repository.FindOrderById(id);
            if (mTmp == null)
            {
                return NotFound();
            }
            m.OrderId = id;
            repository.UpdateOrder(m);
            return NoContent();
        }
    }
}
