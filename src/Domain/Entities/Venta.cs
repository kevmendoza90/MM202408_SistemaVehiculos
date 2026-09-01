// Entities/Venta.cs
namespace Domain.Entities;

public class Venta
{
    public int Id { get; set; }
    public double TotalVenta { get; set; }
    public int Cantidad { get; set; }

    public int VehiculoId { get; set; }
    public Vehiculo? Vehiculo { get; set; }
}