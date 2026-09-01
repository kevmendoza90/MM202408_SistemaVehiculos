// Repositories/VehiculoRepository.cs
using Core.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Infrastructure.Repositories;

public class VehiculoRepository : IVehiculoRepository
{
    private readonly AppDbContext _context;

    public VehiculoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Vehiculo>> GetAllAsync()
        => await _context.Vehiculos.Include(v => v.Marca).Include(v => v.Venta).ToListAsync();

    public async Task<Vehiculo?> GetByIdAsync(int id)
        => await _context.Vehiculos.Include(v => v.Marca).Include(v => v.Venta)
            .FirstOrDefaultAsync(v => v.Id == id);

    public async Task AddAsync(Vehiculo vehiculo)
    {
        await _context.Vehiculos.AddAsync(vehiculo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Vehiculo vehiculo)
    {
        _context.Vehiculos.Update(vehiculo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var vehiculo = await _context.Vehiculos.FindAsync(id);
        if (vehiculo != null)
        {
            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();
        }
    }
}