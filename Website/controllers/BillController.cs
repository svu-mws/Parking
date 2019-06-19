using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Web.Http;

namespace Website
{
    public class BillController : ApiController
    {

        [HttpGet]  
        public double Get(int userID,int carID)
        {

            return Global.DataSource.GetInvoice(userID, carID);
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