using Newtonsoft.Json;

namespace DesignPattern.Classes;

public class Bill
{
    private Dictionary<Sandwich, int> Sandwiches { get; set; } = new Dictionary<Sandwich, int>();
    private double TotalPrice { get; set; }

    public Bill()
    {
        TotalPrice = 0;
    }

    public List<Sandwich> GetSandwiches()
    {
        return Sandwiches.Keys.ToList();
    }

    public void AddNewSandwich(Sandwich sandwich)
    {
        Sandwiches.Add(sandwich, 1);
    }

    public void IncrementSandwich(Sandwich sandwich)
    {
        Sandwiches.Keys.ToList().ForEach(s =>
        {
            if (s.Name == sandwich.Name)
            {
                Sandwiches[s]++;
            }
        });
    }

    public async Task BillToJson()
    {
        TotalPrice = 0;
        List<dynamic> sandwichesList = new List<dynamic>();

        foreach (var sandwich in Sandwiches)
        {
            Console.WriteLine(sandwich.Value);
            Console.WriteLine(sandwich.Key.Price);

            dynamic sandwichesInfo = new
            {
                Quantity = sandwich.Value,
                Sandwich = sandwich.Key,
            };

            sandwichesList.Add(sandwichesInfo);
            TotalPrice += sandwich.Key.Price * sandwich.Value;
        }

        Console.WriteLine(TotalPrice);

        dynamic bill = new
        {
            Sandwiches = sandwichesList,
            TotalPrice = Math.Round(TotalPrice, 2).ToString("N2") + "€"
        };

        await File.WriteAllTextAsync("facture.json", JsonConvert.SerializeObject(bill));
    }

    public async Task BillToTxt()
    {
        TotalPrice = 0;
        string bill = "";

        foreach (var sandwich in Sandwiches)
        {
            bill += sandwich.Value + " " + sandwich.Key.Name + "\n";

            foreach (var ingredient in sandwich.Key.Ingredients)
            {
                bill += "   " + ingredient + "\n";
            }

            bill += "--------------------------------------------------------\n";
            TotalPrice += sandwich.Key.Price * sandwich.Value;
        }

        bill += "Total = " + Math.Round(TotalPrice, 2).ToString("N2") + "€\n";
        bill += "--------------------------------------------------------\n\n";

        await File.WriteAllTextAsync("facture.txt", bill);
    }
}