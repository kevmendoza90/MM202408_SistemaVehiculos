using Core.Interfaces;
using Domain.Entities;
using MediatR;

namespace Core.Features.Marcas.Queries;

public class GetAllMarcasQueryHandler : IRequestHandler<GetAllMarcasQuery, IEnumerable<Marca>>
{
    private readonly IMarcaRepository _marcaRepository;

    public GetAllMarcasQueryHandler(IMarcaRepository marcaRepository)
    {
        _marcaRepository = marcaRepository;
    }

    public async Task<IEnumerable<Marca>> Handle(GetAllMarcasQuery request, CancellationToken cancellationToken)
    {
        return await _marcaRepository.GetAllAsync();
    }
}