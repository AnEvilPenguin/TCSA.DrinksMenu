using System.Text.Json.Serialization;

namespace Drinks_Menu.Model;

public record CategoryList(
    [property: JsonPropertyName("drinks")] List<Category> Categories);