using System;
using System.Collections.Generic;
using System.Xml.Linq;

public class Folders
{
    public static IEnumerable<string> FolderNames(string xml, char startingLetter)
    {
        XDocument doc = XDocument.Parse(xml);
        IEnumerable<XElement> ele = doc.Descendants("folder");
        List<string> ret = new List<string>();
        foreach (XElement e in ele)
        {
            string s = e.Attribute("name").Value;
            if (s.StartsWith(startingLetter.ToString()))
            {
                ret.Add(s);
            }
        }
        return ret;
    }

    public static void Main(string[] args)
    {
        string xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<folder name=\"c\">" +
                "<folder name=\"program files\">" +
                    "<folder name=\"uninstall information\" />" +
                "</folder>" +
                "<folder name=\"users\" />" +
            "</folder>";

        // foreach (string name in Folders.FolderNames(xml, 'u'))
        //     Console.WriteLine(name);
    }
}