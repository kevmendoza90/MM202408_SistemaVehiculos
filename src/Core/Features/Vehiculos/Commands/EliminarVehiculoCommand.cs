using MediatR;

namespace Core.Features.Vehiculos.Commands;

public class EliminarVehiculoCommand : IRequest<bool>
{
    public int Id { get; set; }

    public EliminarVehiculoCommand(int id)
    {
        Id = id;
    }
}