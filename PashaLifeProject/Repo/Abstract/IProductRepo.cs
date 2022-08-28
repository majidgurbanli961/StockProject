using PashaLifeProject.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PashaLifeProject.Repo.Abstract
{
    public interface IProductRepo
    {
        public Task<List<Product>> GetAllProducts();
        public Task<Product> GetProductById(int id);
        public Task CreateProduct(Product product);
        public Task DeleteProduct(Product product);
        public Task UpdateProduct(Product product);

    }
}
