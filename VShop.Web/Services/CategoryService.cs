using System.Text;
using System.Text.Json;
using VShop.Web.Models;
using VShop.Web.Services.Contracts;

namespace VShop.Web.Services;

public class CategoryService : ICategoryService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _options;
    private const string apiEndpoint = "/api/categories/";

    private CategoryViewModel categoryVM;
    private IEnumerable<CategoryViewModel> categoriesVM;

    public CategoryService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
    {
        var client = _clientFactory.CreateClient("ProductApi");

        IEnumerable<CategoryViewModel> categories;

        using (var response = await client.GetAsync(apiEndpoint))
        {

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                categories = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }
        return categories;
    }

    public async Task<CategoryViewModel> FindCategoryById(int id)
    {
        var client = _clientFactory.CreateClient("ProductApi");

        using (var response = await client.GetAsync(apiEndpoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                categoryVM = await JsonSerializer.DeserializeAsync<CategoryViewModel>(apiResponse, _options);
            }
            else
            {
                return null;
            }

            return categoryVM;
        }
    }

    public async Task<CategoryViewModel> CreateCategory(CategoryViewModel categoryVM)
    {
        var client = _clientFactory.CreateClient("ProductApi");

        StringContent content = new StringContent(JsonSerializer.Serialize(categoryVM), Encoding.UTF8, "application/json");

        using (var response = await client.PostAsync(apiEndpoint, content))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                categoryVM = await JsonSerializer.DeserializeAsync<CategoryViewModel>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }
        return categoryVM;
    }

    public async Task<CategoryViewModel> UpdateCategory(CategoryViewModel categoryVM)
    {
        var client = _clientFactory.CreateClient("ProductApi");

        CategoryViewModel productUpdated = new CategoryViewModel();

        using (var response = await client.PutAsJsonAsync(apiEndpoint, categoryVM))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                productUpdated = await JsonSerializer.DeserializeAsync<CategoryViewModel>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }
        return productUpdated;
    }

    public async Task<bool> DeleteCategoryById(int id)
    {
        var client = _clientFactory.CreateClient("ProductApi");

        using (var response = await client.DeleteAsync(apiEndpoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
        }
        return false;
    }
}
