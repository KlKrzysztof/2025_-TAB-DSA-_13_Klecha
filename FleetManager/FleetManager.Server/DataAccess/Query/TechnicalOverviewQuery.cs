using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.TechnicalOverview;

namespace FleetManager.Server.DataAccess.Query;

public class TechnicalOverviewQuery(VehicleContext db) : ITechnicalOverviewQuery
{
    public async Task<List<TechnicalOverview>> GetTechnicalOverviewsAsync()
    {
        return await db.Technicaloverviews.ToListAsync();
    }

    public async Task<TechnicalOverview?> GetTechnicalOverviewByIdAsync(int id)
    {
        return await db.Technicaloverviews.SingleOrDefaultAsync(o => o.OverviewId == id);
    }

    public async Task<List<TechnicalOverview>?> GetTechnicalOverviewsForVehicleAsync(int id)
    {
        var caretake = await db.Caretakes.SingleOrDefaultAsync(o => o.VehicleId == id);
        if (caretake == null)
        {
            return [];
        }
        else
        {
            return await db.Technicaloverviews.Where(o => o.CaretakeId == caretake.CaretakeId).ToListAsync();
        }
    }

    public async Task CreateTechnicalOverviewAsync(TechnicalOverview model)
    {
        var t = await db.Technicaloverviews.SingleOrDefaultAsync(o => o.OverviewId == model.OverviewId);
        if (t == null)
        {
            await db.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateTechnicalOverviewAsync(TechnicalOverview model)
    {
        var t = await db.Technicaloverviews.SingleOrDefaultAsync(o => o.OverviewId == model.OverviewId);
        if (t != null)
        {
            t = model;
            db.Update(t);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteTechnicalOverviewAsync(int id)
    {
        var t = await db.Technicaloverviews.SingleOrDefaultAsync(o => o.OverviewId == id);
        if (t != null)
        {
            db.Remove(t);
            await db.SaveChangesAsync();
        }
    }
}