using AutoMapper;
using CrudClientes.Api.DTOs;
using CrudClientes.Api.Models;
using CrudClientes.Api.Repositories;

namespace CrudClientes.Api.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;
    private readonly IMapper _mapper;

    public ClienteService(IClienteRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ClienteDto>> GetAllAsync()
    {
        var clientes = await _repository.GetAllAsync();
        return _mapper.Map<List<ClienteDto>>(clientes);
    }

    public async Task<ClienteDto?> GetByIdAsync(int id)
    {
        var cliente = await _repository.GetByIdAsync(id);
        return cliente == null ? null : _mapper.Map<ClienteDto>(cliente);
    }

    public async Task<ClienteDto> CreateAsync(ClienteCreateUpdateDto request)
    {
        var cliente = _mapper.Map<Cliente>(request);
        cliente.DataCadastro = DateTime.UtcNow;
        await _repository.AddAsync(cliente);
        return _mapper.Map<ClienteDto>(cliente);
    }

    public async Task<bool> UpdateAsync(int id, ClienteCreateUpdateDto request)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
        {
            return false;
        }

        _mapper.Map(request, existing);
        await _repository.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
        {
            return false;
        }

        await _repository.DeleteAsync(existing);
        return true;
    }
}
