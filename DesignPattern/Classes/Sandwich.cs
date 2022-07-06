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
            this.ingredients = ingredients;
            this.prix = prix;
        }

        private string nom;
        private List<string> ingredients = new List<string>();
        private double prix;

        public string Nom { get { return nom; } }
        public List<string> Ingredients { get { return ingredients; } }
        public double Prix { get { return prix; } }
    }
}
