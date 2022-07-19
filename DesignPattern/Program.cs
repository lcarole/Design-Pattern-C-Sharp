// See https://aka.ms/new-console-template for more information
using DesignPattern.Classes;
using DesignPattern.Singleton;
using System.Text.Json;

Console.WriteLine("Saisissez votre commande : (Taper Exit ou metter une chaine vide pour quitter)");
string saisie = Console.ReadLine();

string facture = "";
List<Sandwich> jsonFacture = new List<Sandwich>();

while (saisie != "Exit" && !string.IsNullOrWhiteSpace(saisie))
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

        Console.WriteLine(kvp.Value + " " + kvp.Key);
        facture += kvp.Value + " " + kvp.Key + " ";

        foreach (Sandwich sandwich in Catalogue.Instance().ListSandwich)
        {
            if (sandwich.Nom == kvp.Key)
            {
                facture += (Math.Round(sandwich.Prix, 2) * kvp.Value).ToString("N2") + "€\n";
                jsonFacture.Add(sandwich);

                foreach (string ingredient in sandwich.Ingredients)
                {
                    Console.WriteLine("    " + ingredient);
                    facture += "    " + ingredient + "\n";
                }
                prixTotal += sandwich.Prix * kvp.Value;
                Exists = true;
                facture += "--------------------------------------------------------\n";
                break;
            }
        }

        if (!Exists)
        {
            Console.WriteLine(kvp.Key + " n'existe pas.");
        }
    }
    Console.WriteLine("Prix total = " + Math.Round(prixTotal, 2).ToString("N2") + " EUR");

    facture += "Prix total = " + Math.Round(prixTotal, 2).ToString("N2") + "€\n\n";
    await File.WriteAllTextAsync("facture.txt", facture);

    string json = JsonSerializer.Serialize(jsonFacture);
    await File.WriteAllTextAsync("facture.json", json);

    Console.WriteLine("Saisissez votre commande : (Taper Exit ou metter une chaine vide pour quitter)");
    saisie = Console.ReadLine();
}
//Console.ReadLine();
