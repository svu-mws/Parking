using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataBaseInitializer : DropCreateDatabaseIfModelChanges<DB_Context>
    {
        protected override void Seed(DB_Context context)
        {
            context.Customers.Add(new Customer() { Name = "Salem" });
            context.SaveChanges();
        }
    }

}
