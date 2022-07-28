using System.Text.Json;
using System.Xml.Serialization;
using DesignPattern.Classes;

namespace DesignPattern.File_Reader
{
    public class FileReader
    {
        public List<string> getCommandes(string path)
        {
            List<string> lines = new List<string>();
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.ReadLine != null)
                    {
                        lines.Add(sr.ReadLine());
                    }
                }
            }
            else
            {
                Console.WriteLine("Le fichier n'existe pas.");
                return null;
            }

            return lines;
        }

        public List<Dictionary<Sandwich, int>> GetCommandsJson(string filepath)
        {
            List<Dictionary<Sandwich, int>> commands = new List<Dictionary<Sandwich, int>>();
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    commands = JsonSerializer.Deserialize<List<Dictionary<Sandwich, int>>>(sr.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }

            return commands;
        }

        public List<Dictionary<Sandwich, int>> GetCommandsXml(string filepath)
        {
            List<Dictionary<Sandwich, int>> commands = new List<Dictionary<Sandwich, int>>();
            XmlSerializer xml = new XmlSerializer(commands.GetType());
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    commands = (List<Dictionary<Sandwich, int>>)xml.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }

            return commands;
        }

        public Dictionary<Sandwich, int> GetCommandsTxt(string filepath)
        {
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(filepath))
            {
                while (sr.Read())
            }
        }
    }
}