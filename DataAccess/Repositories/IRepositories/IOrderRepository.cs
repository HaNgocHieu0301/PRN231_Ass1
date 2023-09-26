using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.IRepositories
{
    public interface IOrderRepository
    {
        public List<Order> GetOrders();

        public Order FindOrderById(int id);

        public void SaveOrder(Order m);

        public void UpdateOrder(Order m);


        public void DeleteOrder(Order m);
    }
}
