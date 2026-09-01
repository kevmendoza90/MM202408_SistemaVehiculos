// Interfaces/IMarcaRepository.cs
using Domain.Entities;

namespace Core.Interfaces;

public interface IMarcaRepository
{
    Task<IEnumerable<Marca>> GetAllAsync();
    Task<Marca?> GetByIdAsync(int id);
    Task AddAsync(Marca marca);
    Task UpdateAsync(Marca marca);
    Task DeleteAsync(int id);
}