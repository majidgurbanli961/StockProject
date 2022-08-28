using PashaLifeProject.Dto.ProductDto.RequestDto;
using PashaLifeProject.Dto.ProductDto.ResponseDto;
using PashaLifeProject.Repo.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PashaLifeProject.Service.Abstract
{
    public interface IProductService
    {

        public Task<List<ProductResponseDto>> GetAllProducts();
        public Task<ProductResponseDto> GetProductById(int productId);
        public Task CreateProduct(ProductRequestDto productRequest);
        public Task DeleteProduct(int productId);
        public Task UpdateProduct(int productId, ProductRequestDto productRequest);


    }
}
