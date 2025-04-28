using System.Text.Json.Serialization;

namespace Drinks_Menu.Model;

public record DrinkId(
    [property: JsonPropertyName("strDrink")] string Name,
    [property: JsonPropertyName("idDrink")] string Id);