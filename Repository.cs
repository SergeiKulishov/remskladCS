using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remsklad_C_
{
    public class Repository
    {
        public static void Add(Dictionary<string, Datum> ItemsFromWarehouse)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (KeyValuePair<string, Datum> kvp in ItemsFromWarehouse)
                {
                    // добавляем их в бд
                    db.Datums.Add(kvp.Value);
                }
                db.SaveChanges();
                Console.WriteLine("Объекты успешно добавлены");
            }
        }
            
        public static void Update(Dictionary<string, Datum> ItemsFromWarehouse)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (KeyValuePair<string, Datum> kvp in ItemsFromWarehouse)
                {
                    //обновляем их в бд
                    db.Datums.Update(kvp.Value);
                }
                db.SaveChanges();
                Console.WriteLine("Объекты успешно обновлены");
            }
        }

        public static IEnumerable<Datum> FetchData()
        {
            IEnumerable<Datum> items;

            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                items = db.Datums.ToList();
                Console.WriteLine("Список объектов:");
                foreach (var i in items)
                {
                    Console.WriteLine(i.article + " - " + i.title + " Кол-во: " + i.residue);
                }
            }
            return items;
        }
    }
}
