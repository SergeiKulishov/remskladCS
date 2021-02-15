using System;
using System.Xml;
using Newtonsoft.Json;

namespace remsklad_C_
{
    public static class XMLSearch
    {
        /* На момент написания данного кода количество страниц склада в Remonline составляет : 26 */


        static public void SearchByXmlElement(string token,string article,int pageCount = 26)
        {
            for (int i = 1; i < pageCount; i++)
            {
                string responceMessage = ConnectionWithRemonline.GetPageFromRemonline(token, i);
                string json = responceMessage.ToString();
                //Console.WriteLine(json);
                XmlDocument node = JsonConvert.DeserializeXmlNode(json, "data");
                XmlElement xRoot = node.DocumentElement;

                foreach (XmlNode xnode in xRoot)
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "article" && childnode.InnerText == $"{article}")
                        {
                            Console.WriteLine($"Позиция : {childnode.ParentNode["title"].InnerText}");
                            Console.WriteLine($"Артикул : {childnode.ParentNode["article"].InnerText} ");
                            Console.WriteLine($"Количество на складе : {childnode.ParentNode["residue"].InnerText}");
                            Console.WriteLine($"Навание : {childnode.ParentNode.OuterXml}");
                        }



                    }

                }
            }
        }


        static public void SearchByXmlElement(string token, string[] articles, int pageCount = 26)
        {
            for (int i = 1; i < pageCount; i++)
            {
                string responceMessage = ConnectionWithRemonline.GetPageFromRemonline(token, i);
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
                                Console.WriteLine($"Позиция : {childnode.ParentNode["title"].InnerText}");
                                Console.WriteLine($"Артикул : {childnode.ParentNode["article"].InnerText} ");
                                Console.WriteLine($"Количество на складе : {childnode.ParentNode["residue"].InnerText}");
                                Console.WriteLine($"Навание : {childnode.ParentNode.OuterXml}");
                            }
                        }


                    }

                }
            }
        }

    }
}
