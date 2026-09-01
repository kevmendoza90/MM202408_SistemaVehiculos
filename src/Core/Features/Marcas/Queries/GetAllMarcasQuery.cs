using Domain.Entities;
using MediatR;

namespace Core.Features.Marcas.Queries;

public class GetAllMarcasQuery : IRequest<IEnumerable<Marca>>
{
}