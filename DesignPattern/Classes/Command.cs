namespace DesignPattern.Classes
{
    public class Command
    {
        private List<Sandwich> sandwichList = new List<Sandwich>();

        public Command(List<Sandwich> sandwichList)
        {
            this.sandwichList = sandwichList;
        }

        public List<Sandwich> SandwichList
        {
            get { return sandwichList; }
        }
    }
}