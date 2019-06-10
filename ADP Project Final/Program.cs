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
            //Database.SetInitializer(new DataBaseInitializer());

            ParkingManagerDatabaseEntities db = new ParkingManagerDatabaseEntities();
            
            db.Customers.Add(new Customer() {Name = "Zaher"});
            db.SaveChanges();
            
            Console.WriteLine(db.Customers.First().Name);

            Console.ReadLine();
        }
    }
}