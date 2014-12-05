using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Net.Http;
using ShoppingListWeb.Services;
using MongoDB.Bson;
using ShoppingListWeb.App_Start;
using System.Net.Http.Headers;
//using System.Web.Mvc;

namespace ShoppingListWeb.Controllers
{
    public class ValuesController : ApiController
    {
        private DBService dbService;

        public ValuesController() {
            dbService = new DBService();
        }
        // GET api/values
        public HttpResponseMessage Get()
        {
            var a = dbService.Retrive();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, a);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Content = new StringContent(a);
            return response;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public HttpResponseMessage Post(myShoppingList sL)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, sL);
                   dbService.Create(sL);
                   return response;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Model");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    //se mapeaza cu ce primeste din angular
    public class myShoppingList
    {
        public String Name { get; set; }
        public String Quantity { get; set; }
        public Boolean Bought { get; set; }
    }
}