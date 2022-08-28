using PashaLifeStockProject.Dto;
using System.Threading.Tasks;

namespace PashaLifeStockProject.Service.Abstract
{
    public interface IStockService
    {
        public Task CheckProductId(int productId);
        public Task AddStock(StockDto stockRequestDto);
        public Task RemoveStock(StockDto stockRequestDto);
        public Task<StockResponseDto> GetStock(int productId);




    }
}
