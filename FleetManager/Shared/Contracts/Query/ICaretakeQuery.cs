using Shared.Models;

namespace Shared.Contracts.Query;

public interface ICaretakeQuery
{

    public Task<List<Caretake>> GetCaretakesAsync();

    public Task<Caretake?> GetCaretakeByIdAsync(int id);

    public Task<Caretake?> GetCaretakeByVehicleId(int id);

    public Task<Caretake?> GetCaretakeByEmployeeId(int id);

    public Task CreateCaretakeAsync(Caretake model);

    public Task UpdateCaretakeAsync(Caretake model);

    public Task DeleteCaretakeAsync(int id);
}