using Domain.Entities;
using MediatR;

namespace Core.Features.Vehiculos.Queries;

public class GetVehiculoByIdQuery : IRequest<Vehiculo?>
{
    public int Id { get; set; }

    public GetVehiculoByIdQuery(int id)
    {
        Id = id;
    }
}