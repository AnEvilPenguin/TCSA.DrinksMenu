using Drinks_Menu.Controller;
using Drinks_Menu.Model;
using Spectre.Console;

namespace Drinks_Menu.View;

public class MainMenu(DrinksController controller)
{
    private readonly Dictionary<string, Category> _categories = new();
    
    public async Task RunMenuAsync()
    {
        try
        {
            await BuildCategoryMap();
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex);
            return;
        }
        
        while (true)
        {
            var category = GetCategory();
            
            if (category == null)
                return;
        }
    }

    private async Task BuildCategoryMap()
    {
        var categories = await controller.ListCategories();
        
        if (categories == null)
            throw new Exception("Category list returned null");
        
        categories.ForEach(c => _categories.Add(c.Name, c));
    }

    private Category? GetCategory()
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose category:")
                .AddChoices(_categories.Keys.Union(["Exit"])));
        
        return _categories.GetValueOrDefault(choice);
    }
}