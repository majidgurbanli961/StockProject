using PashaLifeStockProject.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PashaLifeStockProject.Repo.Abstract
{
    public interface IStockRepo
    {
        public Task AddStock(Stock stock);
        public Task<List<Stock>> GetStocksByProductId(int productId);

    }
}
