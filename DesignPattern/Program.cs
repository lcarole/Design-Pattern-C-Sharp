// See https://aka.ms/new-console-template for more information
using DesignPattern.Classes;
Sandwich JambonBeurre = new Sandwich("Jambon Beurre",new List<string> { "pain", "tranche de jambon", "beurre" },3.50);
Sandwich PouletCrudites = new Sandwich("Poulet crudites", new List<string> { "pain", "oeuf", "tomate", "tranche de poulet", "mayonnaise", "salade" }, 5);
Sandwich Dieppois = new Sandwich("Dieppois", new List<string> { "pain", "thon", "tomate", "mayonnaise", "salade" }, 4.50);

List<Sandwich> allSandwich = new List<Sandwich> { JambonBeurre, PouletCrudites, Dieppois };

Console.WriteLine("Saisissez votre commande : (Taper Exit ou metter une chaine vide pour quitter)");
string saisie = Console.ReadLine();

while (saisie != "Exit")
{
    Dictionary<string, int> detailsCommand = new Dictionary<string, int>();

    string[] listSandwich = saisie.Split(',');

    //Enlève les blancs en dévut et fin de ligne.
    for (int i = 0; i < listSandwich.Length; i++)
    {
        listSandwich[i] = listSandwich[i].Trim();
    }

    //Enlève les doublons du tableau et incrément la quantité de la première occurence trouvé.
    foreach (string sandwich in listSandwich)
    {
        string[] tmp = sandwich.Split(' ', 2);
        try
        {
            if (detailsCommand.ContainsKey(tmp[1]))
            {
                detailsCommand[tmp[1]] += Int32.Parse(tmp[0]);
            }
            else
            {
                detailsCommand.Add(tmp[1], Int32.Parse(tmp[0]));
            }
        }
        catch
        {
            Console.WriteLine("La saisie est invalide.");
        }
    }

    double prixTotal = 0;
    
    foreach (KeyValuePair<string, int> kvp in detailsCommand)
    {
        bool Exists = false;
        Console.WriteLine(kvp.Key + " " + kvp.Value);
        foreach (Sandwich sandwich in allSandwich)
        {
            if (sandwich.nom == kvp.Key)
            {
                foreach (string ingredient in sandwich.Ingredients)
                {
                    Console.WriteLine("    " + ingredient);
                }
                prixTotal += sandwich.prix * kvp.Value;
                Exists = true;
                break;
            }
        }

        if (!Exists)
        {
            Console.WriteLine(kvp.Key + " n'existe pas.");
        }
    }
    Console.WriteLine("Prix total = " + Math.Round(prixTotal, 2).ToString("N2") + "€");

    Console.WriteLine("Saisissez votre commande : (Taper Exit ou metter une chaine vide pour quitter)");
    saisie = Console.ReadLine();
}
//Console.ReadLine();