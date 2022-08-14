using CursoEntityCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoEntityCore.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        // Incluir modelos
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<DetalleUsuario> DetalleUsuario { get; set; }
        public DbSet<Etiqueta> Etiqueta { get; set; }
        public DbSet<ArticuloEtiqueta> ArticuloEtiqueta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticuloEtiqueta>().HasKey(ae => new { ae.EtiquetaId, ae.Articulo_Id });

            // Data seed
            var categoria5 = new Categoria() { Id = 50, Name = "Categoria 5", FechaCreacion = new DateTime(2022, 11, 28), Activo = true };
            var categoria6 = new Categoria() { Id = 51, Name = "Categoria 6", FechaCreacion = new DateTime(2022, 11, 28), Activo = true };

            // N:M relations
            modelBuilder.Entity<Categoria>().HasData(new Categoria[] { categoria5, categoria6 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
