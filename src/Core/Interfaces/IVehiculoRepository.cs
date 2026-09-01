// Interfaces/IVehiculoRepository.cs
using Domain.Entities;

namespace Core.Interfaces;

public interface IVehiculoRepository
{
    Task<IEnumerable<Vehiculo>> GetAllAsync();
    Task<Vehiculo?> GetByIdAsync(int id);
    Task AddAsync(Vehiculo vehiculo);
    Task UpdateAsync(Vehiculo vehiculo);
    Task DeleteAsync(int id);
}