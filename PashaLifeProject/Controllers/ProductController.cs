using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PashaLifeProject.Dto.ProductDto.RequestDto;
using PashaLifeProject.Dto.ProductDto.ResponseDto;
using PashaLifeProject.Response;
using PashaLifeProject.Service.Abstract;
using PashaLifeProject.Validator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PashaLifeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet("getallproducts")]
        public async Task<ApiValueResponse<List<ProductResponseDto>>> GetAllProducts()
        {
            var response = await productService.GetAllProducts();
            return new ApiValueResponse<List<ProductResponseDto>>(response);

        }
        [HttpGet("getbyid")]
        public async Task<ApiValueResponse<ProductResponseDto>> GetProductById(int productId)
        {
            var response = await productService.GetProductById(productId);
            return new ApiValueResponse<ProductResponseDto>(response);

        }
        [HttpPost("create")]
        public async Task<ApiResponse> CreateProduct(ProductRequestDto productRequest)
        {
            var validator = new ProductValidator();
            validator.ValidateAndThrow(productRequest);
            await productService.CreateProduct(productRequest);

            return new ApiResponse();
        }
        [HttpDelete("delete")]
        public async Task <ApiResponse> DeleteProduct(int productId)
        {
            await productService.DeleteProduct(productId);

            return new ApiResponse();
        }
        [HttpPut("update")]
        public async Task <ApiResponse> UpdateProduct(int productId, ProductRequestDto updatedProduct)
        {
            var validator = new ProductValidator();
            validator.ValidateAndThrow(updatedProduct);
            await productService.UpdateProduct(productId, updatedProduct);
            return new ApiResponse();
        }
    }
}
