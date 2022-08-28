using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PashaLifeStockProject.Dto;
using PashaLifeStockProject.Response;
using PashaLifeStockProject.Service.Abstract;
using PashaLifeStockProject.Validator;
using System.Threading.Tasks;

namespace PashaLifeStockProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService stockService;

        public StockController(IStockService stockService)
        {
            this.stockService = stockService;
        }
        [HttpGet("test")]
        public async Task Test()
        {
            await stockService.CheckProductId(1);

        }
        [HttpPost("addstock")]
        public async Task<ApiResponse> AddStock(StockDto stockRequest)
        {
            var validator = new StockValidator();
            validator.ValidateAndThrow(stockRequest);
            await  stockService.AddStock(stockRequest);
            return new ApiResponse();
        }
        [HttpPost("removestock")]
        public async Task<ApiResponse> RemoveStock(StockDto stockRequest)
        {
            var validator = new StockValidator();
            validator.ValidateAndThrow(stockRequest);
            await stockService.RemoveStock(stockRequest);
            return new ApiResponse();
        }
        [HttpGet("getstock")]
        public async Task<ApiValueResponse<StockResponseDto>> GetStock(int productId)
        {
            var response = await stockService.GetStock(productId);

            return new ApiValueResponse<StockResponseDto>(response);
        }
    }
}
