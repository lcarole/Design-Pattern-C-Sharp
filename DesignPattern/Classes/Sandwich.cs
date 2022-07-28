namespace DesignPattern.Classes
{
    public class Sandwich
    {
        public Sandwich(string name, List<string> ingredients, double price)
        {
            this.name = name;
            this.ingredients = ingredients;
            this.price = price;
        }

        private string name;
        private List<string> ingredients = new List<string>();
        private double price;

        public string Name
        {
            get { return name; }
        }

        public List<string> Ingredients
        {
            get { return ingredients; }
        }

        public double Price
        {
            get { return price; }
        }
    }
}