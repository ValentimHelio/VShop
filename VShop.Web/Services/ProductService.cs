using System.Text.Json;
using VShop.Web.Models;
using VShop.Web.Services.Contracts;

namespace VShop.Web.Services;

public class ProductService : IProductService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _options;
    private const string apiEndpoint = "/api/products/";
    private ProductViewModel productVM;
    private IEnumerable<ProductViewModel> productsVM;

    public ProductService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    }

    public Task<ProductViewModel> CreateProduct(ProductViewModel productVM, string token)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProductById(int id, string token)
    {
        throw new NotImplementedException();
    }

    public Task<ProductViewModel> FindProductById(int id, string token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductViewModel>> GetAllProducts(string token)
    {
        throw new NotImplementedException();
    }

    public Task<ProductViewModel> UpdateProduct(ProductViewModel productVM, string token)
    {
        throw new NotImplementedException();
    }
}
