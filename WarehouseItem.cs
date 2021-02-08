using System;
namespace remsklad_C_
{
    public class WarehouseItem
    {
        public string nameOfItem;
        public int countInWarehouse;
        public string articleOfItem;

        public WarehouseItem(string ItemName, string CountInWarehouse, string article)
        {
            this.nameOfItem = ItemName;
            this.countInWarehouse = Int32.Parse(CountInWarehouse);
            this.articleOfItem = article;
        }


        public int GetCount()
        {
            return this.countInWarehouse;
        }

        public void SetCount(string count)
        {
            this.countInWarehouse = Int32.Parse(count);
        }

        public string GetName()
        {
            return this.nameOfItem;
        }

        public void SetName(string name)
        {
            this.nameOfItem = name;
        }

        public string GetArticle()
        {
            return this.articleOfItem;
        }

        public void SetArticle(string article)
        {
            this.articleOfItem = article;
        }

        public void ShowAll()
        {
            Console.WriteLine($"Name : {this.nameOfItem}, Count : {this.countInWarehouse} , Article : {this.articleOfItem}");
        }


    }
}
