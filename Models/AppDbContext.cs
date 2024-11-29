using Microsoft.EntityFrameworkCore;

namespace BackEndMobile.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Materia>()
                .HasMany(m => m.Notas) 
                .WithOne(n => n.Materia) 
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Nota>(); 
        }



        public DbSet<Materia> Materias { get; set; }
        public DbSet<Nota> Notas { get; set; }
    }

    
}
