using Microsoft.EntityFrameworkCore;
using LocacaoMoto.Models;

namespace LocacaoMoto.Models
{
    public class ModelsContext : DbContext
    {
        public DbSet<Motos> Motos { get; init; }

        public DbSet<Locacao> Locacao { get; init; }

        public DbSet<Entregadores> Entregadores { get; init; }


        public ModelsContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Motos>();
            modelBuilder.Entity<Locacao>();  
            modelBuilder.Entity<Entregadores>();  
        }
      
    }
}