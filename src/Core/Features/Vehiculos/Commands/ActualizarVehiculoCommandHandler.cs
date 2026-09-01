using Core.Interfaces;
using MediatR;

namespace Core.Features.Vehiculos.Commands;

public class ActualizarVehiculoCommandHandler : IRequestHandler<ActualizarVehiculoCommand, bool>
{
    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly IMarcaRepository _marcaRepository;

    public ActualizarVehiculoCommandHandler(IVehiculoRepository vehiculoRepository, IMarcaRepository marcaRepository)
    {
        _vehiculoRepository = vehiculoRepository;
        _marcaRepository = marcaRepository;
    }

    public async Task<bool> Handle(ActualizarVehiculoCommand request, CancellationToken cancellationToken)
    {
        var vehiculo = await _vehiculoRepository.GetByIdAsync(request.Id);
        if (vehiculo == null) return false;

        var marca = await _marcaRepository.GetByIdAsync(request.MarcaId);
        if (marca == null)
            throw new InvalidOperationException($"No existe una Marca con Id {request.MarcaId}.");

        vehiculo.Modelo = request.Modelo;
        vehiculo.Anio = request.Anio;
        vehiculo.CantidadPuertas = request.CantidadPuertas;
        vehiculo.MarcaId = request.MarcaId;

        await _vehiculoRepository.UpdateAsync(vehiculo);
        return true;
    }
}