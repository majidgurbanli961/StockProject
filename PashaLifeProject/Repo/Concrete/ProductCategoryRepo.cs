using Microsoft.EntityFrameworkCore;
using PashaLifeProject.Data.Context;
using PashaLifeProject.Data.Entities;
using PashaLifeProject.Errors;
using PashaLifeProject.Repo.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PashaLifeProject.Repo.Concrete
{
    public class ProductCategoryRepo : IProductCategoryRepo
    {
        private readonly PashaLifeDbContext dbContext;

        public ProductCategoryRepo(PashaLifeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateProductCategory(ProductCategory productCategory)
        {
            await dbContext.ProductCategories.AddAsync(productCategory);
            var result = await dbContext.SaveChangesAsync();
            if(result <= 0)
            {
                throw new CustomError("create_error");
            }
            
        }

        public async Task DeleteProductCategory(ProductCategory productCategory)
        {
            dbContext.ProductCategories.Remove(productCategory);
            var result = await dbContext.SaveChangesAsync();
            if(result <= 0)
            {
                throw new CustomError("delete_category_error");
            }
        }

        public async Task<List<ProductCategory>> GetAllProductCategories()
        {
            var result = await dbContext.ProductCategories.ToListAsync();
            return result;
        }

        public async Task<ProductCategory> GetByIdAsync(int id)
        {
            var productCategory = await dbContext.ProductCategories.FirstOrDefaultAsync(x=>x.CategoryId==id);
            if(productCategory == null)
            {
                throw new CustomError("product_category_not_found");
            }
            return productCategory;
        }

        public  async Task UpdateProductCategory(ProductCategory productCategory)
        {
             dbContext.ProductCategories.Update(productCategory);
            var result = await dbContext.SaveChangesAsync();
            if(result<= 0)
            {
                throw new CustomError("update_product_category_error");
            }
        }
    }
}
