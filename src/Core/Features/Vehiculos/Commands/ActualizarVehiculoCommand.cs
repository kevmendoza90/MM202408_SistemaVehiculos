using MediatR;

namespace Core.Features.Vehiculos.Commands;

public class ActualizarVehiculoCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Modelo { get; set; } = string.Empty;
    public int Anio { get; set; }
    public int CantidadPuertas { get; set; }
    public int MarcaId { get; set; }
}