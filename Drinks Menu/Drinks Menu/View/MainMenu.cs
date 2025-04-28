using Drinks_Menu.Controller;
using Drinks_Menu.Model;
using Spectre.Console;

namespace Drinks_Menu.View;

public class MainMenu(DrinksController controller)
{
    private readonly Dictionary<string, Category> _categories = new();
    private readonly Dictionary<Category, CategoryMenu> _categoryMenus = new();
    
    public async Task RunMenuAsync()
    {
        AnsiConsole.Clear();
        
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
            
            await _categoryMenus[category].RunMenuAsync();
        }
    }

    private async Task BuildCategoryMap()
    {
        var categories = await controller.ListCategories();
        
        if (categories == null)
            throw new Exception("Category list returned null");
        
        categories.ForEach(c =>
        {
            _categories.Add(c.Name, c);
            _categoryMenus.Add(c, new CategoryMenu(controller, c));
        });
    }

    private Category? GetCategory()
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose [green]category[/]:")
                .AddChoices(_categories.Keys.Union(["Exit"])));
        
        return _categories.GetValueOrDefault(choice);
    }
}