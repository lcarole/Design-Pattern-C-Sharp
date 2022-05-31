using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Classes
{
    public class Sandwich
    {
        public Sandwich(string nom, List<string> ingredients, double prix)
        {
            this.nom = nom;
            Ingredients = ingredients;
            this.prix = prix;
        }

        public string nom { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
        public double prix { get; set; }
    }
}
