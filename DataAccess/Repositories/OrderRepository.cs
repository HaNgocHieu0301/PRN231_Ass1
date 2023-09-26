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
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(Order m) => OrderDAO.DeleteOrder(m);

        public Order FindOrderById(int id) => OrderDAO.FindOrderById(id);

        public List<Order> GetOrders() => OrderDAO.GetOrders();

        public void SaveOrder(Order m) => OrderDAO.SaveOrder(m);

        public void UpdateOrder(Order m) => OrderDAO.UpdateOrder(m);
    }
}
