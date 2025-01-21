using Microsoft.EntityFrameworkCore;
using PruebaAPI.Models;

namespace PruebaAPI.Data
{
    public class PruebaAPIContext : DbContext
    {
        public PruebaAPIContext(DbContextOptions<PruebaAPIContext> options)
            : base(options)
        {
        }

        public DbSet<PruebaAPI.Models.Person> Person { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para la tabla Persons
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person"); // Nombre de la tabla en la base de datos

                entity.HasKey(e => e.Id); // Clave primaria

                entity.Property(e => e.FirstName)
                    .IsRequired() // NOT NULL
                    .HasMaxLength(100); // nvarchar(100)

                entity.Property(e => e.LastName)
                    .IsRequired() // NOT NULL
                    .HasMaxLength(100); // nvarchar(100)

                entity.Property(e => e.Age)
                    .IsRequired(); // NOT NULL
            });
        }

    }
}
