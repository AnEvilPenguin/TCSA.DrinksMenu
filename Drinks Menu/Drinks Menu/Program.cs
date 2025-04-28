using Drinks_Menu.Controller;
using Drinks_Menu.Model;

using var drinks = new DrinksController();

var categories = await drinks.ListCategories();

foreach (var category in categories ?? Enumerable.Empty<Category>())
    Console.WriteLine(category);
    