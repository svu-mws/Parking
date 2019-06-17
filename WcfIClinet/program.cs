using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;
namespace WcfIClinet
{
    class program
    {
        public static void Main(string[] arg)
        {
            ADP_ParkingEntities db = new ADP_ParkingEntities();
            //db.Customers.Add(new Customer() { Name = "mo", ID = 100 });
            db.SaveChanges();

            Console.WriteLine(db.Customers.ToList().Count);

            Console.ReadLine();
        }
    }
}
