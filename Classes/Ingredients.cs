using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieBook.Classes
{
    public class Ingredients
    {
        int ID;
        string Name;
        string Instructions;

        public int _ID { get => ID;}
        public string _Name { get => Name; }

        public string _Instructions { get => Instructions; }
        public Ingredients (int id, string name, string instructions)
        {
            ID = id;
            Name = name;
            Instructions = instructions;
        }
    }
}
