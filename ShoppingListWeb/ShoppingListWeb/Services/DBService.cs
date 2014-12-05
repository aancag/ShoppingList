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
        private MongoCollection<shoppingListDBModel> collection;

        public DBService() {
            var connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            this.db = server.GetDatabase("shoppingList");
            this.collection = db.GetCollection<shoppingListDBModel>("info");
        }

        public void Create(shoppingListDBModel entry) {
            collection.Insert(entry);
            collection.Save(entry);
        }

        public String Retrive() {
            MongoCursor<shoppingListDBModel> all = collection.FindAllAs<shoppingListDBModel>();
            return all.ToArray().ToJson();
        }

        public void Update(String id, shoppingListDBModel entry) {
            var query = new QueryDocument("_id", id);
            var updateName = new UpdateDocument { {"$set", new BsonDocument("Name", entry.Name)} };
            collection.Update(query, updateName);
            var updateQuantity = new UpdateDocument { { "$set", new BsonDocument("Quantity", entry.Quantity) } };
            collection.Update(query, updateQuantity);
        }

        public void Delete(String entry) {
            var query = new QueryDocument("_id", entry);
            collection.Remove(query);
        }
        
    }
   
}