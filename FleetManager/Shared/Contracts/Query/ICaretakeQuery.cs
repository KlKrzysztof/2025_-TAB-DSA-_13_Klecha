using Shared.Models.Caretake;

namespace Shared.Contracts.Query;

public interface ICaretakeQuery
{
    public Task<List<CaretakeModel>> GetCaretakesAsync();

    public Task<CaretakeModel?> GetCaretakeByIdAsync(int id);

    public Task<CaretakeModel?> GetCaretakeByVehicleIdAsync(int id);

    public Task<List<CaretakeModel>> GetCaretakeByEmployeeIdAsync(int id);

    public Task<CaretakeDetailsModel?> GetCaretakeDetailsByIdAsync(int id);

    public Task<List<CaretakeModel>> GetFinishedCaretakesAsync();

    public Task CreateCaretakeAsync(CaretakeModel model);

    public Task PatchVehicleCaretakerAsync(uint employeeId, int vehicleId);

    public Task UpdateCaretakeAsync(CaretakeModel model);

    public Task DeleteCaretakeAsync(int id);
}