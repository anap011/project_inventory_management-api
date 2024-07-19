using Microsoft.EntityFrameworkCore;

namespace backend_inventory_management.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            :base(options)
        { }

        /* override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = db_inventory_management.mssql.somee.com; Initial Catalog = db_inventory_management; user id= anapereira_SQLLogin_1;pwd= nknmmqxfk1;TrustServerCertificate=True;");
        }*/

        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Batches> Batches { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
    }
}