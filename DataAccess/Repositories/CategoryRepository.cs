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
    public class CategoryRepository : ICategoryRepository
    {
        public void DeleteCategory(Category p) => CategoryDAO.DeleteCategory(p);

        public Category FindCategoryById(int id) => CategoryDAO.FindCategoryById(id);

        public List<Category> GetCategories() => CategoryDAO.GetCategories();

        public void SaveCategory(Category p) => CategoryDAO.SaveCategory(p);

        public void UpdateCategory(Category p) => CategoryDAO.UpdateCategory(p); 
    }
}
