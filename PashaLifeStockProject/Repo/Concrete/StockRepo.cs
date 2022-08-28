using Microsoft.EntityFrameworkCore;
using PashaLifeStockProject.Data.Context;
using PashaLifeStockProject.Data.Entities;
using PashaLifeStockProject.Errors;
using PashaLifeStockProject.Repo.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PashaLifeStockProject.Repo.Concrete
{
    public class StockRepo : IStockRepo
    {
        private readonly StockDbContext stockDbContext;

        public StockRepo(StockDbContext stockDbContext)
        {
            this.stockDbContext = stockDbContext;
        }
        public async Task AddStock(Stock stock)
        {
            await stockDbContext.Stocks.AddAsync(stock);
            var result =  await stockDbContext.SaveChangesAsync();
            if (result <=0)
            {
                throw new CustomError("add_stock_error");
            }
        }

        public async Task<List<Stock>> GetStocksByProductId(int productId)
        {
            var result = await stockDbContext.Stocks.Where(x => x.ProductId == productId).ToListAsync();
            return result;
        }
    }
}
