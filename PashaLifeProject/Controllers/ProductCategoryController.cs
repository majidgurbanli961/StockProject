using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PashaLifeProject.Dto.ProductCategoryDto.RequestDto;
using PashaLifeProject.Dto.ProductCategoryDto.ResponseDto;
using PashaLifeProject.Response;
using PashaLifeProject.Service.Abstract;
using PashaLifeProject.Validator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PashaLifeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }
        [HttpGet("getall")]

        public async Task<ApiValueResponse<List<ProductCategoryResponseDto>>> GetAllCategories()
        {
            var result = await productCategoryService.GetAllProductCategories();
            return new ApiValueResponse<List<ProductCategoryResponseDto>>(result);
  
        }
        [HttpPost("create")]
        public async Task<ApiResponse> CreateProductCategory(ProductCategoryRequestDto productCategoryRequest)
        {
            var validator = new ProductCategoryValidator();
            validator.ValidateAndThrow(productCategoryRequest);
            await productCategoryService.CreateProductCategory(productCategoryRequest);
            return new ApiResponse();
        }
        [HttpDelete("delete")]
        public async Task<ApiResponse> DeleteProductCategory(int id)
        {
            await productCategoryService.DeleteProductCategory(id);
            return new ApiResponse();
        }
        [HttpPut("update")]
        public async Task<ApiResponse> UpdateProductCategory(int id, ProductCategoryRequestDto productCategory)
        {
            await productCategoryService.UpdateProductCategory(productCategory, id);
            return new ApiResponse();
        }
    }
}
