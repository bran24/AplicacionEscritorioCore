using Microsoft.EntityFrameworkCore;
using ORM.Entities;

namespace ORM

{
    public class OrmContext: DbContext
    {

        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Producto> productos { get; set; }
        public static string connection { get; set; } = @"Server=DESKTOP-2CBE3PB\SQLEXPRESS;Database=Bodega;User Id=sa;Password=sqlserver;";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connection+ "TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Usuario>().ToTable("usuario");
            //modelBuilder.Entity<Producto>().ToTable("producto");
        }


    




    }
}