using Core.Interfaces;
using MediatR;

namespace Core.Features.Marcas.Commands;

public class ActualizarMarcaCommandHandler : IRequestHandler<ActualizarMarcaCommand, bool>
{
    private readonly IMarcaRepository _marcaRepository;

    public ActualizarMarcaCommandHandler(IMarcaRepository marcaRepository)
    {
        _marcaRepository = marcaRepository;
    }

    public async Task<bool> Handle(ActualizarMarcaCommand request, CancellationToken cancellationToken)
    {
        var marca = await _marcaRepository.GetByIdAsync(request.Id);
        if (marca == null) return false;

        marca.Nombre = request.Nombre;
        await _marcaRepository.UpdateAsync(marca);
        return true;
    }
}