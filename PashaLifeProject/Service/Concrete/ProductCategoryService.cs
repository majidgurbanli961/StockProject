using PashaLifeProject.Data.Entities;
using PashaLifeProject.Dto.ProductCategoryDto.RequestDto;
using PashaLifeProject.Dto.ProductCategoryDto.ResponseDto;
using PashaLifeProject.Repo.Abstract;
using PashaLifeProject.Service.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PashaLifeProject.Service.Concrete
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepo productCategoryRepo;

        public ProductCategoryService(IProductCategoryRepo productCategoryRepo)
        {
            this.productCategoryRepo = productCategoryRepo;
        }

        public async Task CreateProductCategory(ProductCategoryRequestDto productRequest)
        {
            var productCategory = new ProductCategory()
            {
                CategoryName = productRequest.CategoryName
            };
           await  productCategoryRepo.CreateProductCategory(productCategory);
        }

        public async Task DeleteProductCategory(int id)
        {
            var productCategory = await  productCategoryRepo.GetByIdAsync(id);
            await productCategoryRepo.DeleteProductCategory(productCategory);
        }

        public async Task<List<ProductCategoryResponseDto>> GetAllProductCategories()
        {
            var productCategories = await productCategoryRepo.GetAllProductCategories();
            var productCategoriesResponse = new List<ProductCategoryResponseDto>();
            foreach (var productCategory in productCategories)
            {
                var productCategoryResponse = new ProductCategoryResponseDto()
                {
                    CategoryId = productCategory.CategoryId,
                    CategoryName = productCategory.CategoryName
                };
                productCategoriesResponse.Add(productCategoryResponse);

            }
            return productCategoriesResponse;

        }

        public async Task UpdateProductCategory(ProductCategoryRequestDto productCategory, int id)
        {
            var productCategoryMain = await productCategoryRepo.GetByIdAsync(id);
            productCategoryMain.CategoryName = productCategory.CategoryName;
            await productCategoryRepo.UpdateProductCategory(productCategoryMain);

        }
    }
}
