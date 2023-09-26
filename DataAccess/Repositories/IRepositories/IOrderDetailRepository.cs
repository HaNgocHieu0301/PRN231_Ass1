using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.IRepositories
{
    public interface IOrderDetailRepository
    {
        public List<OrderDetail> GetOrderDetails();

        public OrderDetail FindOrderDetailByOrderIdAndProductId(int orderId, int productId);

        public List<OrderDetail> FindOrderDetailsByOrderId(int orderId);

        public void SaveOrderDetail(OrderDetail m);

        public void UpdateOrderDetail(OrderDetail m);

        public void DeleteOrderDetail(int orderId, int productId);
        public void DeleteOrderDetails(int orderId);
    }
}
