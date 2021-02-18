using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
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


            Dictionary<string, Datum> ItemsFromWarehouse = ConnectionWithRemonline.GetItemByArticle(await ConnectionWithRemonline.GetCollectionOfItems(), allArticles);

            Repository.Update(ItemsFromWarehouse);
            Repository.FetchData();
            Console.Read();


        }
        
    }
}