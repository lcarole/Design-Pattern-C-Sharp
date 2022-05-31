using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class Sandwich
    {
        private string nom { get; set; }
        private List<string> Ingredients { get; set; } = new List<string>();
        private double prix { get; set; }
    }
}
