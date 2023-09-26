using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderDetailRepostitory : IOrderDetailRepository
    {
        public void DeleteOrderDetail(int orderId, int productId) => OrderDetailDAO.DeleteOrderDetail(orderId, productId);

        public void DeleteOrderDetails(int orderId) => OrderDetailDAO.DeleteOrderDetails(orderId);

        public OrderDetail FindOrderDetailByOrderIdAndProductId(int orderId, int productId) => OrderDetailDAO.FindOrderDetailByOrderId(orderId, productId);

        public List<OrderDetail> FindOrderDetailsByOrderId(int orderId) => OrderDetailDAO.FindOrderDetailByOrderId(orderId);

        public List<OrderDetail> GetOrderDetails() => OrderDetailDAO.GetOrderDetails();

        public void SaveOrderDetail(OrderDetail m) => OrderDetailDAO.SaveOrderDetail(m);

        public void UpdateOrderDetail(OrderDetail m) => OrderDetailDAO.UpdateOrderDetail(m);
    }
}
