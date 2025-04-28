using System.Text.Json.Serialization;

namespace Drinks_Menu.Model;

public record DrinkList(
    [property: JsonPropertyName("drinks")] List<DrinkRecord> Drinks);