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
            string[] articlesOfAccum = { "1010", "1020", "1030", "1050", "1060", "1070", "1080", "1090", "1120", "1128", "1129", "1125" };
            string[] articlesOfDisplay = { "0601", "0601s", "0602", "0602s", "0601p", "0601sp", "0602p", "0602sp" };
            
            var allArticles = new List<string>();

            foreach (var accum in articlesOfAccum)
            {
               allArticles.Add(accum);
            }
            foreach (var disp in articlesOfDisplay)
            {
               allArticles.Add(disp);
            }
           

            var ItemsFromWarehouse = ConnectionWithRemonline.GetItemByArticle(await ConnectionWithRemonline.GetCollectionOfItems(),allArticles);
            
            Console.WriteLine();
            Console.ReadLine();

             foreach( KeyValuePair<string ,Datum> kvp in ItemsFromWarehouse ){
                System.Console.WriteLine(kvp.Key + " - Кол-во: " + kvp.Value.residue + " - " + kvp.Value.title  );
            }
            

            



            

        }
    }
}