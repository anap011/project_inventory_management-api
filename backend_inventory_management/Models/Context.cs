using Microsoft.EntityFrameworkCore;

namespace backend_inventory_management.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            :base(options)
        { }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Lotes> Lotes { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
    }
}