using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CookieBook.Classes
{
    public class Recipe
    {
       public List<string> _Recipe;
       public List<string> recipe 
        {
            get { return _Recipe; }

            set { _Recipe = value; }
        }

        public void ReadFromTextFile(List<Ingredients> ingredients)
        {
            var FileContent = File.ReadAllText(BuildFilePath());
            var recipesFromFile = FileContent.Split(Environment.NewLine);
            int recipeCount = 0;
            
            foreach (var recipe in recipesFromFile)
            {
                recipeCount++;
                if (recipe == "")
                {
                    break;
                }
                var recipeIDs = recipe.Split(",");
                Console.WriteLine($"*****{recipeCount}*****");
                foreach ( var recipeID in recipeIDs)
                {
                    //var recipeId = JsonSerializer.Deserialize<string>(recipeID);
                    foreach (Ingredients ingredient in ingredients)
                    {
                        if (int.Parse(recipeID) == ingredient._ID)
                        {
                            Console.WriteLine($"{ingredient._Name}. {ingredient._Instructions}");
                            break;
                        }
                    }

                }
                Console.WriteLine();

            }
        }

        public void WriteRecipesToTextFile()
        {
            File.AppendAllText(BuildFilePath(), Format());
            File.AppendAllText(BuildFilePath(), Environment.NewLine);
        }

        public string BuildFilePath()
        {
            return "recipes.txt";
            //return "recipes.json";
        }

        public string Format()
        {
            return string.Join(",", _Recipe);
            //return string.Join(",", JsonSerializer.Serialize(_Recipe));
        }

        public void SelectIngredients(List<Ingredients> ingredients)
        {
            string Input = Console.ReadLine();
            bool IsInputNumber = int.TryParse(Input, out int ingredientID);
            List<string> recipes = new List<string>();
            
            
            while (IsInputNumber)
            {
                bool IsInputAnIngredientInTheList = false;
                foreach (Ingredients ingredient in ingredients)
                {
                    if (ingredientID == ingredient._ID)
                    {
                        IsInputAnIngredientInTheList = true;
                        recipes.Add($"{ingredient._ID}");
                        break;
                    }
                }

                if (IsInputAnIngredientInTheList == false)
                {
                    Console.WriteLine("The ID entered is not an ingredient.");
                    Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");
                }
               
                Input = Console.ReadLine();
                IsInputNumber = int.TryParse(Input, out ingredientID);
            }
            

            if (recipes.Count > 0)
            {
                this.recipe = recipes;
                this.WriteRecipesToTextFile();
            }
            else
            {
                Console.WriteLine("No ingredients have been selected.Recipe will not be saved.");
            }
        }


    }
    
}
