using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.Reservation;

namespace FleetManager.Server.DataAccess.Query;

public class ReservationQuery(VehicleContext db) : IReservationQuery
{
    public async Task<List<ReservationModel>> GetReservationsAsync()
    {
        return await db.Reservations.ToListAsync();
    }

    public async Task<List<ReservationModel>> GetReservationsByEmployeeId(int id)
    {
        return await db.Reservations.Where(o => o.EmployeeId == id).ToListAsync();
    }

    public async Task<ReservationModel?> GetReservationByIdAsync(int id)
    {
        return await db.Reservations.SingleOrDefaultAsync(o => o.ReservationId == id);
    }

    public async Task<List<ReservationModel>> GetReservationsByVehicleId(int id)
    {
        return await db.Reservations.Where(o => o.VehicleId == id).ToListAsync();
    }

    public async Task CreateReservationAsync(ReservationModel model)
    {
        var r = await db.Reservations.SingleOrDefaultAsync(o => o.ReservationId == model.ReservationId);
        if (r == null)
        {
            await db.Reservations.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateReservationAsync(ReservationModel model)
    {
        var r = await db.Reservations.AsNoTracking().SingleOrDefaultAsync(o => o.ReservationId == model.ReservationId);
        if(r != null)
        {
            db.Reservations.Update(r);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteReservationAsync(int id)
    {
        var r = await db.Reservations.SingleOrDefaultAsync(o => o.ReservationId == id);
        if (r != null)
        {
            db.Reservations.Remove(r);
            await db.SaveChangesAsync();
        }
    }
}
