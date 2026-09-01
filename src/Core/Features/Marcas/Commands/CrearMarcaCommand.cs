using MediatR;

namespace Core.Features.Marcas.Commands;

public class CrearMarcaCommand : IRequest<int>
{
    public string Nombre { get; set; } = string.Empty;
}