﻿// <auto-generated />
using CursoEntityCore.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CursoEntityCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CursoEntityCore.Models.Articulo", b =>
                {
                    b.Property<int>("Articulo_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Articulo_Id"), 1L, 1);

                    b.Property<double>("Calificacion")
                        .HasColumnType("float");

                    b.Property<int>("Categoria_Id")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Fecha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TituloArticulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Titulo");

                    b.HasKey("Articulo_Id");

                    b.HasIndex("Categoria_Id");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("CursoEntityCore.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("CursoEntityCore.Models.DetalleUsuario", b =>
                {
                    b.Property<int>("DetalleUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleUsuarioId"), 1L, 1);

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Deporte")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mascota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DetalleUsuarioId");

                    b.ToTable("DetalleUsuario");
                });

            modelBuilder.Entity("CursoEntityCore.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DetalleUsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DetalleUsuarioId")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("CursoEntityCore.Models.Articulo", b =>
                {
                    b.HasOne("CursoEntityCore.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("Categoria_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("CursoEntityCore.Models.Usuario", b =>
                {
                    b.HasOne("CursoEntityCore.Models.DetalleUsuario", "DetalleUsuario")
                        .WithOne("Usuario")
                        .HasForeignKey("CursoEntityCore.Models.Usuario", "DetalleUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DetalleUsuario");
                });

            modelBuilder.Entity("CursoEntityCore.Models.DetalleUsuario", b =>
                {
                    b.Navigation("Usuario")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
