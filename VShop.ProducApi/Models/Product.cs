namespace VShop.ProducApi.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; } = String.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = String.Empty;
    public long Stock {  get; set; }
    public string ImageURL { get; set; } = String.Empty;

    public Category category { get; set; }
    public int CategoryId { get; set; }
}
