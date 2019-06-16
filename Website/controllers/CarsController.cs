using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Website
{
    public class CarsController : ApiController
    {
        public IEnumerable<Car> Get()
        {
            return Global.DataSource.GetAllCars();            
//            return new Car[] {new Car()
//                {City = "test", Color = "red", Company = "tete", ArrivalTime = DateTime.MinValue, ID = GetHashCode()} };
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
            Global.DataSource.RemoveCar(id);
        }
    }
}