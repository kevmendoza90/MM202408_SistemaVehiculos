using Core.Interfaces;
using Domain.Entities;
using MediatR;

namespace Core.Features.Vehiculos.Commands;

public class CrearVehiculoCommandHandler : IRequestHandler<CrearVehiculoCommand, int>
{
    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly IMarcaRepository _marcaRepository;

    public CrearVehiculoCommandHandler(IVehiculoRepository vehiculoRepository, IMarcaRepository marcaRepository)
    {
        _vehiculoRepository = vehiculoRepository;
        _marcaRepository = marcaRepository;
    }

    public async Task<int> Handle(CrearVehiculoCommand request, CancellationToken cancellationToken)
    {
        var marca = await _marcaRepository.GetByIdAsync(request.MarcaId);
        if (marca == null)
            throw new InvalidOperationException($"No existe una Marca con Id {request.MarcaId}.");

        var vehiculo = new Vehiculo
        {
            Modelo = request.Modelo,
            Anio = request.Anio,
            CantidadPuertas = request.CantidadPuertas,
            MarcaId = request.MarcaId
        };

        await _vehiculoRepository.AddAsync(vehiculo);
        return vehiculo.Id;
    }
}