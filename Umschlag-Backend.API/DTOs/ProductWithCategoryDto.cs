namespace Umschlag_Backend.API.DTOs
{
    public class ProductWithCategoryDto: ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
