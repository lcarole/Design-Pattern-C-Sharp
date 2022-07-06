using DesignPattern.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Singleton
{
    public class Catalogue
    {
        private List<Sandwich> listSandwich = new List<Sandwich>();
        private static Catalogue instance = null;
        private Catalogue() {
            listSandwich = new List<Sandwich> {
                new Sandwich("Jambon Beurre",new List<string> { "pain", "tranche de jambon", "beurre" },3.50),
                new Sandwich("Poulet crudites", new List<string> { "pain", "oeuf", "tomate", "tranche de poulet", "mayonnaise", "salade" }, 5),
                new Sandwich("Dieppois", new List<string> { "pain", "thon", "tomate", "mayonnaise", "salade" }, 4.50)
            };
        }
        public static Catalogue Instance()
        {
            if (instance == null)
            {
                return new Catalogue();                
            }
            return instance;
        }

        public List<Sandwich> ListSandwich 
        { 
            get
            {
                return listSandwich;
            }
        }
    }
}
