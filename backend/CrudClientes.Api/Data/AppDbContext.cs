using CrudClientes.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudClientes.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.Telefone)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.DataCadastro)
                .HasDefaultValueSql("GETUTCDATE()");
        });
    }
}
