using Domain.Entities;
using MediatR;

namespace Core.Features.Vehiculos.Queries;

public class GetAllVehiculosQuery : IRequest<IEnumerable<Vehiculo>>
{
}