using System.Xml;

namespace DesignPattern.Classes;

public class WritingXml
{
    static void xmlFacture(string facture)
    {

        Console.WriteLine(facture);

        // XmlWriter xmlWriter = XmlWriter.Create("Facture.xml");
        //
        // xmlWriter.WriteStartDocument();
        // xmlWriter.WriteStartElement("sandwich");
        //
        // xmlWriter.WriteStartElement("user");
        // xmlWriter.WriteAttributeString("age", "42");
        // xmlWriter.WriteString("John Doe");
        // xmlWriter.WriteEndElement();
    }
}