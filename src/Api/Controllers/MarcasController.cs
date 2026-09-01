using Core.Features.Marcas.Commands;
using Core.Features.Marcas.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MarcasController : ControllerBase
{
    private readonly IMediator _mediator;

    public MarcasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var marcas = await _mediator.Send(new GetAllMarcasQuery());
        return Ok(marcas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var marca = await _mediator.Send(new GetMarcaByIdQuery(id));
        if (marca == null) return NotFound();
        return Ok(marca);
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearMarcaCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarMarcaCommand command)
    {
        if (id != command.Id) return BadRequest("El Id no coincide.");
        var actualizado = await _mediator.Send(command);
        if (!actualizado) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var eliminado = await _mediator.Send(new EliminarMarcaCommand(id));
        if (!eliminado) return NotFound();
        return NoContent();
    }
}