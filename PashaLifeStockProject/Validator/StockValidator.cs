using FluentValidation;
using PashaLifeStockProject.Dto;

namespace PashaLifeStockProject.Validator
{
    public class StockValidator : AbstractValidator<StockDto>
    {
        public StockValidator()
        {
            RuleFor(stock => stock.ChangedProductCount).GreaterThan(0);
        }
    }
}
