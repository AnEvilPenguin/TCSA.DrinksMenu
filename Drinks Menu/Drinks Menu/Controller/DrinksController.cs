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

    public async Task<List<DrinkId>?> ListDrinks(Category category)
    {
        await using Stream stream = await _client.GetStreamAsync($"filter.php?c={category.Name.Replace(" ", "_")}");
        
        var drinkIds = await JsonSerializer.DeserializeAsync<DrinkIdList>(stream);
        
        return drinkIds?.Drinks;
    }

    public async Task<Drink?> GetDrink(string drinkId)
    {
        await using Stream stream = await _client.GetStreamAsync($"lookup.php?i={drinkId}");
        
        var drinks = await JsonSerializer.DeserializeAsync<DrinkList>(stream);
        
        var record = drinks?.Drinks.FirstOrDefault();
        
        if (record == null)
            throw new Exception($"Failed to find drink: {drinkId}");
        
        return new Drink(record);
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}