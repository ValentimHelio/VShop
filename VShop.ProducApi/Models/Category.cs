namespace VShop.ProducApi.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = String.Empty;

    public ICollection<Product> Products { get; set; }
}
