using System;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json;


namespace remsklad_C_
{
    class GetXmlElement
    {
        static public Dictionary<string,WarehouseItem> GetXmlElementByArticle(string token, List<string> articles , int pageCount = 26)
        {
            var ListOfItems = new Dictionary<string,WarehouseItem>();

            for (int i = 1; i < pageCount; i++)
            {
                string responceMessage = ConnectionWithRemonline.getPageFromRemonline(token, i);
                string json = responceMessage.ToString();
                //Console.WriteLine(json);
                XmlDocument node = JsonConvert.DeserializeXmlNode(json, "data");
                XmlElement xRoot = node.DocumentElement;

                foreach (XmlNode xnode in xRoot)
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        foreach (string article in articles)
                        {
                            if (childnode.Name == "article" && childnode.InnerText == $"{article}")
                            {
                                var item = new WarehouseItem(childnode.ParentNode["title"].InnerText,
                                                         childnode.ParentNode["residue"].InnerText,
                                                         childnode.ParentNode["article"].InnerText
                                                         );

                                ListOfItems.Add(childnode.ParentNode["article"].InnerText, item);

                                Console.WriteLine($"Позиция : {childnode.ParentNode["title"].InnerText}");
                                Console.WriteLine($"Артикул : {childnode.ParentNode["article"].InnerText} ");
                                Console.WriteLine($"Количество на складе : {childnode.ParentNode["residue"].InnerText}");
                                Console.WriteLine("-------------------------------------------------------------------");
                                //Console.WriteLine($"Навание : {childnode.ParentNode.OuterXml}");

                             
                            }
                            
                        }


                    }

                }
            }
            return ListOfItems;
        }

    }
}
