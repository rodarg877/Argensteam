﻿// <auto-generated />
using Argensteam1.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Argensteam1.Migrations
{
    [DbContext(typeof(ArgensteamDatabaseContext))]
    [Migration("20220622224653_CreacionTablaSoporte")]
    partial class CreacionTablaSoporte
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Argensteam1.Models.Juego", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagenes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<string>("urllVideo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Juegos");
                });

            modelBuilder.Entity("Argensteam1.Models.Noticia", b =>
                {
                    b.Property<int>("NoticiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NoticiaId");

                    b.ToTable("Noticias");
                });

            modelBuilder.Entity("Argensteam1.Models.Usuario", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoPerfil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("UserId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Argensteam1.Models.UsuarioJuego", b =>
                {
                    b.Property<int>("JuegoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("tipoLista")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("JuegoId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioJuegos");
                });

            modelBuilder.Entity("Argensteam1.Models.UsuarioJuego", b =>
                {
                    b.HasOne("Argensteam1.Models.Juego", "Juego")
                        .WithMany("Usuarios")
                        .HasForeignKey("JuegoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Argensteam1.Models.Usuario", "Usuario")
                        .WithMany("UsuarioJuegos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Juego");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Argensteam1.Models.Juego", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Argensteam1.Models.Usuario", b =>
                {
                    b.Navigation("UsuarioJuegos");
                });
#pragma warning restore 612, 618
        }
    }
}
