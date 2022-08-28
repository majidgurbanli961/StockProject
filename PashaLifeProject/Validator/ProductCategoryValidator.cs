using FluentValidation;
using PashaLifeProject.Dto.ProductCategoryDto.RequestDto;

namespace PashaLifeProject.Validator
{
    public class ProductCategoryValidator : AbstractValidator<ProductCategoryRequestDto>
    {
        public ProductCategoryValidator()
        {
            RuleFor(product => product.CategoryName).NotNull();
           


        }
    }
}
