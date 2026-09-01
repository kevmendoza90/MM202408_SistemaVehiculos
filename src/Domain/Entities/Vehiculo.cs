// Entities/Vehiculo.cs
namespace Domain.Entities;

public class Vehiculo
{
    public int Id { get; set; }
    public string Modelo { get; set; } = string.Empty;
    public int Anio { get; set; }
    public int CantidadPuertas { get; set; }

    public int MarcaId { get; set; }
    public Marca? Marca { get; set; }

    public Venta? Venta { get; set; }
}