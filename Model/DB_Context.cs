namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB_Context : DbContext
    {
        public DB_Context()
            : base("name=DB_Context")
        {
            if (!Database.Exists("DB_Context"))
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DB_Context>());
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          }
    }
}
