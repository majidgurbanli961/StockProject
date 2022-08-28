using FluentValidation;
using PashaLifeProject.Data.Entities;
using PashaLifeProject.Dto.ProductDto.RequestDto;

namespace PashaLifeProject.Validator
{
    public class ProductValidator : AbstractValidator<ProductRequestDto>
    {
        public ProductValidator()
        {
            RuleFor(product => product.ProductName).NotNull();
            RuleFor(product => product.Price).GreaterThan(0);
            RuleFor(product => product.State).NotNull();


        }
    }
}
