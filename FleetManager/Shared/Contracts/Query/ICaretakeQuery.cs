using Shared.Models.Caretake;

namespace Shared.Contracts.Query;

public interface ICaretakeQuery
{

    public Task<List<CaretakeModel>> GetCaretakesAsync();

    public Task<CaretakeModel?> GetCaretakeByIdAsync(int id);

    public Task<CaretakeModel?> GetCaretakeByVehicleId(int id);

    public Task<CaretakeModel?> GetCaretakeByEmployeeId(int id);

    public Task CreateCaretakeAsync(CaretakeModel model);

    public Task UpdateCaretakeAsync(CaretakeModel model);

    public Task DeleteCaretakeAsync(int id);
}