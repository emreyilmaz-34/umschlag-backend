using System.ComponentModel.DataAnnotations;

namespace Umschlag.Web.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} field can not be empty")]
        public string Name { get; set; }
    }
}
