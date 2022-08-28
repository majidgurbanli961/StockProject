using Microsoft.EntityFrameworkCore;
using PashaLifeProject.Data.Entities;

namespace PashaLifeProject.Data.Context
{
    public class PashaLifeDbContext : DbContext
    {
        public PashaLifeDbContext(DbContextOptions<PashaLifeDbContext> options)
         : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }


    }
}
