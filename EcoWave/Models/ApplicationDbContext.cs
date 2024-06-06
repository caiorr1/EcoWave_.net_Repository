using EcoWave.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoWave.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ItemReciclado> ItensReciclados { get; set; }
        public DbSet<Recompensa> Recompensas { get; set; }
        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<ReconhecimentoItem> ReconhecimentoItens { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }
        public DbSet<Configuracao> Configuracoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurando a chave composta para Amigo
            modelBuilder.Entity<Amigo>()
                .HasKey(a => new { a.UsuarioId, a.AmigoId });

            modelBuilder.Entity<Amigo>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Amigos)
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Amigo>()
                .HasOne(a => a.AmigoUsuario)
                .WithMany(u => u.AmigosDoUsuario)
                .HasForeignKey(a => a.AmigoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Recompensa>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Recompensas)
                .HasForeignKey(r => r.UsuarioId);

            modelBuilder.Entity<ItemReciclado>()
                .HasOne(i => i.Usuario)
                .WithMany(u => u.ItensReciclados)
                .HasForeignKey(i => i.UsuarioId);

            modelBuilder.Entity<ReconhecimentoItem>()
                .HasOne(ri => ri.Usuario)
                .WithMany(u => u.ReconhecimentoItens)
                .HasForeignKey(ri => ri.UsuarioId);

            modelBuilder.Entity<Configuracao>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Configuracoes)
                .HasForeignKey(c => c.UsuarioId);
        }
    }
}
