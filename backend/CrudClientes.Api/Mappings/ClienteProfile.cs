using AutoMapper;
using CrudClientes.Api.DTOs;
using CrudClientes.Api.Models;

namespace CrudClientes.Api.Mappings;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<Cliente, ClienteDto>();
        CreateMap<ClienteCreateUpdateDto, Cliente>()
            .ForMember(dest => dest.DataCadastro, opt => opt.Ignore());
    }
}
