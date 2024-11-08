using CookieBook.Classes;
using System.Net.Http.Headers;
using System.Xml.Linq;
var WheatFlour = new Ingredients(1, "Wheat flour", "Sieve. Add to other ingredients.");
var CoconutFlour = new Ingredients(2, "Coconut flour", "Sieve. Add to other ingredients.");
var Butter = new Ingredients(3, "Butter", "Melt on low heat. Add to other ingredients.");
var Chocolate = new Ingredients(4, "Chocolate", "Melt in a water bath. Add to other ingredients.");
var Sugar = new Ingredients(5, "Sugar", "Add to other ingredients.");
var Cardamom = new Ingredients(6, "Cardamom", "Take half a teaspoon. Add to other ingredients.");
var Cinnamon = new Ingredients(7, "Cinnamon", "Take half a teaspoon. Add to other ingredients.");
var CocoaPowder = new Ingredients(8, "Cocoa powder", "Add to other ingredients.");


List<Ingredients> ingredients = new List<Ingredients>
{
    WheatFlour,
    CoconutFlour,
    Butter,
    Chocolate,
    Sugar,
    Cardamom,
    Cinnamon,
    CocoaPowder
};



var Recipes = new Recipe();
var RecipeFIle = Recipes.BuildFilePath();
if (File.Exists(RecipeFIle))
{
    Console.WriteLine("Existing recipes are:\r");
    Console.WriteLine();
    Recipes.ReadFromTextFile(ingredients);
}
Console.WriteLine();
Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
Console.WriteLine();
ReadIngredients();
Console.WriteLine();
Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");
Recipes.SelectIngredients(ingredients);






void ReadIngredients ()
{
    foreach (Ingredients ingredient in ingredients)
    {
        Console.WriteLine(ingredient._ID + ". " + ingredient._Name);
    }

}

