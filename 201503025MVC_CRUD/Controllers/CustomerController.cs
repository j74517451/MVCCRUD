using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using _201503025MVC_CRUD.Models;
using System.Data.Entity.Infrastructure;


namespace _201503025MVC_CRUD.Controllers
{
    public class CustomerController : ApiController
    {
        InventoryEntities db = new InventoryEntities();

        //get all customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return db.Customer.AsEnumerable();
        }

        //get customer by id
        public Customer Get(int id)
        {
            Customer customer = db.Customer.Find(id);
            if( customer == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            }
            return customer;
        }

        //insert customer
        public HttpResponseMessage Post(Customer customer)
        {
            if(ModelState.IsValid)
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, customer);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { Id = customer.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        //update customer
        public HttpResponseMessage Put(int id, Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest , ModelState);

            }
            if( id != customer.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            db.Entry(customer).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        //delete customer by id
        public HttpResponseMessage Delete(int id)
        {
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Customer.Remove(customer);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
