using BusinessObject.Models;
using DataAccess.Repositories.IRepositories;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailAPI : ControllerBase
    {
        private IOrderDetailRepository repository = new OrderDetailRepostitory();
        [HttpGet]
        public ActionResult<IEnumerable<OrderDetail>> GetOrderDetails() => repository.GetOrderDetails();

        [HttpPost]
        public IActionResult PostOrderDetail(OrderDetail m)
        {
            m.Order = null;
            m.Product = null;
            repository.SaveOrderDetail(m);
            return NoContent();
        }

        [HttpDelete("orderId")]
        public IActionResult DeleteOrderDetails(int orderId)
        {
            var m = repository.FindOrderDetailsByOrderId(orderId);
            if (m == null)
                return NotFound();
            repository.DeleteOrderDetails(orderId);
            return NoContent();
        }

        [HttpDelete("productId")]
        public IActionResult DeleteOrderDetail(int orderId, int productId)
        {
            var m = repository.FindOrderDetailByOrderIdAndProductId(orderId, productId);
            if (m == null)
                return NotFound();
            repository.DeleteOrderDetail(orderId, productId);
            return NoContent();
        }

        [HttpPut("orderId")]
        public IActionResult UpdateProduct(int orderId, int productId, OrderDetail od)
        {
            var m = repository.FindOrderDetailByOrderIdAndProductId(orderId, productId);
            if (m == null)
                return NotFound();
            od.OrderId = orderId;
            od.ProductId = productId;
            repository.UpdateOrderDetail(od);
            return NoContent();
        }
    }
}
