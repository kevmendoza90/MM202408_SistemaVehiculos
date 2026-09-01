// Repositories/MarcaRepository.cs
using Core.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Infrastructure.Repositories;

public class MarcaRepository : IMarcaRepository
{
    private readonly AppDbContext _context;

    public MarcaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Marca>> GetAllAsync()
        => await _context.Marcas.Include(m => m.Vehiculos).ToListAsync();

    public async Task<Marca?> GetByIdAsync(int id)
        => await _context.Marcas.Include(m => m.Vehiculos).FirstOrDefaultAsync(m => m.Id == id);

    public async Task AddAsync(Marca marca)
    {
        await _context.Marcas.AddAsync(marca);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Marca marca)
    {
        _context.Marcas.Update(marca);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var marca = await _context.Marcas.FindAsync(id);
        if (marca != null)
        {
            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();
        }
    }
}