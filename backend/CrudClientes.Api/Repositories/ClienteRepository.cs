using CrudClientes.Api.Data;
using CrudClientes.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudClientes.Api.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Cliente>> GetAllAsync()
        => _context.Clientes.OrderBy(c => c.Nome).ToListAsync();

    public Task<Cliente?> GetByIdAsync(int id)
        => _context.Clientes.FindAsync(id).AsTask();

    public async Task AddAsync(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Cliente cliente)
    {
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
    }

    public Task<bool> ExistsAsync(int id)
        => _context.Clientes.AnyAsync(c => c.Id == id);
}
