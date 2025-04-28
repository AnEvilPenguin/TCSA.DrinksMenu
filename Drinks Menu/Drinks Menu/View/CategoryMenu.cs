using Drinks_Menu.Controller;
using Drinks_Menu.Model;
using Spectre.Console;

namespace Drinks_Menu.View;

public class CategoryMenu (DrinksController controller, Category category)
{
    private readonly Dictionary<string, string> _idMap = new();
    private readonly Dictionary<string, Drink> _drinkMap = new();
    
    public async Task RunMenuAsync()
    {
        await BuildIdMap();

        while (true)
        {
            var drink = await GetDrink();
            
            if (drink == null)
                return;
            
            DrinkView.Show(drink);
        }
    }

    private async Task BuildIdMap()
    {
        var drinkIds = await controller.ListDrinks(category);
        
        if (drinkIds == null)
            throw new Exception($"Failed to find drinks in category: {category.Name}");
        
        drinkIds.ForEach(id => _idMap[id.Name] = id.Id);
    }

    private async Task<Drink?> GetDrink()
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title($"Category: [green]{category.Name}[/] | Choose drink:")
                .AddChoices(_idMap.Keys.Union(["Back"])));
        
        if (choice.Equals("Back"))
            return null;

        var id = _idMap[choice];

        if (!_drinkMap.ContainsKey(id))
        {
            var drink = await controller.GetDrink(id);

            _drinkMap[id] = drink ?? throw new Exception($"Failed to find drink: {choice}");
        }
            
        return _drinkMap[id];
    }
}