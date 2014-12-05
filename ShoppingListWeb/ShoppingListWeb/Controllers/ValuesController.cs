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
        public HttpResponseMessage Post(shoppingListDBModel sL)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   sL._id = Guid.NewGuid().ToString(); 
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
        public HttpResponseMessage Put(String id, shoppingListDBModel sL)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    dbService.Update(id, sL);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, sL);
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

        // DELETE api/values/5
        public String Delete(String id)
        {
            dbService.Delete(id);
            return id;

        }
    }
}