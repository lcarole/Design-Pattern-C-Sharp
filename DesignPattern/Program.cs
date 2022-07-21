// See https://aka.ms/new-console-template for more information
using DesignPattern.Classes;
using DesignPattern.Lecture_de_fichiers;
using DesignPattern.Singleton;

//Console.WriteLine("Saisissez votre commande : (Taper Exit ou metter une chaine vide pour quitter)");
List<string> lignes = new FileReader().getCommandes(@"C:\Users\luigi\Desktop\commande.txt");
//string saisie = Console.ReadLine();
foreach (string saisie in lignes)
{

    while (saisie != "Exit" && !string.IsNullOrWhiteSpace(saisie))
    {
        Dictionary<string, int> detailsCommand = new Dictionary<string, int>();

        string[] listSandwich = saisie.Split(',');

        //Enlève les blancs en début et fin de ligne.
        for (int i = 0; i < listSandwich.Length; i++)
        {
            listSandwich[i] = listSandwich[i].Trim();
        }

        //Enlève les doublons du tableau et incrémente la quantité de la première occurence trouvé.
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
            foreach (Sandwich sandwich in Catalogue.Instance().ListSandwich)
            {
                if (sandwich.Nom == kvp.Key)
                {
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

        //Console.WriteLine("Saisissez votre commande : (Taper Exit ou metter une chaine vide pour quitter)");
        //saisie = Console.ReadLine();
    }
}
//Console.ReadLine();
