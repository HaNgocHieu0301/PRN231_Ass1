using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
using DataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.DAO
{
    public class OrderDetailDAO
    {
        public static List<OrderDetail> GetOrderDetails()
        {
            var listOrderDetail = new List<OrderDetail>();
            try
            {
                using var context = new PRN231_As1Context();
                listOrderDetail = context.OrderDetails.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return listOrderDetail;
        }

        public static OrderDetail FindOrderDetailByOrderId(int orderId, int productId)
        {
            OrderDetail m = new OrderDetail();
            try
            {
                using var context = new PRN231_As1Context();
                m = context.OrderDetails.SingleOrDefault(m => m.OrderId == orderId && m.ProductId == productId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return m;
        }

        public static List<OrderDetail> FindOrderDetailByOrderId(int orderId)
        {
            var m = new List<OrderDetail>();
            try
            {
                using var context = new PRN231_As1Context();
                m = context.OrderDetails.Where(m => m.OrderId == orderId).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return m;
        }

        public static void SaveOrderDetail(OrderDetail m)
        {
            try
            {
                using var context = new PRN231_As1Context();
                context.OrderDetails.Add(m);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void UpdateOrderDetail(OrderDetail m)
        {
            try
            {
                using var context = new PRN231_As1Context();
                context.Entry<OrderDetail>(m).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteOrderDetail(int orderId, int productId)
        {
            try
            {
                using var context = new PRN231_As1Context();
                var m1 = context.OrderDetails.SingleOrDefault(c => c.OrderId == orderId && c.ProductId == productId);
                if (m1 != null)
                {
                    context.OrderDetails.Remove(m1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public static void DeleteOrderDetails(int orderId)
        {
            try
            {
                using var context = new PRN231_As1Context();
                var m1 = context.OrderDetails.Where(c => c.OrderId == orderId).ToList();
                context.OrderDetails.RemoveRange(m1);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}