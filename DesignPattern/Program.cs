// See https://aka.ms/new-console-template for more information

using DesignPattern.Classes;
using DesignPattern.Singleton;

Console.WriteLine("Saisissez votre commande : (Taper Exit ou metter une chaine vide pour quitter)");
string saisie = Console.ReadLine();

while (saisie != "Exit" && !string.IsNullOrWhiteSpace(saisie))
{
    Bill bill = new Bill();

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

        foreach (Sandwich sandwich in Catalogue.Instance().ListSandwich)
        {
            if (sandwich.Nom == kvp.Key)
            {
                bill.AddNewSandwich(sandwich);
                if (kvp.Value > 1)
                {
                    for (int i = 0; i < kvp.Value - 1; i++)
                    {
                        bill.IncrementSandwich(sandwich);
                    }
                }

                foreach (string ingredient in sandwich.Ingredients)
                {
                    Console.WriteLine("    " + ingredient);
                }

                prixTotal += sandwich.Prix * kvp.Value;
                Exists = true;
                break;
            }
        }

        if (!Exists)
        {
            Console.WriteLine(kvp.Key + " n'existe pas.");
        }
    }

    Console.WriteLine("Prix total = " + Math.Round(prixTotal, 2).ToString("N2") + " EUR");

    await bill.BillToString();
    await bill.BillToJson();

    Console.WriteLine("Saisissez votre commande : (Taper Exit ou metter une chaine vide pour quitter)");
    saisie = Console.ReadLine();
}
//Console.ReadLine();