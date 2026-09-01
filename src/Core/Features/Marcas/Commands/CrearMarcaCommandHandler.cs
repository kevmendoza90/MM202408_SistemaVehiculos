using Core.Interfaces;
using Domain.Entities;
using MediatR;

namespace Core.Features.Marcas.Commands;

public class CrearMarcaCommandHandler : IRequestHandler<CrearMarcaCommand, int>
{
    private readonly IMarcaRepository _marcaRepository;

    public CrearMarcaCommandHandler(IMarcaRepository marcaRepository)
    {
        _marcaRepository = marcaRepository;
    }

    public async Task<int> Handle(CrearMarcaCommand request, CancellationToken cancellationToken)
    {
        var marca = new Marca { Nombre = request.Nombre };
        await _marcaRepository.AddAsync(marca);
        return marca.Id;
    }
}