using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace remsklad_C_
{
    class Program
    {
        static async Task Main(string[] args)
        {
        
            
            // string responceMessage = ConnectionWithRemonline.getPageFromRemonline(responceToken.token,1);
            // System.Console.WriteLine(responceMessage);
            List<Item> ListItem = new List<Item>();
            for (var i = 1; i < 10; i++)
            {
                string responceMessage = ConnectionWithRemonline.getPageFromRemonline(await ConnectionWithRemonline.getToken(), i);
                
                Item thing = JsonConvert.DeserializeObject<Item>(responceMessage);
                ListItem.Add(thing);
                
            }

            Dictionary<string,Datum> ItemsfromWarehouse = new Dictionary<string,Datum>();
            try
            {
                foreach(var s in ListItem)
            {
                // Console.WriteLine(s.page);
                foreach(var p in s.data)
                {  
                    try
                    {
                        ItemsfromWarehouse.Add(p.article,p);
                    // Console.WriteLine(p.title);
                    }
                    catch (System.Exception)
                    {   if(p.article == null){
                            System.Console.WriteLine("У этой позиции отсутствует артикль :");
                            System.Console.WriteLine(p.title);

                        }else{
                            System.Console.WriteLine("У этой позиции отсутствует артикль или найдено совпадение:");
                            System.Console.WriteLine(p.title);
                            throw;
                        }
                    }
                    
                }
            }
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Совпали артикли у двух позиций !!!");
                throw;
            }
            

            Console.WriteLine();
            Console.ReadLine();



            // string[] articlesOfAccum = { "1010", "1020", "1030", "1050", "1060", "1070", "1080", "1090", "1120", "1128", "1129", "1125" };

            // foreach(var Key in articlesOfAccum){
            //     ItemsfromWarehouse
            // }

            foreach( KeyValuePair<string ,Datum> kvp in ItemsfromWarehouse ){
                System.Console.WriteLine(kvp.Key + " - " + kvp.Value.title );
            }
            //string[] articlesOfDisplay = { "0601", "0601s", "0602", "0602s", "0601p", "0601sp", "0602p", "0602sp" };

            //var allArticles = new List<string>();

            //foreach (var accum in articlesOfAccum)
            //{
            //    allArticles.Add(accum);
            //}
            //foreach (var disp in articlesOfDisplay)
            //{
            //    allArticles.Add(disp);
            //}



            ////XMLSearch.SearchByXmlElement(responceToken.token, articles,5);
            //var Accums = GetXmlElement.GetXmlElementByArticle(responceToken.token, allArticles);

            //Accums["1010"].ShowAll();

        }
    }
}