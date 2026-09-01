using Core.Features.Vehiculos.Commands;
using Core.Features.Vehiculos.Queries;
using Core.Features.Ventas.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiculosController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehiculosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vehiculos = await _mediator.Send(new GetAllVehiculosQuery());
        return Ok(vehiculos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var vehiculo = await _mediator.Send(new GetVehiculoByIdQuery(id));
        if (vehiculo == null) return NotFound();
        return Ok(vehiculo);
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearVehiculoCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarVehiculoCommand command)
    {
        if (id != command.Id) return BadRequest("El Id no coincide.");
        var actualizado = await _mediator.Send(command);
        if (!actualizado) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var eliminado = await _mediator.Send(new EliminarVehiculoCommand(id));
        if (!eliminado) return NotFound();
        return NoContent();
    }

    // Caso de uso <<extend>>: Realizar Venta Vehiculo
    [HttpPost("{id}/venta")]
    public async Task<IActionResult> RealizarVenta(int id, [FromBody] RealizarVentaCommand command)
    {
        if (id != command.VehiculoId) return BadRequest("El Id del vehiculo no coincide.");
        var ventaId = await _mediator.Send(command);
        return Ok(new { VentaId = ventaId, Mensaje = "Venta registrada exitosamente." });
    }
}