using System.Text.Json.Serialization;

namespace Drinks_Menu.Model;

public record Category(
    [property: JsonPropertyName("strCategory")] string Name);