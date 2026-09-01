using Domain.Entities;
using MediatR;

namespace Core.Features.Marcas.Queries;

public class GetMarcaByIdQuery : IRequest<Marca?>
{
    public int Id { get; set; }

    public GetMarcaByIdQuery(int id)
    {
        Id = id;
    }
}