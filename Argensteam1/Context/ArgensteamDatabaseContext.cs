using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Argensteam1.Models;
namespace Argensteam1.Context
{
    public class ArgensteamDatabaseContext : DbContext
    {
        public
       ArgensteamDatabaseContext(DbContextOptions<ArgensteamDatabaseContext> options)
       : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioJuego>()
                .HasKey(jueuser => new { jueuser.JuegoId, jueuser.UsuarioId });
            modelBuilder.Entity<UsuarioJuego>()
                .HasOne(jueuser => jueuser.Juego)
                .WithMany(user => user.Usuarios)
                .HasForeignKey(jueuser => jueuser.JuegoId);
            modelBuilder.Entity<UsuarioJuego>()
                .HasOne(jueuser => jueuser.Usuario)
                .WithMany(jue => jue.UsuarioJuegos)
                .HasForeignKey(jueuser => jueuser.UsuarioId);
        }
        public DbSet<Juego> Juegos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<UsuarioJuego> UsuarioJuegos { get; set; }
        public DbSet<Soporte> Soporte { get; set; }
    }
}
