using PashaLifeProject.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PashaLifeProject.Repo.Abstract
{
    public interface IProductCategoryRepo
    {
        public Task<ProductCategory> GetByIdAsync(int id);
        public Task<List<ProductCategory>> GetAllProductCategories();
        public Task CreateProductCategory(ProductCategory productCategory);
        public Task UpdateProductCategory(ProductCategory productCategory);
        public Task DeleteProductCategory(ProductCategory productCategory);
       
    }
}
