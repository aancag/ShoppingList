using MongoDB.Bson;
using MongoDB.Driver;
using ShoppingListWeb.App_Start;
using ShoppingListWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace ShoppingListWeb.Services
{
    //Connection to database
    public class DBService
    {
        private MongoDatabase db;
        private MongoCollection<myShoppingList> collection;

        public DBService() {
            var connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            this.db = server.GetDatabase("shoppingList");
            this.collection = db.GetCollection<myShoppingList>("info");
        }

        public void Create(shoppingListDBModel entry) {
            collection.Insert(entry);
            collection.Save(entry);
        }

        public String Retrive() {
            MongoCursor<shoppingListDBModel> all = collection.FindAllAs<shoppingListDBModel>();
            //var allDB = db.GetCollection<BsonDocument>("info");
            return all.ToArray().ToJson();
        }
    }
   
}