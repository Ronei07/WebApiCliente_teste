using CrudClientes.Api.DTOs;
using CrudClientes.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientes.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _service;

    public ClientesController(IClienteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
    {
        var clientes = await _service.GetAllAsync();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClienteDto>> Get(int id)
    {
        var cliente = await _service.GetByIdAsync(id);
        return cliente == null ? NotFound() : Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult<ClienteDto>> Post([FromBody] ClienteCreateUpdateDto request)
    {
        var cliente = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ClienteCreateUpdateDto request)
    {
        if (!await _service.UpdateAsync(id, request))
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await _service.DeleteAsync(id))
        {
            return NotFound();
        }

        return NoContent();
    }
}
