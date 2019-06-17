using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Website
{
    public class CustomerController : ApiController
    {
        public IEnumerable<Customer> Get()
        {
            return Global.DataSource.GetAllCustomers();            
        }

        // GET api/customers/5
        public string Get(string id)
        {
            return id;
        }

        // POST api/customers
        public void Post([FromBody]string value)
        {
        }

        // PUT api/customers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/customers/5
        public void Delete(int id)
        {
        }
    }
}