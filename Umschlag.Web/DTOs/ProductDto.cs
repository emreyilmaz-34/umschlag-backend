using System.ComponentModel.DataAnnotations;

namespace Umschlag.Web.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} field is required")]
        public string Name { get; set; }
        [Range(minimum:1, maximum:100, ErrorMessage = "{0} must be between 1-100")]
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
