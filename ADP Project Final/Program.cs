using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;

namespace ADP_Project_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            ADP_ParkingEntities x = new ADP_ParkingEntities();
            x.Customers.Add(new Customer() { Name = "Sror" });
            x.SaveChanges();

            Console.WriteLine(x.Customers.ToList().Count);
         //   Console.WriteLine(x.Customers.ToList().Count);
            
            //var x = new API();
            //var db = x.singlton();
            //Console.WriteLine(db.Customers.ToList().Count);
            //Database.SetInitializer(new DataBaseInitializer());
            // var x = new API();
            // ParkingManagerDatabaseEntities db = new ParkingManagerDatabaseEntities();
            //db.Customers.SqlQuery("SET IDENTITY_INSERT Customers ON");
            // db.Customers.Add(new Customer() {Name = "Zaher"});
            // db.SaveChanges();

            //Console.WriteLine(db.Customers.First().Name);

            Console.ReadLine();
        }
    }
}