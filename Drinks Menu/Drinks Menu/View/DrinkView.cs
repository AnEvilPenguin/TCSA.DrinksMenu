using Drinks_Menu.Model;
using Spectre.Console;

namespace Drinks_Menu.View;

public static class DrinkView
{
    public static void Show(Drink drink)
    {
        AnsiConsole.Clear();
        
        var title = new Rule($"[green]{drink.Name}[/]")
        {
            Style = Style.Parse("red dim"),
            Justification = Justify.Center
        };

        var detailGrid = new Grid();
        detailGrid.AddColumn();
        detailGrid.AddColumn();
        
        detailGrid.AddRow("Id:", drink.Id);
        
        if (drink.Tags.Count > 0)
            detailGrid.AddRow("Tags", drink.Tags.Aggregate((a, b) => $"{a}, {b}"));
        
        detailGrid.AddRow("Alcoholic", $"{drink.IsAlcoholic}");
        
        if (!string.IsNullOrWhiteSpace(drink.Glass))
            detailGrid.AddRow("Glass", drink.Glass);

        var details = new Layout("Details")
            .SplitRows(
                new Layout("Name")
                    .Update(title)
                    .Size(1),
                new Layout("DetailGrid")
                    .Update(detailGrid),
                new Layout("Instructions").Update(new Text(drink.Instructions)));
        
        var ingredientsTable = new Table
        {
            Title = new TableTitle("Ingredients"),
            Expand = true
        };
        
        ingredientsTable.AddColumn("Ingredient");
        ingredientsTable.AddColumn("Measure");

        foreach (var ingredient in drink.Ingredients)
        {
            ingredientsTable.AddRow(ingredient.Item1 ?? "", ingredient.Item2 ?? "");
        }
        
        var ingredients = new Layout("Ingredients")
            .Update(ingredientsTable);

        var layout = new Layout("Root")
            .SplitColumns(details, ingredients);
        
        AnsiConsole.Write(layout);
        
        Pause();
    }
    
    private static void Pause()
    {
        Console.ReadKey();
        Console.Clear();
    }
}