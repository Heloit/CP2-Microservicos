using GestaoEstoqueApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoqueApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<MovimentacaoEstoque> MovimentacoesEstoque { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>()
                .HasIndex(p => p.Sku)
                .IsUnique();
        }
    }
}