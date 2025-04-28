using System.Text.Json;
using Drinks_Menu.Model;

namespace Drinks_Menu.Controller;

public class DrinksController : IDisposable
{
    private readonly HttpClient _client = new()
    {
        BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/")
    };
    
    public async Task<List<Category>?> ListCategories()
    {
        await using Stream stream = await _client.GetStreamAsync("list.php?c=list");
        
        var categories = await JsonSerializer.DeserializeAsync<CategoryList>(stream);
        
        return categories?.Categories;
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}