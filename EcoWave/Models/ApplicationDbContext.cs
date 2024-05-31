using Microsoft.EntityFrameworkCore;
using EcoWave.Models;

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
            modelBuilder.Entity<Amigo>()
                .HasKey(a => new { a.usuario_id, a.amigo_id });

            modelBuilder.Entity<Amigo>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Amigos)
                .HasForeignKey(a => a.usuario_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Amigo>()
                .HasOne(a => a.AmigoUsuario)
                .WithMany(u => u.AmigosDoUsuario)
                .HasForeignKey(a => a.amigo_id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
