using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Website
{
    public class PositionsController : ApiController
    {
        public IEnumerable<Position> Get()
        {
            var rnd = new Random();
            return new Position[] {
                new Position() { ID = rnd.Next(100), Floor = 1, Department = "11", Place = 1 },
                new Position() { ID = rnd.Next(100), Floor = 1, Department = "11", Place = 1 },
                new Position() { ID = rnd.Next(100), Floor = 1, Department = "11", Place = 1 },
                new Position() { ID = rnd.Next(100), Floor = 1, Department = "11", Place = 1 },
                new Position() { ID = rnd.Next(100), Floor = 1, Department = "11", Place = 1 },
                };
        }

        // GET api/cars/5
        public string Get(string id)
        {
            return id;
        }

        // POST api/cars
        public void Post([FromBody]string value)
        {
        }

        // PUT api/cars/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/cars/5
        public void Delete(int id)
        {
        }
    }
}