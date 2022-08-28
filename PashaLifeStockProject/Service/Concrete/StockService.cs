using Newtonsoft.Json;
using PashaLifeStockProject.Data.Entities;
using PashaLifeStockProject.Dto;
using PashaLifeStockProject.Errors;
using PashaLifeStockProject.Helper;
using PashaLifeStockProject.Repo.Abstract;
using PashaLifeStockProject.Response;
using PashaLifeStockProject.Service.Abstract;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PashaLifeStockProject.Service.Concrete
{
    public class StockService : IStockService
    {
        private readonly IStockRepo stockRepo;

        public StockService(IStockRepo stockRepo)
        {
            this.stockRepo = stockRepo;
        }
        public async Task AddStock(StockDto stockRequestDto )
        {
            await CheckProductId(stockRequestDto.ProductId );
            var stock = new Stock()
            {
                ProductId = stockRequestDto.ProductId,
                ChangedProductCount = stockRequestDto.ChangedProductCount
            };
           await stockRepo.AddStock(stock);

        }

        public async Task CheckProductId(int productId)
        {
            using var client = new HttpClient();

            string uri = "http://localhost:5961/api/product/getbyid?productid="+productId;

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            //var context = JsonConvert.SerializeObject(employeeRegisterDto);

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var responseObj = JsonConvert.DeserializeObject(result, typeof(ApiResponse)) as ApiResponse;
                if (!responseObj.Success)
                {
                    throw new CustomError("InvalidProductId");
                }
              

            }



        }

        public async Task RemoveStock(StockDto stockRequestDto)
        {
            await CheckProductId(stockRequestDto.ProductId);

            var stocks = await stockRepo.GetStocksByProductId(stockRequestDto.ProductId);
            var isZeroOrLess = HelperFunctions.IsZeroOrLess(stocks);
            if (isZeroOrLess)
            {
                throw new CustomError("OutOfStock");
            }
            stockRequestDto.ChangedProductCount = -stockRequestDto.ChangedProductCount;
            var stock = new Stock()
            {
                ChangedProductCount = stockRequestDto.ChangedProductCount,
                ProductId = stockRequestDto.ProductId
            };
            await stockRepo.AddStock(stock);

        }
     

        public async Task<StockResponseDto> GetStock(int productId)
        {
            await CheckProductId(productId);

            var stocks = await stockRepo.GetStocksByProductId(productId);
            var totalSum = HelperFunctions.GetTotalStockValue(stocks);
            var response = new StockResponseDto()
            {
                ProductId = productId,
                TotalSum = totalSum

            };
            return response;

        }
    }
}
