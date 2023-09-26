using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        public Category FindCategoryById(int id);

        public void SaveCategory(Category p);

        public void UpdateCategory(Category p);

        public void DeleteCategory(Category p);
    }
}
