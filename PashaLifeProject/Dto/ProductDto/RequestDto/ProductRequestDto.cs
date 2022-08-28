namespace PashaLifeProject.Dto.ProductDto.RequestDto
{
    public class ProductRequestDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string State { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
