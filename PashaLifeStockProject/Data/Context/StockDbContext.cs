using Microsoft.EntityFrameworkCore;
using PashaLifeStockProject.Data.Entities;

namespace PashaLifeStockProject.Data.Context
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options)
        : base(options)
        {

        }
        public DbSet<Stock> Stocks { get; set; }
    }
}
