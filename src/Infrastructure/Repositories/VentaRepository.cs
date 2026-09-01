// Repositories/VentaRepository.cs
using Core.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Infrastructure.Repositories;

public class VentaRepository : IVentaRepository
{
    private readonly AppDbContext _context;

    public VentaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Venta>> GetAllAsync()
        => await _context.Ventas.Include(v => v.Vehiculo).ToListAsync();

    public async Task<Venta?> GetByIdAsync(int id)
        => await _context.Ventas.Include(v => v.Vehiculo).FirstOrDefaultAsync(v => v.Id == id);

    public async Task AddAsync(Venta venta)
    {
        await _context.Ventas.AddAsync(venta);
        await _context.SaveChangesAsync();
    }
}