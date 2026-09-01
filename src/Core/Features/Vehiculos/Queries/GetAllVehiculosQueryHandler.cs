using Core.Interfaces;
using Domain.Entities;
using MediatR;

namespace Core.Features.Vehiculos.Queries;

public class GetAllVehiculosQueryHandler : IRequestHandler<GetAllVehiculosQuery, IEnumerable<Vehiculo>>
{
    private readonly IVehiculoRepository _vehiculoRepository;

    public GetAllVehiculosQueryHandler(IVehiculoRepository vehiculoRepository)
    {
        _vehiculoRepository = vehiculoRepository;
    }

    public async Task<IEnumerable<Vehiculo>> Handle(GetAllVehiculosQuery request, CancellationToken cancellationToken)
    {
        return await _vehiculoRepository.GetAllAsync();
    }
}