using MiactlanAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MiactlanAPI.Context
{
    public class MiactlanDbContext : IdentityDbContext<Usuario>
    {
        public MiactlanDbContext(DbContextOptions<MiactlanDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Entidad> Entidades { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<EntradaCategoria> EntradaCategorias { get; set; }
        public DbSet<CategoriaArchivo> CategoriaArchivos { get; set; }
        public DbSet<Archivo> Archivos { get; set; }
        public DbSet<ArchivoCategoriaArchivo> ArchivoCategoriaArchivos { get; set; }
    }
}
