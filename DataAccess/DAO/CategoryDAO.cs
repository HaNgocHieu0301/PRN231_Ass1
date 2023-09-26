using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            var listCategory = new List<Category>();
            try
            {
                using var context = new PRN231_As1Context();
                listCategory = context.Categories.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return listCategory;
        }

        public static Category FindCategoryById(int id)
        {
            Category m = new Category();
            try
            {
                using var context = new PRN231_As1Context();
                m = context.Categories.SingleOrDefault(m => m.CategoryId == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return m;
        }

        public static void SaveCategory(Category m)
        {
            try
            {
                using var context = new PRN231_As1Context();
                context.Categories.Add(m);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void UpdateCategory(Category m)
        {
            try
            {
                using var context = new PRN231_As1Context();
                context.Entry<Category>(m).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteCategory(Category m)
        {
            try
            {
                using var context = new PRN231_As1Context();
                var m1 = context.Categories.SingleOrDefault(c => c.CategoryId == m.CategoryId);
                if (m1 != null)
                {
                    context.Categories.Remove(m1);
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
