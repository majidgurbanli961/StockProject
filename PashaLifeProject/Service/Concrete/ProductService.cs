using PashaLifeProject.Data.Entities;
using PashaLifeProject.Dto.ProductDto.RequestDto;
using PashaLifeProject.Dto.ProductDto.ResponseDto;
using PashaLifeProject.Errors;
using PashaLifeProject.Repo.Abstract;
using PashaLifeProject.Service.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PashaLifeProject.Service.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo productRepo;
        private readonly IProductCategoryRepo productCategoryRepo;

        public ProductService(IProductRepo productRepo, IProductCategoryRepo productCategoryRepo)
        {
            this.productRepo = productRepo;
            this.productCategoryRepo = productCategoryRepo;
        }

        public async Task CreateProduct(ProductRequestDto productRequest)
        {
            var productCategory =  await productCategoryRepo.GetByIdAsync(productRequest.ProductCategoryId);
           
            var product = new Product()
            {
                ProductName = productRequest.ProductName,
                Price = productRequest.Price,
                Created = System.DateTime.Now,
                State = productRequest.State,
                IsDeleted = false,
                ProductCategoryId = productCategory.CategoryId

            };
            await productRepo.CreateProduct(product);
        }

        public async Task DeleteProduct(int productId)
        {
           var product = await productRepo.GetProductById(productId);
            await productRepo.DeleteProduct(product);

        }

        public async Task<List<ProductResponseDto>> GetAllProducts()
        {
            var products =  await productRepo.GetAllProducts();
            var productResponses = new List<ProductResponseDto>();
            foreach (var product in products)
            {
                var  productResponse = new ProductResponseDto()
                {
                    ProductName = product.ProductName,
                    Price = product.Price,
                    CreatedDate = product.Created,
                    State = product.State,
                    ProductCategoryName = product.ProductCategory.CategoryName
                };
                productResponses.Add(productResponse);

            }
            return productResponses;
        }

        public async Task<ProductResponseDto> GetProductById(int productId)
        {
            var product = await productRepo.GetProductById(productId);
            var productResponse = new ProductResponseDto()
            {
                ProductName = product.ProductName,
                Price = product.Price,
                CreatedDate = product.Created,
                State = product.State,
                ProductCategoryName = product.ProductCategory.CategoryName
            };
            return productResponse;
        }

        public async Task UpdateProduct(int productId, ProductRequestDto productRequest)
        {
            var product = await productRepo.GetProductById(productId);
            product.ProductName = productRequest.ProductName;
            product.Price = productRequest.Price;
            product.ProductCategoryId = productRequest.ProductCategoryId;
            product.State = productRequest.State;
            await productRepo.UpdateProduct(product);
        }
    }
}
