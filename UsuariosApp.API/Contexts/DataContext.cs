using Microsoft.EntityFrameworkCore;
using UsuariosApp.API.Entities;

namespace UsuariosApp.API.Contexts
{
    /// <summary>
    /// Classe de contexto do EntityFramework
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Construtor para injeção de dependência do contexto
        /// </summary>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        /// <summary>
        /// Método para adicionarmos os mapeamentos das entidades
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Mapeamento de usuário

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Nome)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Senha)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.RefreshToken)
                .HasMaxLength(100);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.RefreshTokenExpiration);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            #endregion
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
