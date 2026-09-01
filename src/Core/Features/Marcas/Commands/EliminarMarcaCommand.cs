using MediatR;

namespace Core.Features.Marcas.Commands;

public class EliminarMarcaCommand : IRequest<bool>
{
    public int Id { get; set; }

    public EliminarMarcaCommand(int id)
    {
        Id = id;
    }
}