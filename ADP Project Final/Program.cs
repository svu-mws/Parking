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
            //db.Customers.Add(new Customer());
            db.Customers.Add(new Customer() {Name = "Ahmad", ID = 1213213});
            db.SaveChanges();
            Console.WriteLine();
        }
    }
}