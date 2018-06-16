using Microsoft.EntityFrameworkCore;

namespace iServiceApi.Models
{
    public class IServiceContext : DbContext
    {
        public IServiceContext()
        {

        }

        public IServiceContext(DbContextOptions<IServiceContext> options)
            : base(options)
        {

        }                      
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("DefaultConnection");
            //optionsBuilder.UseSqlServer("DefaultConnection");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
        }
    }
}   

