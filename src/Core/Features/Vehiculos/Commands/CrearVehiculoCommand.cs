using MediatR;

namespace Core.Features.Vehiculos.Commands;

public class CrearVehiculoCommand : IRequest<int>
{
    public string Modelo { get; set; } = string.Empty;
    public int Anio { get; set; }
    public int CantidadPuertas { get; set; }
    public int MarcaId { get; set; }
}