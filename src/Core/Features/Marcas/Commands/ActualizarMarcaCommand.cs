using MediatR;

namespace Core.Features.Marcas.Commands;

public class ActualizarMarcaCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
}