using Core.Interfaces;
using MediatR;

namespace Core.Features.Vehiculos.Commands;

public class EliminarVehiculoCommandHandler : IRequestHandler<EliminarVehiculoCommand, bool>
{
    private readonly IVehiculoRepository _vehiculoRepository;

    public EliminarVehiculoCommandHandler(IVehiculoRepository vehiculoRepository)
    {
        _vehiculoRepository = vehiculoRepository;
    }

    public async Task<bool> Handle(EliminarVehiculoCommand request, CancellationToken cancellationToken)
    {
        var vehiculo = await _vehiculoRepository.GetByIdAsync(request.Id);
        if (vehiculo == null) return false;

        await _vehiculoRepository.DeleteAsync(request.Id);
        return true;
    }
}