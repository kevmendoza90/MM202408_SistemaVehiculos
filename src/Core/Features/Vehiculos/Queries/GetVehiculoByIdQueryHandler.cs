using Core.Interfaces;
using Domain.Entities;
using MediatR;

namespace Core.Features.Vehiculos.Queries;

public class GetVehiculoByIdQueryHandler : IRequestHandler<GetVehiculoByIdQuery, Vehiculo?>
{
    private readonly IVehiculoRepository _vehiculoRepository;

    public GetVehiculoByIdQueryHandler(IVehiculoRepository vehiculoRepository)
    {
        _vehiculoRepository = vehiculoRepository;
    }

    public async Task<Vehiculo?> Handle(GetVehiculoByIdQuery request, CancellationToken cancellationToken)
    {
        return await _vehiculoRepository.GetByIdAsync(request.Id);
    }
}