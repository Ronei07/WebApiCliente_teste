using CrudClientes.Api.DTOs;

namespace CrudClientes.Api.Services;

public interface IClienteService
{
    Task<List<ClienteDto>> GetAllAsync();
    Task<ClienteDto?> GetByIdAsync(int id);
    Task<ClienteDto> CreateAsync(ClienteCreateUpdateDto request);
    Task<bool> UpdateAsync(int id, ClienteCreateUpdateDto request);
    Task<bool> DeleteAsync(int id);
}
