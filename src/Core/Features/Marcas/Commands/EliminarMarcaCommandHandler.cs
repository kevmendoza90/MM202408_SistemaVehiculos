using Core.Interfaces;
using MediatR;

namespace Core.Features.Marcas.Commands;

public class EliminarMarcaCommandHandler : IRequestHandler<EliminarMarcaCommand, bool>
{
    private readonly IMarcaRepository _marcaRepository;

    public EliminarMarcaCommandHandler(IMarcaRepository marcaRepository)
    {
        _marcaRepository = marcaRepository;
    }

    public async Task<bool> Handle(EliminarMarcaCommand request, CancellationToken cancellationToken)
    {
        var marca = await _marcaRepository.GetByIdAsync(request.Id);
        if (marca == null) return false;

        await _marcaRepository.DeleteAsync(request.Id);
        return true;
    }
}   