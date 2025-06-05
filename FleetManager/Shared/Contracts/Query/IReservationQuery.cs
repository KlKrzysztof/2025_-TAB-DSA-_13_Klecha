using Shared.Models.Reservation;

namespace Shared.Contracts.Query;

public interface IReservationQuery
{
    public Task<List<Reservation>> GetReservationsAsync();

    public Task<Reservation?> GetReservationByIdAsync(int id);

    public Task<Reservation?> GetReservationByVehicleId(int id);

    public Task<Reservation?> GetReservationByEmployeeId(int id);

    public Task CreateReservationAsync(Reservation model);

    public Task UpdateReservationAsync(Reservation model);

    public Task DeleteReservationAsync(int id);
}
