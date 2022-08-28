using Microsoft.EntityFrameworkCore;
using PashaLifeProject.Data.Context;
using PashaLifeProject.Data.Entities;
using PashaLifeProject.Errors;
using PashaLifeProject.Repo.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PashaLifeProject.Repo.Concrete
{
    public class ProductRepo : IProductRepo
    {
        private readonly PashaLifeDbContext dbContext;

        public ProductRepo(PashaLifeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateProduct(Product product)
        {
           await dbContext.Products.AddAsync(product);
            var result = await dbContext.SaveChangesAsync();
            if (result <= 0)
            {
                throw new CustomError("create_error");
            }
        }

        public async Task DeleteProduct(Product product)
        {
            product.IsDeleted = true;
            dbContext.Products.Update(product);
            var result = await dbContext.SaveChangesAsync();
            if (result <= 0)
            {
                throw new CustomError("delete_not_working");
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var allProducts = await dbContext.Products.Where(x=>!x.IsDeleted).Include(x=>x.ProductCategory).ToListAsync();
            return allProducts;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await dbContext.Products.Include(x => x.ProductCategory).FirstOrDefaultAsync(x => !x.IsDeleted && x.ProductId == id);
            if(product == null)
            {
                throw new CustomError("product_not_found");
            }
            return product;
        }

        public async Task UpdateProduct(Product product)
        {
             dbContext.Products.Update(product);
            var result = await dbContext.SaveChangesAsync();
            if (result <= 0)
            {
                throw new CustomError("update_not_working");
            }
        }
    }
}
