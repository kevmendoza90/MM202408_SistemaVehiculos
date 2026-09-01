using Core.Interfaces;
using Domain.Entities;
using MediatR;

namespace Core.Features.Ventas.Commands;

public class RealizarVentaCommandHandler : IRequestHandler<RealizarVentaCommand, int>
{
    private readonly IVentaRepository _ventaRepository;
    private readonly IVehiculoRepository _vehiculoRepository;

    public RealizarVentaCommandHandler(IVentaRepository ventaRepository, IVehiculoRepository vehiculoRepository)
    {
        _ventaRepository = ventaRepository;
        _vehiculoRepository = vehiculoRepository;
    }

    public async Task<int> Handle(RealizarVentaCommand request, CancellationToken cancellationToken)
    {
        var vehiculo = await _vehiculoRepository.GetByIdAsync(request.VehiculoId);
        if (vehiculo == null)
            throw new InvalidOperationException($"No existe un Vehiculo con Id {request.VehiculoId}.");

        if (vehiculo.Venta != null)
            throw new InvalidOperationException("Este vehiculo ya tiene una venta registrada.");

        var venta = new Venta
        {
            VehiculoId = request.VehiculoId,
            Cantidad = request.Cantidad,
            TotalVenta = request.TotalVenta
        };

        await _ventaRepository.AddAsync(venta);
        return venta.Id;
    }
}