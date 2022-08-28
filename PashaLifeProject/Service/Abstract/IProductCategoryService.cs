using PashaLifeProject.Dto.ProductCategoryDto.RequestDto;
using PashaLifeProject.Dto.ProductCategoryDto.ResponseDto;
using PashaLifeProject.Dto.ProductDto.ResponseDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PashaLifeProject.Service.Abstract
{
    public interface IProductCategoryService
    {
        public Task<List<ProductCategoryResponseDto>> GetAllProductCategories();
        public Task CreateProductCategory(ProductCategoryRequestDto productRequest);
        public Task UpdateProductCategory(ProductCategoryRequestDto productCategory, int id);
        public Task DeleteProductCategory( int id);

    }
}
