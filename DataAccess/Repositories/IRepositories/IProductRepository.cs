using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.IRepositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        public Product FindProductById(int id);

        public void SaveProduct(Product p);

        public void UpdateProduct(Product p);

        public void DeleteProduct(Product p);
    }
}
