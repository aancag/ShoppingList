using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using ShoppingListWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingListWeb.App_Start
{
    public class shoppingListDBModel
    {
        public String _id { get; set; }
        public String Name { get; set; }
        public String Quantity { get; set; }
        public Boolean Bought { get; set; }

    }
}