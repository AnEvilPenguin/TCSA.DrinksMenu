namespace Drinks_Menu.Model;

public class Drink
{
    public string Id { get; init; }
    public string Name { get; init; }
    public List<string> Tags { get; init; }
    public bool IsAlcoholic { get; init; }
    public string Glass { get; init; }
    public string Instructions { get; init; }
    public List<Tuple<string, string>> Ingredients { get; init; }
    public DateTime DateModified { get; init; }
    
    public Drink(DrinkRecord record)
    {
        Id = record.Id;
        Name = record.Name;
        Tags = record.Tags?.Split(',').ToList() ?? new List<string>();
        IsAlcoholic = record.Alcoholic == "Alcoholic";
        Glass = record.Glass;
        Instructions = record.Instructions;
        if (record.DateModified != null)
            DateModified = DateTime.Parse(record.DateModified);
        
        Ingredients = ((List<Tuple<string, string>>)[
            new Tuple<string, string>(record.Ingredient1, record.Measure1),
            new Tuple<string, string>(record.Ingredient2, record.Measure2),
            new Tuple<string, string>(record.Ingredient3, record.Measure3),
            new Tuple<string, string>(record.Ingredient4, record.Measure4),
            new Tuple<string, string>(record.Ingredient5, record.Measure5),
            new Tuple<string, string>(record.Ingredient6, record.Measure6),
            new Tuple<string, string>(record.Ingredient7, record.Measure7),
            new Tuple<string, string>(record.Ingredient8, record.Measure8),
            new Tuple<string, string>(record.Ingredient9, record.Measure9),
            new Tuple<string, string>(record.Ingredient10, record.Measure10),
            new Tuple<string, string>(record.Ingredient11, record.Measure11),
            new Tuple<string, string>(record.Ingredient12, record.Measure12),
            new Tuple<string, string>(record.Ingredient13, record.Measure13),
            new Tuple<string, string>(record.Ingredient14, record.Measure14),
            new Tuple<string, string>(record.Ingredient15, record.Measure15)
        ]).Where(x => !string.IsNullOrEmpty(x.Item1))
            .ToList();
    }
}