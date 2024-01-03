using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Context
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
            
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlDbContext).Assembly);

            foreach (var item in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                item.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
