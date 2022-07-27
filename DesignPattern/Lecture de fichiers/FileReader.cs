using DesignPattern.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesignPattern.Lecture_de_fichiers
{
    public class FileReader
    {
        public List<string> getCommandes(string path)
        {
            List<string> lignes = new List<string>();
            if (File.Exists(path))
            {
                using(StreamReader sr = new StreamReader(path))
                {
                    while (sr.ReadLine != null)
                    {
                        lignes.Add(sr.ReadLine());
                    }
                }
            }
            else
            {
                Console.WriteLine("Le fichier n'existe pas.");
                return null;
            }
            return lignes;
        }

        public List<Dictionary<Sandwich,int>> GetCommandesJson(string filepath)
        {
            List<Dictionary<Sandwich,int>> Commandes = new List<Dictionary<Sandwich, int>>();
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    Commandes =  JsonSerializer.Deserialize<List<Dictionary<Sandwich, int>>>(sr.ReadToEnd());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
            return Commandes;
        }

        public List<Dictionary<Sandwich, int>> GetCommandesXml(string filepath)
        {
            List<Dictionary<Sandwich,int>> Commandes = new List<Dictionary<Sandwich, int>>();
            XmlSerializer xml = new XmlSerializer(Commandes.GetType());
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    Commandes = (List<Dictionary<Sandwich, int>>)xml.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
            return Commandes;
        }

        public Dictionary<Sandwich, int> GetCommandesTxt(string filepath)
        {
            List<string> Lignes = new List<string>();
            using(StreamReader sr = new StreamReader(filepath))
            {
                while(sr.Read())
            }
        }
    }
}
