using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var listProduct = new List<Product>();
            try
            {
                using var context = new PRN231_As1Context();
                listProduct = context.Products.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return listProduct;
        }

        public static Product FindProductById(int id)
        {
            Product m = new Product();
            try
            {
                using var context = new PRN231_As1Context();
                m = context.Products.SingleOrDefault(m => m.ProductId == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return m;
        }

        public static void SaveProduct(Product m)
        {
            try
            {
                using var context = new PRN231_As1Context();
                context.Products.Add(m);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void UpdateProduct(Product m)
        {
            try
            {
                using var context = new PRN231_As1Context();
                context.Entry<Product>(m).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteProduct(Product m)
        {
            try
            {
                using var context = new PRN231_As1Context();
                var m1 = context.Products.SingleOrDefault(c => c.ProductId == m.ProductId);
                if (m1 != null)
                {
                    context.Products.Remove(m1);
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