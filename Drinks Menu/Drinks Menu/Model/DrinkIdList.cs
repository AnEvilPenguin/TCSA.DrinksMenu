using System.Text.Json.Serialization;

namespace Drinks_Menu.Model;

public record DrinkIdList(
    [property: JsonPropertyName("drinks")] List<DrinkId> Drinks);