using System.ComponentModel.DataAnnotations;
using VShop.ProducApi.Models;

namespace VShop.ProducApi.DTOs;

public class CategoryDTO
{
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string Name { get; set; } = String.Empty;
    public ICollection<ProductDTO> Products { get; set; }

}
