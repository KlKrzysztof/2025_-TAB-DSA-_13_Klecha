using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.Reservation;

namespace FleetManager.Server.DataAccess.Query;

public class ReservationQuery(VehicleContext db) : IReservationQuery
{
    public async Task<List<Reservation>> GetReservationsAsync()
    {

        return await db.Reservations.ToListAsync();
    }

    public async Task<Reservation?> GetReservationByEmployeeId(int id)
    {
        return await db.Reservations.SingleOrDefaultAsync(o => o.EmployeeId == id);
    }

    public async Task<Reservation?> GetReservationByIdAsync(int id)
    {
        return await db.Reservations.SingleOrDefaultAsync(o => o.CaretakeId == id);
    }

    public async Task<Reservation?> GetReservationByVehicleId(int id)
    {
        return await db.Reservations.SingleOrDefaultAsync(o => o.VehicleId == id);
    }

    public async Task CreateReservationAsync(Reservation model)
    {
        var r = await db.Reservations.SingleOrDefaultAsync(o => o.CaretakeId == model.CaretakeId);
        if (r == null)
        {
            await db.Reservations.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateReservationAsync(Reservation model)
    {
        var r = await db.Reservations.AsNoTracking().SingleOrDefaultAsync(o => o.CaretakeId == model.CaretakeId);
        if(r != null)
        {
            db.Reservations.Update(r);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteReservationAsync(int id)
    {
        var r = await db.Reservations.SingleOrDefaultAsync(o => o.CaretakeId == id);
        if (r != null)
        {
            db.Reservations.Remove(r);
            await db.SaveChangesAsync();
        }
    }
}
