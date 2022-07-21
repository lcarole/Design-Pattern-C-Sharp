using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
