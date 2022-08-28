using System;

namespace PashaLifeProject.Dto.ProductDto.ResponseDto
{
    public class ProductResponseDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string State { get; set; }
        public string ProductCategoryName { get; set; }
    }
}
