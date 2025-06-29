﻿using Shared.Models.Reservation;

namespace Shared.Contracts.Query;

public interface IReservationQuery
{
    public Task<List<ReservationModel>> GetReservationsAsync();

    public Task<ReservationModel?> GetReservationByIdAsync(int id);

    public Task<List<ReservationModel>> GetReservationsByVehicleId(int id);

    public Task<List<ReservationModel>> GetReservationsByEmployeeId(int id);

    public Task CreateReservationAsync(ReservationModel model);

    public Task UpdateReservationAsync(ReservationModel model);

    public Task DeleteReservationAsync(int id);
}