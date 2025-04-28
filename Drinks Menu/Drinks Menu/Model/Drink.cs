namespace Drinks_Menu.Model;

public class Drink
{
    public string Id { get; init; }
    public string Name { get; init; }
    public List<string> Tags { get; init; }
    public bool IsAlcoholic { get; init; }
    public string Glass { get; init; }
    public string Instructions { get; init; }
    public List<string> Ingredients { get; init; }
    public List<string> Measures { get; init; }
    public DateTime DateModified { get; init; }
    
    public Drink(DrinkRecord record)
    {
        Id = record.Id;
        Name = record.Name;
        Tags = record.Tags?.Split(',').ToList() ?? new List<string>();
        IsAlcoholic = record.Alcoholic == "Alcoholic";
        Glass = record.Glass;
        Instructions = record.Instructions;
        DateModified = DateTime.Parse(record.DateModified);
        
        Ingredients = ((List<string>)[
            record.Ingredient1,
            record.Ingredient2,
            record.Ingredient3,
            record.Ingredient4,
            record.Ingredient5,
            record.Ingredient6,
            record.Ingredient7,
            record.Ingredient8,
            record.Ingredient9,
            record.Ingredient10,
            record.Ingredient11,
            record.Ingredient12,
            record.Ingredient13,
            record.Ingredient14,
            record.Ingredient15
        ]).Where(x => !string.IsNullOrEmpty(x))
            .ToList();
        
        Measures =((List<string>)[
            record.Measure1,
            record.Measure2,
            record.Measure3,
            record.Measure4,
            record.Measure5,
            record.Measure6,
            record.Measure7,
            record.Measure8,
            record.Measure9,
            record.Measure10,
            record.Measure11,
            record.Measure12,
            record.Measure13,
            record.Measure14,
            record.Measure15
        ]).Where(x => !string.IsNullOrEmpty(x))
            .ToList();
    }
}