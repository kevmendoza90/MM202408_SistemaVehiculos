using Core.Interfaces;
using Domain.Entities;
using MediatR;

namespace Core.Features.Marcas.Queries;

public class GetMarcaByIdQueryHandler : IRequestHandler<GetMarcaByIdQuery, Marca?>
{
    private readonly IMarcaRepository _marcaRepository;

    public GetMarcaByIdQueryHandler(IMarcaRepository marcaRepository)
    {
        _marcaRepository = marcaRepository;
    }

    public async Task<Marca?> Handle(GetMarcaByIdQuery request, CancellationToken cancellationToken)
    {
        return await _marcaRepository.GetByIdAsync(request.Id);
    }
}