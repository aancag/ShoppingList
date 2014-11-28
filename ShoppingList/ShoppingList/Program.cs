using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            var db = server.GetDatabase("shoppingList");
            var collection = db.GetCollection<myShoppingList>("info");

            myShoppingList list = new myShoppingList{
                Name = "pizza", 
                Quantity = "3", 
                Edit = "true",
                Bought = "false"
           };
            collection.Insert(list);
            collection.Save(list);
        }
    }
    public class myShoppingList {
        public ObjectId Id { get; set; }
        public String Name { get; set; }
        public String Quantity { get; set; }
        public String Edit { get; set; }
        public String Bought { get; set; }
    }
}
