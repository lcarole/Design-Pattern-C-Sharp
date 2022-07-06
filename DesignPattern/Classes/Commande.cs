using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Classes
{
    public class Commande
    {
        private List<Sandwich> sandwichList = new List<Sandwich>();

        public Commande(List<Sandwich> sandwichList)
        {
            this.sandwichList = sandwichList;
        }

        public List<Sandwich> SandwichList { 
            get {
                return sandwichList;
            }
        }
    }
}
