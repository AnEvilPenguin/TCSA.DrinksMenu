using Drinks_Menu.Controller;
using Drinks_Menu.Model;
using Drinks_Menu.View;

using var drinks = new DrinksController();

var menu = new MainMenu(drinks);

await menu.RunMenuAsync();
    