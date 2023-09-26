using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class OrderDAO
    {
        public static List<Order> GetOrders()
        {
            var listOrder = new List<Order>();
            try
            {
                using var context = new PRN231_As1Context();
                listOrder = context.Orders.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listOrder;
        }

        public static Order FindOrderById(int id)
        {
            Order m = new Order();
            try
            {
                using var context = new PRN231_As1Context();
                m = context.Orders.SingleOrDefault(m => m.OrderId == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return m;
        }

        public static void SaveOrder(Order m)
        {
            try
            {
                using var context = new PRN231_As1Context();
                context.Orders.Add(m);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void UpdateOrder(Order m)
        {
            try
            {
                using var context = new PRN231_As1Context();
                context.Entry<Order>(m).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteOrder(Order m)
        {
            try
            {
                using var context = new PRN231_As1Context();
                var m1 = context.Orders.SingleOrDefault(c => c.OrderId == m.OrderId);
                if (m1 != null)
                {
                    OrderDetailDAO.DeleteOrderDetails(m.OrderId);
                    context.Orders.Remove(m1);
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