using MediatR;

namespace Core.Features.Ventas.Commands;

public class RealizarVentaCommand : IRequest<int>
{
    public int VehiculoId { get; set; }
    public int Cantidad { get; set; }
    public double TotalVenta { get; set; }
}