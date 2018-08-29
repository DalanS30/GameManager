using System.Collections.Generic;
using System.Xml.XPath;

namespace GameManager
{
    public class GameFileHandler
    {
        public static GameFileHandler Instance { get; set; }

        private XPathDocument Document;

        public GameFileHandler(string filePath)
        {
            Document = new XPathDocument(filePath);
        }

        public Scenario GetScenario(string id)
        {
            List<Choice> choices = new List<Choice>();
            XPathNavigator n = Document.CreateNavigator();
            string gameText = n.SelectSingleNode($"/Reaver/Path[@ID='{id}']/GameText").Value;
            foreach (XPathNavigator item in n.Select($"/Reaver/Path[@ID='{id}']/Choices/Choice"))
            {
                choices.Add(new Choice() { Number = int.Parse(item.GetAttribute("Number", string.Empty)), Text = item.GetAttribute("Text", string.Empty) });
            }
            return new Scenario() { ID = id, Text = gameText, Choices = choices };
        }
    }
}
