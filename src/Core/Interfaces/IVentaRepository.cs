// Interfaces/IVentaRepository.cs
using Domain.Entities;

namespace Core.Interfaces;

public interface IVentaRepository
{
    Task<IEnumerable<Venta>> GetAllAsync();
    Task<Venta?> GetByIdAsync(int id);
    Task AddAsync(Venta venta);
}