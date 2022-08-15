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

            

            // Fluent API "Categoría"
            modelBuilder.Entity<Categoria>().HasKey(c => c.Id);
            modelBuilder.Entity<Categoria>().Property(c => c.Name).IsRequired();
            modelBuilder.Entity<Categoria>().Property(c => c.FechaCreacion).HasColumnType("date");

            // Fluent API "Artículo"
            modelBuilder.Entity<Articulo>().ToTable("Article");
            modelBuilder.Entity<Articulo>().HasKey(c => c.Articulo_Id);
            modelBuilder.Entity<Articulo>().Property(c => c.TituloArticulo).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Articulo>().Property(c => c.Descripcion).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Articulo>().Ignore(c => c.IsFake);

            // Fluent API "Usuario"
            modelBuilder.Entity<Usuario>().HasKey(c => c.Id);

            // Fluent API "DetalleUsuario"
            modelBuilder.Entity<DetalleUsuario>().HasKey(d => d.DetalleUsuarioId);
            modelBuilder.Entity<DetalleUsuario>().Property(d => d.Cedula).IsRequired();

            // Fluent API "Etiqueta"
            modelBuilder.Entity<Etiqueta>().HasKey(e => e.Etiqueta_Id);
            modelBuilder.Entity<Etiqueta>().Property(e => e.Fecha).HasColumnType("date");

            // Fluent API relación 1:1 Usuario DetalleUsuario
            modelBuilder.Entity<Usuario>()
                 .HasOne(c => c.DetalleUsuario)
                 .WithOne(c => c.Usuario).HasForeignKey<Usuario>("DetalleUsuarioId");

            // Fluent API relacion 1:N Categoria Articulo
            modelBuilder.Entity<Articulo>()
                 .HasOne(c => c.Categoria)
                 .WithMany(c => c.Articulos).HasForeignKey("Categoria_Id");


            // Fluent API relación N:M Articulo Etiqueta
            modelBuilder.Entity<ArticuloEtiqueta>().HasKey(ae => new { ae.EtiquetaId, ae.Articulo_Id });
            modelBuilder.Entity<ArticuloEtiqueta>()
                .HasOne(ae => ae.Articulo)
                .WithMany(a => a.ArticuloEtiqueta).HasForeignKey(ae => ae.Articulo_Id);
            modelBuilder.Entity<ArticuloEtiqueta>()
                .HasOne(ae => ae.Etiqueta)
                .WithMany(e => e.ArticuloEtiqueta).HasForeignKey(ae => ae.EtiquetaId);


            // Data seed
            var categoria5 = new Categoria() { Id = 50, Name = "Categoria 5", FechaCreacion = new DateTime(2022, 11, 28), Activo = true };
            var categoria6 = new Categoria() { Id = 51, Name = "Categoria 6", FechaCreacion = new DateTime(2022, 11, 28), Activo = true };
            modelBuilder.Entity<Categoria>().HasData(new Categoria[] { categoria5, categoria6 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
